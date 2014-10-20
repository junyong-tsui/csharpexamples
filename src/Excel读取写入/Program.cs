using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using NPOI;
using Ionic;
using NPOI.HSSF.UserModel;
using System.IO;
namespace Excel读取写入
{
    class Program
    {
        /*
            NPOI涉及的api: HSSFWorkbook ,Sheet,Row,Cell
         *        
         *         创建工作簿：var workbook=new HSSFWorkbook()
         *         创建工作表: var sheet=workbook.CreateSheet()
         *         创建行:     var row=sheet.CreateRow(index)
         *         创建单元格: var cell=sheet.CreateCell(index)
         *         设置单元格的值： cell.SetCellValue([bool|double|string|date])
         *      
         *         读取相应的地方替换为Get即可。
         
         */

        /// <summary>
        ///连接字符串
        /// </summary>
        static string conStr = ConfigurationManager.ConnectionStrings["md5test"].ConnectionString;

        static void Main(string[] args)
        {

            //#region 数据库数据导入excel

            //using (var dr = SqlHelper.ExcuteDataReader(conStr, CommandType.Text, "SELECT autoId,uName,age,height,gender FROM TblPerson"))
            //{
            //    #region 创建工作簿并填充数据

            //    //1工作簿的创建
            //    HSSFWorkbook workbook = new HSSFWorkbook();

            //    //2工作表的创建
            //    var pesonSheet = workbook.CreateSheet("人员");
            //    workbook.CreateSheet("hello to excel");

            //    //3工作簿的列头创建 Excel而言行为真 列为假 类似html的table也是行为真列为假
            //    var headerRow = pesonSheet.CreateRow(0);
            //    headerRow.CreateCell(0).SetCellValue("autoId");
            //    headerRow.CreateCell(1).SetCellValue("uName");
            //    headerRow.CreateCell(2).SetCellValue("age");
            //    headerRow.CreateCell(3).SetCellValue("height");
            //    headerRow.CreateCell(4).SetCellValue("gender");

            //    //3创建行并填充数据 
            //    if (dr.HasRows)
            //    {
            //        int i = 1;
            //        while (dr.Read())
            //        {
            //            var row = pesonSheet.CreateRow(i++);
            //            row.CreateCell(0).SetCellValue(dr.GetValue(0).ToString());
            //            row.CreateCell(1).SetCellValue(dr.GetValue(1).ToString());
            //            row.CreateCell(2).SetCellValue(dr.GetValue(2).ToString());
            //            row.CreateCell(3).SetCellValue(dr.GetValue(3).ToString());
            //            row.CreateCell(4).SetCellValue(dr.GetValue(4).ToString());
            //        }
            //    }
            //    #endregion

            //    #region 保存excel至指定目录

            //    using (var fs = File.OpenWrite("peson.xls"))
            //    {
            //        workbook.Write(fs);
            //        workbook.Dispose();
            //    }
            //    #endregion
            //}

            //#endregion


            #region 读取excel数据修改并加载至集合中打印到屏幕上
            using (var fr = File.OpenRead("peson.xls"))
            {
                using (var workbook = new HSSFWorkbook(fr))
                {
                    var sheet = workbook.GetSheet("人员");
                    List<Person> persons = new List<Person>();
                    
                    for (int i = 1; i <= sheet.LastRowNum; i++)
                    {
                        var row = sheet.GetRow(i);
                        var person = new Person()
                        {
                            Identity =Convert.ToInt32(row.GetCell(0).StringCellValue),
                            Name = row.GetCell(1).StringCellValue,
                            Age = Convert.ToInt32(row.GetCell(2).StringCellValue),
                            Height =string.IsNullOrEmpty(row.GetCell(3).StringCellValue)?0:Convert.ToInt32(row.GetCell(3).StringCellValue),
                            Gender = string.IsNullOrEmpty(row.GetCell(4).StringCellValue) ? false : Convert.ToBoolean(row.GetCell(4).StringCellValue)
                        };
                        persons.Add(person);
                    }
                    Console.WriteLine(string.Join("\r\n",persons));
                }
            }
            #endregion

            Console.ReadKey();
        }
    }
    class Person
    {
        public int Identity { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public bool Gender { get; set; }
        public override string ToString()
        {
            return string.Format("Identity:{0}，Name:{1},Age:{2},Height:{3},Gender:{4}", Identity, Name, Age, Height, Gender);
        }
    }
}
