using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace User增删改_版本3_
{
    public partial class FormUserList : Form
    {
        private List<User> _userList;

        private BindingSource bindingSource1 = new BindingSource();

        /// <summary>
        /// 无参构造函数
        /// </summary>
        public FormUserList()
        {
            InitializeComponent();
            Load += FormUserList_Load;
        }

        void FormUserList_Load(object sender, EventArgs e)
        {
            //1加载xml到List集合
            LoadXmlData();

            //2加载数据到网格
            bindingSource1.DataSource = _userList;
          
            listBoxUser.DataSource = bindingSource1;
            listBoxUser.DisplayMember = "Name";
            listBoxUser.ValueMember = "Id";
        }     

        /// <summary>
        /// 加载xml到List集合
        /// </summary>
        private void LoadXmlData()
        {
            //读取xml
            var xmlUsers = XDocument.Load("UserData.xml");
            var rootElement = xmlUsers.Root;
            //将xml讯息加载到list集合
            if (rootElement == null) return;
            _userList = rootElement.Descendants("user").Select(userElement => new User
            {
                Id = userElement.Attribute("id").Value,
                Name = userElement.Element("name").Value,
                Password = userElement.Element("password").Value
            }).ToList();
        }

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddClick(object sender, EventArgs e)
        {
            //1获取User对象
            var formUserInfo = new FormRegister();
            var dialogResult = formUserInfo.ShowDialog();
            if (dialogResult != DialogResult.OK) return;
            var userInfo = formUserInfo.UserInfo;
           
            //2验证数据
            if (_userList.Any(user => user.Id == userInfo.Id))
            {
                MessageBox.Show(@"新增失败，用户编号已经存在！");
                return;
            }

            if (_userList.Any(user => user.Name == userInfo.Name))
            {
                MessageBox.Show(@"新增失败，用户姓名已经存在！");
                return;
            }

            //3通过数据绑定组件同步界面和数据源
            bindingSource1.Add(userInfo);
        }

        /// <summary>
        /// 编辑用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEditClick(object sender, EventArgs e)
        {
            //1收集网格上旧的数据源  
            var curUser = _userList.Single(c => c.Id == listBoxUser.SelectedValue.ToString());      

            //2手机用户修改后的信息
            var formUserInfo = new FormRegister(curUser.Id, curUser.Name, curUser.Password);
            var dialogResult = formUserInfo.ShowDialog();
            if (dialogResult != DialogResult.OK) return;
           
            //3校验信息
            var user = _userList.Single(c => c.Id == curUser.Id);

            if (curUser.Id != formUserInfo.UserInfo.Id &&
                _userList.Any(c=>c.Id==formUserInfo.UserInfo.Id))
            {
                MessageBox.Show(@"用户编号已存在,请重新修改。");
                return;
            }


            //4保存信息
            user.Id = formUserInfo.UserInfo.Id;
            user.Name = formUserInfo.UserInfo.Name;
            user.Password = formUserInfo.UserInfo.Password;   
         
            bindingSource1.ResetCurrentItem();                  //通过数据源组件重设当前项
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
           bindingSource1.RemoveCurrent();
        }
    }
}