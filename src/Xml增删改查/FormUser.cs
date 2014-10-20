using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Xml增删改查
{
    public partial class FormUser : Form
    {
        #region Field

        private const string Filepath = "users.xml";

        private XDocument _xDocument;
        
        #endregion  
        #region Ctor   

        public FormUser()
        {
            InitializeComponent();

            Load += Form1_Load;
            btnAdd.Click += btnAdd_Click;
            btnDel.Click += btnDel_Click;
            btnEdit.Click += btnEdit_Click;
            btnLogin.Click += btnLogin_Click;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
        }
        
        #endregion  
        #region EventHandle

        void btnLogin_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text.Trim();
            string id = textBoxId.Text.Trim();

            bool result = _xDocument.Root != null &&
                         _xDocument.Root.Descendants("id").Any(element => element.Value == id)
                         && _xDocument.Root.Descendants("name").Any(element => element.Value == name);

            if (result)
            {
                MessageBox.Show(@"登录成功");
            }
            else
            {
                MessageBox.Show(@"登录失败");
            }


        }

        void btnEdit_Click(object sender, EventArgs e)
        {
            //1收集当前修改后的用户的信息
            string name = textBoxName.Text.Trim();
            string id = textBoxId.Text.Trim();
            string addr = textBoxAddr.Text.Trim();

            //2判断修改后的id是否和也有用户的id重复
            if (IsExsit(id))
            {
                MessageBox.Show(@"修改后和已有用户帐号重复");
            }

            //3修改xml文件中的内容
            //1xml文件中新增一行
            var curElement = _xDocument.Root.Descendants("id").
            SingleOrDefault(element => element.Value == dataGridView1.CurrentRow.Cells["id"].Value.ToString());

            if (curElement != null && curElement.Parent != null)
            {
                curElement.Parent.ReplaceWith(new XElement("user", new XElement("id", id), new XElement("name", name), new XElement("addr", addr)));
            }

            _xDocument.Save(Filepath);


            //4修改网格中的数据
            dataGridView1.CurrentRow.Cells["id"].Value = id;
            dataGridView1.CurrentRow.Cells["name"].Value = name;
            dataGridView1.CurrentRow.Cells["addr"].Value = addr;

        }

        void btnDel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            string id = dataGridView1.CurrentRow.Cells["id"].Value.ToString();

            //1文档中移除节点
            var curElement = _xDocument.Root.Descendants("id").Single(element => element.Value == id);  

            if (curElement != null && curElement.Parent != null)
            {
                curElement.Parent.Remove();  
            }     
            _xDocument.Save(Filepath);


            //2datagridview中移除行
            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);

        }

        void Form1_Load(object sender, EventArgs e)
        {
            _xDocument = XDocument.Load(Filepath);
            LoadData();
        }

        void btnAdd_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text.Trim();
            string id = textBoxId.Text.Trim();
            string addr = textBoxAddr.Text.Trim();

            if (IsExsit(id))
            {
                MessageBox.Show(@"用户已存在", @"Created by gzr", MessageBoxButtons.YesNo);
            }
            else
            {
                //1xml文件中新增一行
                var user = new XElement("user", new XElement("id", id),
                     new XElement("name", name), new XElement("addr", addr));
                _xDocument.Root.Add(user);
                _xDocument.Save(Filepath);

                //2网格数据源中新增一行
                DataTable table = (DataTable)dataGridView1.DataSource;
                var row = table.NewRow();
                row["id"] = id;
                row["name"] = name;
                row["addr"] = addr;
                table.Rows.Add(row);
            }

        }

        void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                textBoxId.Text = dataGridView1.CurrentRow.Cells["id"].Value.ToString();

                textBoxName.Text = dataGridView1.CurrentRow.Cells["name"].Value.ToString();

                textBoxAddr.Text = dataGridView1.CurrentRow.Cells["addr"].Value.ToString();
            }
        } 

        #endregion  
        #region Private

        private void LoadData()
        {

            DataTable table = new DataTable();
            table.Columns.Add("id", typeof(string));
            table.Columns.Add("name", typeof(string));
            table.Columns.Add("addr", typeof(string));


            foreach (XElement element in _xDocument.Root.Descendants("user"))
            {
                var row = table.NewRow();

                int i = 0;

                foreach (XElement valueElement in element.Elements())
                {
                    row[i++] = valueElement.Value;
                }

                table.Rows.Add(row);
            }



            dataGridView1.DataSource = table;
        }

        private bool IsExsit(string userId)
        {
            return _xDocument.Root != null && _xDocument.Root.Descendants("id").Any(element => element.Value == userId);
        }   
        
        #endregion    
    }
}
