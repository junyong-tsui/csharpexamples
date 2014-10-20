using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IISServer
{
    /// <summary>
    /// 我的aspx页面
    /// </summary>
    public class MyAspxPage:IHttpHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpcontext"></param>
        public void ProcessRequest(HttpContext httpcontext)
        {
            string htm = string.Format(@"<html><head><title>我的第一个处理程序</title></head><body><h1>{0}</h1></body></html>",DateTime.Now.ToString());

            httpcontext.HttpResponse.StateCode = "200";          
            httpcontext.HttpResponse.StateDescription = "OK";
            httpcontext.HttpResponse.Body = Encoding.UTF8.GetBytes(htm);
        }
    }
}
