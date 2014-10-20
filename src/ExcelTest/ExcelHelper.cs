using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using NPOI.SS.UserModel;
using System.Data;
using NPOI.HSSF.UserModel;
using System.IO;

namespace ExcelTest
{
    /*
     * Author: gzr
     * Data:2013-11-12 19:24
     * the first trial of excelHelper
     * this version maily solve the conversion between datatable and excel and focuses on the datatype conversion
     */

    /// <summary>
    /// excel helper provides the conversion between datatable and excel
    /// </summary>
    public static class ExcelHelper
    {
        /// <summary>
        /// export the datatable to excel
        /// </summary>
        /// <param name="src">data source</param>
        /// <param name="filePath">the physical path of creating excel file</param>
        public static void Export(DataTable src,string filePath)
        {
            #region create the workBook  
            
            //create the workbook
            IWorkbook workBook = new HSSFWorkbook();

            //create the worksheet
            ISheet sheet = workBook.CreateSheet("用户资料"); 
  
            //create header of sheet
            IRow header = sheet.CreateRow(0);
            foreach (DataColumn column in src.Columns)
            {
                header.CreateCell(column.Ordinal);
            }

            //ceate the content of sheet
            foreach (DataRow row in src.Rows)
            {
                //create the row of sheet
                IRow contentRow = sheet.CreateRow(src.Rows.IndexOf(row));
                foreach (DataColumn column in src.Columns)
                {   
                    //create the cell of sheet
                    ICell cell = contentRow.CreateCell(column.Ordinal);
                    
                    //notice we cann't assign the null to the cell which means we have to judge whether the cell is null
                    //when import excel to datatable
                    if (row[column.Ordinal]!=null)
                    {
                        SetCellValue(cell, column.DataType, row[column.Ordinal]);                        
                    }
                }
            }
            #endregion

            #region write the workBook to disk

            using (var fsWrite = File.OpenWrite(filePath))
            {
                workBook.Write(fsWrite);
                workBook = null;
            }
            
            #endregion
        }

        /// <summary>
        ///  Import Speicified Excel to DataTable
        /// </summary>
        /// <param name="filePath">the physical path of the specified excel</param>
        /// <returns>List<DataTable> every dataTable maps to one sheet of workBook  if count==0</returns>
        public static List<DataTable> Import(string filePath)
        {
            using (var fsRead=File.OpenRead(filePath))
            {
                IWorkbook workBook = new HSSFWorkbook(fsRead);
                List<DataTable> tableLst=new List<DataTable>();
                for (int i = 0; i < workBook.NumberOfSheets; i++)
                {
                    ISheet sheet = workBook.GetSheetAt(i);
                    DataTable table = new DataTable();

                    #region construct the columns  
                  
                    IRow row = sheet.GetRow(0);
                    for (int j = 0; j < row.LastCellNum; j++)
                    {
                        table.Columns.Add(row.GetCell(j).StringCellValue);
                    }                    
                    #endregion

                    #region construct the content
                
                    for (int j = 1; j <= sheet.LastRowNum; j++)
                    {
                        row = sheet.GetRow(j);
                        var dataRow = table.NewRow();                        
                        for (int k = 0; k < row.LastCellNum; k++)
                        {
                            ICell cell = row.GetCell(k);
                            if (cell == null) continue;                          
                            dataRow[cell.ColumnIndex] = GetCellValue(cell);                  
                        }
                        table.Rows.Add(dataRow);
                    }
                    
                    #endregion                    
                    
                    //add table in the list
                    tableLst.Add(table);
                }
                workBook = null;
                return tableLst;                
            }  
        }

        /// <summary>
        /// set the cell value 
        /// </summary>
        /// <param name="cell">the cell which will be assigned value</param>
        /// <param name="type">the type of assigning value</param>
        /// <param name="value">the assigning value</param>
        private static void SetCellValue(ICell cell,Type type,object value)
        {
             switch (type.ToString())
             {
                case "System.String":
                      cell.SetCellValue(value.ToString());
                      break;
                case "System.DateTime":             
                      cell.SetCellValue((DateTime)value);                   
                      break;
                case "System.Boolean":               
                      cell.SetCellValue((bool)value);
                      break;
                case "System.Int16"://Numeric
                case "System.Int32":
                case "System.Int64":
                case "System.Byte": 
                case "System.Decimal":
                case "System.Double":                   
                      cell.SetCellValue(Convert.ToDouble(value));
                      break;                   
                case "System.DBNull":                    
                      break;
            } 
        }
         
        /// <summary>
        ///  get the cell value
        /// </summary>
        /// <param name="cell">the cell which to get value form</param>
        /// <param name="type">the value of value</param>
        /// <returns>object</returns>
        private static object GetCellValue(ICell cell) 
        {               
            switch (cell.CellType)
            {               
                case CellType.BOOLEAN:
                     return cell.BooleanCellValue;                   
                case CellType.NUMERIC:
                     return  DateUtil.IsCellDateFormatted(cell)?(object)DateTime.FromOADate(cell.NumericCellValue):(object)cell.NumericCellValue;
                case CellType.STRING:
                     return cell.StringCellValue;
                //BLANK, ERROR, FORMULA, Unknown 
                default:
                     return DBNull.Value;                   
            }
        }
    }
}
