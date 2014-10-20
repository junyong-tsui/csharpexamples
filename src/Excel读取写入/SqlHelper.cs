using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Excel读取写入
{
   public static class SqlHelper
   {
       /// <summary>
       /// 执行sql返回受影响的行数
       /// </summary>
       /// <param name="connnectionString">连接字符串</param>
       /// <param name="commandType">storeProcedure,text</param>
       /// <param name="commandText">sql语句或存储过程的名称</param>
       /// <param name="parameters">参数列表</param>
       /// <returns></returns>
       public static int ExcuteNonQuery(string connectionString, CommandType commandType, string commandText, params SqlParameter[] parameters)
       {
           using (var connection = new SqlConnection(connectionString))
           {
               var cmd = PrepareCommand(connection, commandType, commandText, parameters);
               return cmd.ExecuteNonQuery();
           }
       }

       /// <summary>
       /// 执行sql返回查询第一行第一列的值
       /// </summary>
       /// <param name="connnectionString">连接字符串</param>
       /// <param name="commandType">storeProcedure,text</param>
       /// <param name="commandText">sql语句或存储过程的名称</param>
       /// <param name="parameters">参数列表</param>
       /// <returns></returns>
       public static object ExcuteScalar(string connectionString, CommandType commandType, string commandText, params SqlParameter[] parameters)
       {
           using (var connection = new SqlConnection(connectionString))
           {
               var cmd = PrepareCommand(connection, commandType, commandText, parameters);
               return cmd.ExecuteScalar();
           }
       }

       /// <summary>
       /// 执行sql返回只读的SqlDataReader
       /// </summary>
       /// <param name="connnectionString">连接字符串</param>
       /// <param name="commandType">storeProcedure,text</param>
       /// <param name="commandText">sql语句或存储过程的名称</param>
       /// <param name="parameters">参数列表</param>
       /// <returns></returns>
       public static SqlDataReader ExcuteDataReader(string connectionString, CommandType commandType, string commandText, params SqlParameter[] parameters)
       {
           var connection = new SqlConnection(connectionString);
           try
           {               
               var cmd = PrepareCommand(connection, commandType, commandText, parameters);
             
               return cmd.ExecuteReader(CommandBehavior.CloseConnection);
           }
           catch 
           {
               connection.Close();
               throw;
           }
       }

       /// <summary>
       /// 执行sql并返回datatable
       /// </summary>
       /// <param name="connnectionString">连接字符串</param>
       /// <param name="commandType">storeProcedure,text</param>
       /// <param name="commandText">sql语句或存储过程的名称</param>
       /// <param name="parameters">参数列表</param>
       /// <returns></returns>
       public static DataTable ExcuteDataTable(string connectionString, CommandType commandType, string commandText, params SqlParameter[] parameters)
       {
           using (var connection = new SqlConnection(connectionString))
           {
               var cmd = PrepareCommand(connection, commandType, commandText, parameters);
               using (var da=new SqlDataAdapter(cmd))
               {
                   var table = new DataTable();
                   da.Fill(table);
                   return table;
               }
           }
       }

       /// <summary>
       /// 准备执行的command命令
       /// </summary>
       /// <param name="connection">连接对象</param>
       /// <param name="commandType">storeProcedure,text</param>
       /// <param name="commandText">sql语句或存储过程的名称</param>
       /// <param name="parameters">参数列表</param>
       /// <returns></returns>
       private static SqlCommand PrepareCommand(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] parameters)
       {
           if (connection.State != ConnectionState.Open)
               connection.Open();
       
           SqlCommand cmd = new SqlCommand(commandText, connection) { CommandType=commandType};
          
           if (parameters.Length > 0) {
               cmd.Parameters.AddRange(parameters);           
           }
           return cmd;
       }
   }
}
