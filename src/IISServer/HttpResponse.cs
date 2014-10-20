using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IISServer
{
    /// <summary>
    /// http响应报文封装类
    /// </summary>
    public class HttpResponse
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public string StateCode { get; set; }

        /// <summary>
        /// 状态描述
        /// </summary>
        public string StateDescription { get; set; }

        /// <summary>
        /// 相应报文的类型
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// 报文体
        /// </summary>
        public byte[] Body { get; set; }

        /// <summary>
        /// 报文头
        /// </summary>
        public byte[] Header
        {
            get
            {
                string responseHeader = string.Format(
@"HTTP/1.1 {0} {1}
Connection: keep-alive
Date: Thu, 26 Jul 2007 14:00:02 GMT
Server: Microsoft-IIS/6.0
X-Powered-By: ASP.NET
Content-Length: {2}
Content-Type: {3}

", StateCode, StateDescription, Body.Length, ContentType);
                return Encoding.UTF8.GetBytes(responseHeader);
            }
        }
    }
}
