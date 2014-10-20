using System;
using System.Windows.Forms;

namespace 对xml用winform进行增删改查
{
	internal static class Program
	{
		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			//登录验证
			var formLogin = new FormLogin();
			var dialogResult = formLogin.ShowDialog();
			if (dialogResult != DialogResult.OK) return;
			var formUserList = new FormUserList();
			Application.Run(formUserList);
		}
	}
}