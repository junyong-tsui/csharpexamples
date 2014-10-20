using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace ExcelTest
{
    public partial class Form1 : Form
    {
        string con = ConfigurationManager.ConnectionStrings["excelImOrExport"].ConnectionString;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var table = SqlHelper.ExcuteDataTable(con, CommandType.Text, "SELECT * FROM T_Customers");
            ExcelHelper.Export(table, "custormer.xls");
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            var tablst = ExcelHelper.Import("客户资料new.xls");
            string sql = @"INSERT INTO T_Customers(CC_CustomerName,CC_CellPhone,CC_Landline,CC_BuyDate,CC_CarNum,CC_BracketNum)
                     VALUES(@name,@cellPhone,@landline,@date,@carNum,@bracketNum)";
            #region  非事务版
            // foreach (DataRow row in tablst[0].Rows)
            //{
            //    SqlParameter[] pms = new SqlParameter[]{
            //         new SqlParameter("@name",row[0]),
            //         new SqlParameter("@cellPhone",row[1]),
            //         new SqlParameter("@landline", row[2]),
            //         new SqlParameter("@date", row[5]),
            //         new SqlParameter("@carNum", row[4]),
            //         new SqlParameter("@bracketNum", row[3])
            //     };

            //    SqlHelper.ExcuteNonQuery(con,CommandType.Text,sql, pms);
            //}   
             #endregion
            #region 同一连接事务版
            using (var connection = new SqlConnection(con))
            {
                connection.Open();
                var trans = connection.BeginTransaction();
                try
                {
                    foreach (DataRow row in tablst[0].Rows)
                    {
                        SqlParameter[] pms = new SqlParameter[]
                        {
                            new SqlParameter("@name",row[0]),
                            new SqlParameter("@cellPhone",row[1]),
                            new SqlParameter("@landline", row[2]),
                            new SqlParameter("@date", row[5]),
                            new SqlParameter("@carNum", row[4]),
                            new SqlParameter("@bracketNum", row[3])
                        };
                        SqlHelper.ExcuteNonQuery(connection, trans, CommandType.Text, sql, pms);
                    }
                    trans.Commit();
                }
                catch (Exception err)
                {
                    trans.Rollback();
                    MessageBox.Show(err.Message);
                }
            }
            #endregion
            #region 不同连接事务版 测试发现异常信息：“事务不是与当前连接无关联，就是已完成。”跟代码发现事务是基于连接的：
            //可以看出这种事务能力较低，必须重复指定一个连接对象。
            //即：command执行前会检查它的Transaction.Connection和Connection是否为同一个连接 如果不是一个连接则抛异常。
            /*
             *  ValidateCommand()
             *  {
             *     // to validate other things such as connectionState......
             *     if ((this._transaction != null) && (this._activeConnection != this._transaction.Connection))
             *     {
             *           throw ADP.TransactionConnectionMismatch();
             *     }
             *     //to validate other things
             * }
             */

            //using (var connection =new SqlConnection(con))
            //{
            //    connection.Open();
            //    var trans = connection.BeginTransaction();
            //    try
            //    {
            //        foreach (DataRow row in tablst[0].Rows)
            //        {
            //            SqlParameter[] pms = new SqlParameter[]
            //            {
            //                new SqlParameter("@name",row[0]),
            //                new SqlParameter("@cellPhone",row[1]),
            //                new SqlParameter("@landline", row[2]),
            //                new SqlParameter("@date", row[5]),
            //                new SqlParameter("@carNum", row[4]),
            //                new SqlParameter("@bracketNum", row[3])
            //            };
            //            using (var connection2=new SqlConnection(con))
            //            {
            //                SqlHelper.ExcuteNonQuery(connection2, trans, CommandType.Text, sql, pms);
            //            }                       
            //        }
            //        trans.Commit();      
            //    }
            //    catch (Exception err)
            //    {
            //        trans.Rollback();
            //        MessageBox.Show(err.Message);
            //    }
            //}
            #endregion

            MessageBox.Show("导出成功");
        }
    }
}
