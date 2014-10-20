using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MD5注册登录
{
    public partial class FormChangePwd : Form
    {
        public string NewPassword
        {
            get;
            set;
        }

        public FormChangePwd()
        {
            InitializeComponent();
            this.btnOk.Click += btnOk_Click;
            this.btnCancel.Click += btnCancel_Click;
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        void btnOk_Click(object sender, EventArgs e)
        {
            NewPassword = txtPwd.Text;
            DialogResult = DialogResult.OK;
        }
    }
}
