using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IISServer
{
    /// <summary>
    /// http请求的上下文
    /// </summary>
    public class HttpContext
    {
        public HttpRequest HttpRequest { get; set; }
        public HttpResponse HttpResponse { get; set; }
        public HttpContext(string requsetContext)
        {
            HttpRequest = new HttpRequest(requsetContext);
            HttpResponse = new HttpResponse();
        }
    }
}
