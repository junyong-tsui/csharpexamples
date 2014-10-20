using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace QQXMl增改
{
    /// <summary>
    /// QQ问题信息界面
    /// </summary>
    public partial class FormQQuetion : Form
    { 
        #region Field

        private const string QQXmlFileName = @"QQ.xml";      //QQ问题的配置文件名

        private ContextMenuStrip _contextMenuStrip;          //树的右键菜单

        private XDocument _xDocument;                        //配置文件对应的文档对象
        
        #endregion  
        #region Ctor

        public FormQQuetion()
        {
            InitializeComponent();
            Closing += FormQQuetion_Closing;
            Load += FormQQQuestion_Load;
            tvQQQustion.AfterSelect += tvQQQustion_AfterSelect;
            tbTitle.Enabled = false;
            tbContent.Enabled = false;
            rbIsSolve.Enabled = false;
        }    

        
        #endregion    
        #region EventHandle 
 
        /// <summary>
        /// 加载树节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void FormQQQuestion_Load(object sender, EventArgs e)
        {
            try
            {
                #region 加载树的右键菜单

                _contextMenuStrip = new ContextMenuStrip();

                ToolStripItem addItem = _contextMenuStrip.Items.Add("新增");
                addItem.Name = "toolAdd";

                ToolStripItem modifyItem = _contextMenuStrip.Items.Add("修改");
                modifyItem.Name = "toolModify";

                ToolStripItem delItem = _contextMenuStrip.Items.Add("删除");
                delItem.Name = "toolDel";

                _contextMenuStrip.ItemClicked += _contextMenuStrip_ItemClicked;
                _contextMenuStrip.Opening += _contextMenuStrip_Opening;

                tvQQQustion.ContextMenuStrip = _contextMenuStrip;

                #endregion

                #region 加载树数据

                _xDocument = XDocument.Load(QQXmlFileName);
                if (_xDocument.Root == null) return;

                var rootNode = tvQQQustion.Nodes.Add(_xDocument.Root.Name.ToString());
                rootNode.Tag = _xDocument.Root;


                foreach (XElement dateElement in _xDocument.Descendants("Date"))
                {
                    var dateNode = rootNode.Nodes.Add(dateElement.FirstAttribute.Value);
                    dateNode.Tag = dateElement;

                    foreach (XElement titleElement in dateElement.Descendants("title"))
                    {
                        var titleNode = dateNode.Nodes.Add(titleElement.Value);

                        if (titleElement.Parent == null ||
                            !titleElement.Parent.Name.ToString().Equals("Q")) continue;

                        titleNode.Tag = titleElement.Parent;

                        if (Convert.ToBoolean(titleElement.Parent.FirstAttribute.Value))
                        {
                            titleNode.BackColor = Color.Green;
                        }
                    }
                }

                tvQQQustion.ExpandAll();

                #endregion
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }    
        }

        /// <summary>
        /// 右键菜单打开前设置菜单的可用性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                if (tvQQQustion.SelectedNode.Level == 2)
                {
                    var qElement = tvQQQustion.SelectedNode.Tag as XElement;
                    bool isOk = qElement != null && Convert.ToBoolean(qElement.FirstAttribute.Value);
                    _contextMenuStrip.Items["toolAdd"].Enabled = false;
                    _contextMenuStrip.Items["toolModify"].Enabled = !isOk;
                    _contextMenuStrip.Items["toolDel"].Enabled = isOk;
                }
                else if (tvQQQustion.SelectedNode.Level == 1)
                {
                    _contextMenuStrip.Items["toolAdd"].Enabled = true;
                    _contextMenuStrip.Items["toolDel"].Enabled = true;
                    _contextMenuStrip.Items["toolModify"].Enabled = false;
                }
                else if (tvQQQustion.SelectedNode.Level == 0)
                {
                    _contextMenuStrip.Items["toolAdd"].Enabled = true;
                    _contextMenuStrip.Items["toolModify"].Enabled = false;
                    _contextMenuStrip.Items["toolDel"].Enabled = false;
                }
            }
            catch (Exception err)
            {  
                MessageBox.Show(err.Message);
            } 
        }

        /// <summary>
        /// 右键菜单操作 增删改节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _contextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                switch (e.ClickedItem.Name)
                {
                    case "toolAdd":
                        AddNode();
                        break;
                    case "toolModify":
                        ModifyNode();
                        break;
                    case "toolDel":
                        DelNode();
                        break;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        /// <summary>
        /// 节点选中后显示节点的信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tvQQQustion_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                var node = e.Node;
                XElement qElement = node.Tag as XElement;
                if (qElement == null || !qElement.Name.ToString().Equals("Q")) return;

                tbTitle.Text = e.Node.Text;

                var descElement = qElement.Element("desc");
                if (descElement != null) tbContent.Text = descElement.Value;

                rbIsSolve.Checked = Convert.ToBoolean(qElement.FirstAttribute.Value);
            }
            catch (Exception err)
            {   
                MessageBox.Show(err.Message);
            }
           
        }

        /// <summary>
        /// 窗体关闭的时候 存储信息之xml文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void FormQQuetion_Closing(object sender, CancelEventArgs e)
        {
            try
            {
                _xDocument.Save(QQXmlFileName);
            }
            catch (Exception err)
            {   
                MessageBox.Show(err.Message);
            }
           
        }   
        
        #endregion
        #region Private Method   
       
        /// <summary>
        /// 删除树节点
        /// </summary>
        private void DelNode()
        {
            if (tvQQQustion.SelectedNode.Level==0)return; 

            XElement dateElement = tvQQQustion.SelectedNode.Tag as XElement;

            if (dateElement != null) dateElement.Remove();  

            tvQQQustion.SelectedNode.Remove(); 
        }

        /// <summary>
        /// 修改树节点
        /// </summary>
        private void ModifyNode()
        {
            if (tvQQQustion.SelectedNode.Level != 2) return;

            //1更新内存的Xdocment的对应的元素节点
            XElement qElement = tvQQQustion.SelectedNode.Tag as XElement;  
            if (qElement == null || !qElement.Name.ToString().Equals("Q")) return;
      
            var frm = new FormQuestionInfo(tbTitle.Text, tbContent.Text, rbIsSolve.Checked);    
            if (DialogResult.OK != frm.ShowDialog()) return;  

            qElement.FirstAttribute.Value = frm.IsOk;  

            var titleElement = qElement.Element("title");
            if (titleElement != null) titleElement.Value = frm.Title; 

            var descElement = qElement.Element("desc");
            if (descElement != null) descElement.Value = frm.Content;   

            //2更新节点的数据   
            tvQQQustion.SelectedNode.BackColor =Convert.ToBoolean(frm.IsOk) ? Color.Green : Color.White;

            //3节点显示的数据更新
            tbTitle.Text = frm.Title;
            tbContent.Text = frm.Content;
            rbIsSolve.Checked = Convert.ToBoolean(frm.IsOk);
        }

        /// <summary>
        /// 增加树节点
        /// </summary>
        private void AddNode()
        {
            if (tvQQQustion.SelectedNode.Level ==2) return;

            var element = tvQQQustion.SelectedNode.Tag as XElement;
           
            if (element == null) return;
          
            var frm = new FormQuestionInfo();

            if (DialogResult.OK != frm.ShowDialog()) return;

            if (tvQQQustion.SelectedNode.Level == 0)      //新增date节点
            {
                //1xml文档中加入节点          tvQQQustion.SelectedNode.Level ==0
                var newElement = new XElement("Date", 
                    new XAttribute("id", DateTime.Now.ToString("yyyyMMdd")),
                    new XElement("Q",
                        new XAttribute("isOk", frm.IsOk),
                        new XElement("title", frm.Title),
                        new XElement("desc", frm.Content
                            )
                        )
                    ); 
                element.Add(newElement); 

                //2增加树节点
                var dateNode = new TreeNode(newElement.FirstAttribute.Value) { Tag = newElement };
                tvQQQustion.SelectedNode.Nodes.Add(dateNode);

                var qElement = newElement.Element("Q");
                var qNode = new TreeNode(qElement.Descendants("title").First().Value) { Tag = qElement };
                dateNode.Nodes.Add(qNode);
                qNode.BackColor = Convert.ToBoolean(frm.IsOk) ? Color.Green : Color.White;

                //3选中新节点
                tvQQQustion.SelectedNode = qNode;
            }
            else  if(tvQQQustion.SelectedNode.Level ==1)     //新增问题节点
            {
                //1xml文档中加入节点
                var newElement = new XElement("Q",
                    new XAttribute("isOk", frm.IsOk),
                    new XElement("title", frm.Title),
                    new XElement("desc", frm.Content
                        )
                    );
                   
                element.Add(newElement);

                //2增加树节点
                var qNode = new TreeNode(newElement.Descendants("title").First().Value) { Tag = newElement };
                tvQQQustion.SelectedNode.Nodes.Add(qNode);
                qNode.BackColor = Convert.ToBoolean(frm.IsOk) ? Color.Green : Color.White;

                //3选中新节点
                tvQQQustion.SelectedNode = qNode;
            }
        }

        #endregion
    }
}
