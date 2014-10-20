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
using Microsoft.International.Converters.PinYinConverter;
using Microsoft.International.Converters.TraditionalChineseToSimplifiedConverter;
using System.Data.SqlClient;
namespace PinYin
{
    public partial class Form1 : Form
    {
        string con = ConfigurationManager.ConnectionStrings["gpinyin"].ConnectionString;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string input=txtInput.Text.Trim();
            txtResult.Text = ConvertToPinYin(input);            
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            string input = txtInput.Text.Trim();

            txtResult.Text = ChineseConverter.Convert(input, ChineseConversionDirection.SimplifiedToTraditional);
        }

        private void btnGeneratePinyin_Click(object sender, EventArgs e)
        {
            /*
               1从数据库读取数据并修改数据 CC_pinyin
             */
            using (var dr=SqlHelper.ExcuteDataReader(con,CommandType.Text,"SELECT CC_AutoId ,CC_CustomerName FROM T_Customers"))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        int id = dr.GetInt32(0);
                        string name = dr.GetString(1);
                        SqlHelper.ExcuteNonQuery(con,CommandType.Text,"UPDATE T_Customers SET CC_pinyin=@pinyin WHERE CC_AutoId=@id",
                            new SqlParameter("@pinyin",ConvertToPinYin(name)),new SqlParameter("@id",id));
                    }
                }
                MessageBox.Show("转换成功");
            }
        }
        

        private string ConvertToPinYin(string input)
        {        
            StringBuilder sb = new StringBuilder();
            foreach (var item in input)
	        {
                string s= new ChineseChar(item).Pinyins[0];
                sb.Append(s.Substring(0,s.Length-1));
	        }
            return sb.ToString();
        }
    }
}
