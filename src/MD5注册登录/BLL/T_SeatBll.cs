using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD5注册登录.BLL
{
    public  class T_SeatBll
    {
        public int Login(int id, string pwd) 
        {
            return (new T_SeatDal()).Login(id, pwd);
        }

        public bool ChangPwd(int id,string newPwd)
        {
            return (new T_SeatDal()).ChangePwd(id, newPwd)>0;
        }
    }
}
