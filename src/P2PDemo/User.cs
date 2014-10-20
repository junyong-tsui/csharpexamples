using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2PDemo
{
    /// <summary>
    /// 
    /// </summary>
    public class User
    {
        /// <summary>
        /// 主机名
        /// </summary>
        public string UserHostName { get; set; }

        /// <summary>
        /// IP
        /// </summary>
        public string IP{ get; set; }

        /// <summary>
        /// 登录状态
        /// </summary>
        public State LoginState { get; set; }
     
        public override string ToString()
        {
            return UserHostName + ":" + IP;
        }
    }

    /// <summary>
    /// 用户登录状态
    /// </summary>
    public enum State
    { 
        /// <summary>
        /// 下线
        /// </summary>
        OffLine=1,    

        /// <summary>
        /// 上线
        /// </summary>
        OnLine=2,
    }
}
