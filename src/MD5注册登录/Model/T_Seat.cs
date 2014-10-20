using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD5注册登录
{
    public class T_Seat
    {
        public int Identifier { get; set; }

        public string  UserName { get; set; }

        public string Password { get; set; }

        public LoginStatus LoginStatus { get; set; }


    }

    /// <summary>
    /// 登录状态
    /// </summary>
    public enum LoginStatus
    { 
        /// <summary>
        /// 用户不存在
        /// </summary>
        NoneExist=1,

        /// <summary>
        /// 成功
        /// </summary>
        Success=2,
        
        /// <summary>
        /// 失败
        /// </summary>
        Fail=4
    }
}
