using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IISServer
{
    /// <summary>
    /// 请求处理的入口
    /// </summary>
    public class HttpApplication : IHttpHandler
    {
        /// <summary>
        /// 处理各种请求的统一入口
        /// </summary>
        /// <param name="httpcontext"></param>
        public void ProcessRequest(HttpContext httpcontext)
        {
            #region 1获取请求的物理路径

            string rootPath = AppDomain.CurrentDomain.BaseDirectory; //网站的跟目录
            string relativePath = httpcontext.HttpRequest.Url;         //相对路径
            string pysicalFilePath = Path.Combine(rootPath, relativePath.TrimStart('/'));

            #endregion           

            #region 2判断请求的文件是否存在

            if (!File.Exists(pysicalFilePath))
            {
                httpcontext.HttpResponse.StateCode = "404";
                httpcontext.HttpResponse.StateDescription = "Not Found";
                httpcontext.HttpResponse.ContentType = "text/html";
                string notFoundFilePath = Path.Combine(rootPath, @"WebSite\404.htm");
                httpcontext.HttpResponse.Body = File.ReadAllBytes(notFoundFilePath);
                return;
            }

            #endregion

            #region 3设置响应报文的类型
           
            httpcontext.HttpResponse.ContentType = GetContenType(Path.GetExtension(relativePath));
            
            #endregion

            #region 3处理动态文件

            if (Path.GetExtension(relativePath) == ".aspx")
            {
                //获取页面类的名称
                string pageName = Path.GetFileNameWithoutExtension(relativePath);

                //获取页面类对应的类型          
                var pageType = Type.GetType("IISServer." + pageName);

                //类型没有实现IHttpHandler 抛出异常
                if (!typeof(IHttpHandler).IsAssignableFrom(pageType))
                {
                    throw new NotSupportedException(pageType.ToString() + "not support IHttpHandler");
                }

                //处理动态页面的请求
                IHttpHandler obj = (IHttpHandler)System.Activator.CreateInstance(pageType);
                obj.ProcessRequest(httpcontext);               

                return;
            }

            #endregion

            #region 4处理静态文件

            httpcontext.HttpResponse.StateCode = "200";            
            httpcontext.HttpResponse.StateDescription = "OK";
            httpcontext.HttpResponse.Body = File.ReadAllBytes(pysicalFilePath);

            #endregion
        }

        /// <summary>
        /// 获取请求文件对应的响应报文的响应类型
        /// </summary>
        /// <param name="ext"></param>
        /// <returns></returns>
        private string GetContenType(string ext)
        {
            string type = "text/html; charset=UTF-8";
            switch (ext)
            {
                case ".aspx":
                case ".html":
                case ".htm":
                    type = "text/html; charset=UTF-8";
                    break;
                case ".png":
                    type = "image/png";
                    break;
                case ".gif":
                    type = "image/gif";
                    break;
                case ".jpg":
                case ".jpeg":
                    type = "image/jpeg";
                    break;
                case ".css":
                    type = "text/css";
                    break;
                case ".js":
                    type = "application/x-javascript";
                    break;
                default:
                    type = "text/plain; charset=gbk";
                    break;
            }
            return type;
        }
    }
}
