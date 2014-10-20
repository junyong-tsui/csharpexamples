using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IISServer
{
    /// <summary>
    /// http请求报文的封装类
    /// </summary>
    public class HttpRequest
    {
        public HttpRequest(string requestContext)
        {
            InternalInital(requestContext);        
        }
       
        /// <summary>
        /// 请求的方式
        /// </summary>
        public string HttpMethod { get; set; }
        
        /// <summary>
        ///请求的Url 
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// http协议版本
        /// </summary>
        public string HttpVersion { get; set; }

        /// <summary>
        /// 请求报文头信息
        /// </summary>
        public Dictionary<string,string> HeaderDictionary { get; set; }

        /// <summary>
        /// 请求报文体信息
        /// </summary>
        public Dictionary<string,string> BodyDictionary { get; set; }

        /// <summary>
        /// 初始化报文
        /// </summary>
        private void InternalInital(string requestContext)
        {
            var lines =requestContext.Split(new char[] { '\r', '\n' },  StringSplitOptions.RemoveEmptyEntries);   
            
            //1获取请求行的信息
            var head = lines[0].Split(' ');
            HttpMethod = head[0];
            Url = head[1];
            HttpVersion = head[2];

            //2获取实体头的信息

            //3获取请求正文的内容
        }
    }
}
