using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IISServer
{
    /// <summary>
    /// 处理动态内容
    /// </summary>
    interface IHttpHandler
    {
        void ProcessRequest(HttpContext httpcontext);
    }
}
