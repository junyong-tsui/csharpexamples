using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace User增删改_版本3_
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        
            //登录
            FormLogin frmLogin=new FormLogin();
            if (frmLogin.ShowDialog()==DialogResult.Cancel)return;
            
            //进入主界面
            Application.Run(new FormUserList());
        }
    }
}
