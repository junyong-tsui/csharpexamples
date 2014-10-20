using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MD5注册登录
{
    public class T_SeatDal
    {
        static string conn = ConfigurationManager.ConnectionStrings["md5test"].ConnectionString;
     
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="pwd">用户密码</param>
        /// <returns>-1用户不存在，0用户登录失败，1用户登录成功</returns>
        public T_Seat Login(int id, string pwd) 
        {
            string sql = @"SELECT CC_AutoId,CC_LoginId,CC_UserName,CC_LoginPassword FROM T_Seats WHERE T_Seats.CC_LoginId=@uid";           

            using (var dr = SqlHelper.ExcuteDataReader(conn, CommandType.Text, sql, new SqlParameter("@uid", name)))
            {
                if (dr.HasRows)
                {
                    T_Seat t_seat = new T_Seat();

                    while (dr.Read())
                    {
                        t_seat.Identifier = dr.GetInt32(0);
                        t_seat.UserName = dr.GetString(2);
                        t_seat.Password = dr.GetString(3);
                    }

                    return t_seat;
                }               
            }
            return null;
        }

        /// <summary>
        /// 改变密码
        /// </summary>
        /// <returns></returns>
        public int ChangePwd(int id,string newPwd)
        {
            string sql = "UPDATE T_Seats SET CC_LoginPassword=@password WHERE T_Seats.CC_AutoId=@autoId";

            return SqlHelper.ExcuteNonQuery(conn, CommandType.Text, sql, new SqlParameter("@password", Md5Helper.GetMd5FromString(newPwd)),
               new SqlParameter("@autoId", id));
        }
    }
}
