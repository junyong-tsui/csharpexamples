using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 省市联动.Model;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace 省市联动.Dal
{
    public  class TblAreaDal
    {
        string con = ConfigurationManager.ConnectionStrings["gpinyin"].ConnectionString;

        /// <summary>
        /// 根据Pid获取省市的信息
        /// </summary>
        /// <param name="pid">父Id</param>
        /// <returns></returns>
        public List<TblArea> GetTblAreaById(int pid)
        {
            List<TblArea> subAreas = new List<TblArea>();

            string sql = "SELECT AreaId,AreaName,AreaPId  from TblArea WHERE AreaPId=@pid";

            using (var dr=SqlHelper.ExcuteDataReader(con,CommandType.Text,sql,new SqlParameter("@pid",pid)))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        TblArea area = new TblArea()
                        {
                            AreaId=dr.GetInt32(0),
                            AreaName=dr.GetString(1),
                            AreaPId=dr.GetInt32(2)
                        };

                        subAreas.Add(area);
                    }                
                }
            }
            return subAreas;        
        }


        /// <summary>
        /// 删除区域
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public int DelTblAreaById(int pid)
        {
            string sql = "DELETE FROM TblArea WHERE AreaId=@id";
            return SqlHelper.ExcuteNonQuery(con, CommandType.Text, sql, new SqlParameter("@id", pid));        
        }
    }
}
