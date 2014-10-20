using System;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace User增删改_版本3_
{
    /// <summary>
    /// 用户登录窗体
    /// </summary>
	public partial class FormLogin : Form
	{
        /// <summary>
        /// 初始化 <see cref="T:User增删改_版本3_.FormLogin"/> 类的新实例。
        /// </summary>
		public FormLogin()
		{
			InitializeComponent();
            btnLogin.Click += btnLogin_Click;
            btnCancel.Click += btnCancel_Click;
		}

        /// <summary>
        /// 取消登录操作
        /// </summary>
        /// <param name="sender">btnCancel</param>
        /// <param name="e"></param>
        void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// 登录操作
        /// </summary>
        /// <param name="sender">btnLogin</param>
        /// <param name="e"></param>
        void btnLogin_Click(object sender, EventArgs e)
        {
            //获取用户名和密码
            var name = txtName.Text.Trim();
            var pwd = txtPwd.Text;


            //验证
            //1 xml读取
            var xmlUser = XDocument.Load("UserData.xml");
            var rootElement = xmlUser.Root;

            //2 获取name对应的user节点（重复的验证放在编辑中做，此处只获取First）
            if (rootElement == null) return;

            //3 用户名是否存在
            var userElement = rootElement.Descendants("name").Single(c => c.Value == name).Parent;
            if (userElement == null)
            {
                MessageBox.Show(@"您输入的用户名不存在，请重新输入，亲...");
                return;
            }

            //4 密码验证
            if (userElement.Element("password").Value != pwd)
            {
                MessageBox.Show(@"密码输入错误，请重新输入，亲...");
                return;
            }

            DialogResult = DialogResult.OK;
        }  
	
	}
}