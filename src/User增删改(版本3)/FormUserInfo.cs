using System;
using System.Windows.Forms;

namespace User增删改_版本3_
{
    /// <summary>
    /// 用户注册的界面
    /// </summary>
	public partial class FormRegister : Form
	{
        public User UserInfo { get; set; }   

		/// <summary>
		/// 无参构造函数
		/// </summary>
		public FormRegister()
		{
			InitializeComponent();
		}   

        /// <summary>
		/// 有参构造函数
		/// </summary>
		/// <param name="id"></param>
		/// <param name="name"></param>
		/// <param name="pwd"></param>
		public FormRegister(string id, string name, string pwd)
			: this()
		{
			txtId.Text = id;
			txtName.Text = name;
			txtPwd.Text = pwd;
		}

		/// <summary>
		/// 保存按钮方法
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnSaveClick(object sender, EventArgs e)
		{
			var id = txtId.Text.Trim();
			var name = txtName.Text.Trim();
			var pwd = txtPwd.Text.Trim();

			if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(pwd))
			{
				MessageBox.Show(@"用户编号，姓名和密码都不能为空！");
				return;
			}

			UserInfo = new User{Id = id, Name = name, Password = pwd};
			
            DialogResult = DialogResult.OK;
		}
	}
}