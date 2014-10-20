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

namespace MD5注册登录
{
    public partial class FormLogin : Form
    {
       

        int ukey;

        public FormLogin()
        {
            InitializeComponent();
            this.btnLogin.Click += btnLogin_Click;
            this.btnChangePwd.Click += btnChangePwd_Click;
        }

        void btnChangePwd_Click(object sender, EventArgs e)
        {
            var frm = new FormChangePwd();
        
            if (frm.ShowDialog() != DialogResult.OK) return;

            string sql = "UPDATE T_Seats SET CC_LoginPassword=@password WHERE T_Seats.CC_AutoId=@autoId";

            SqlHelper.ExcuteNonQuery(conn, CommandType.Text,sql, new SqlParameter("@password",Md5Helper.GetMd5FromString(frm.NewPassword)), new SqlParameter("@autoId", ukey));

            MessageBox.Show("修改成功");


        }

        void btnLogin_Click(object sender, EventArgs e)
        {
            //1收集用户密码
            ukey = Convert.ToInt32(txtName.Text.Trim());
            string pwd = txtPwd.Text;

            //2查询用户

            switch (flag)
            {
                case 1:                   
                    MessageBox.Show("登陆成功");
                    this.btnChangePwd.Enabled = true;
                    break;
                case 0:
                    MessageBox.Show("密码错误");
                    break;
                case -1:
                    MessageBox.Show("用户不存在");
                    break;
            }
           
        }
    }
}
