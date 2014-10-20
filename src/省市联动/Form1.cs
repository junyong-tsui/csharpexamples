using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using 省市联动.Model;
using 省市联动.Bll;

namespace 省市联动
{
    public partial class Form1 : Form
    {
       
        int rootId = 0;

        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
        }

        void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                LoadData();  
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }             
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null) return;           
            DeleteNodeRecursive((int)treeView1.SelectedNode.Tag);
            treeView1.SelectedNode.Remove();
        }

        #region 加载数据 层次遍历

        void LoadData()
        {
            List<TblArea> subAreas = (new TblAreaBll()).GetAreaById(0);
            foreach (var area in subAreas)
            {
                TreeNode node = new TreeNode(area.AreaName);
                node.Tag = area.AreaId;
                treeView1.Nodes.Add(node);
                LoadData(node,area.AreaId);
            }            
        }

        void LoadData(TreeNode parentNode, int parentId)
        {
            List<TblArea> subAreas = (new TblAreaBll()).GetAreaById(parentId);
            foreach (var area in subAreas)
            {
                TreeNode node = new TreeNode(area.AreaName);
                node.Tag = area.AreaId;
                parentNode.Nodes.Add(node);
                LoadData(node, area.AreaId);
            }           
        }           
        
        #endregion    

        #region 递归删除数据 这个层次遍历(树的前序遍历)

        void DeleteNode(int areaId)
        {
            ////1移除自己
            //string sql =string.Format("delete FROM TblArea WHERE AreaId={0}",areaId);
            //SqlHelper.ExcuteNonQuery(con, CommandType.Text, sql);
        
            ////2移除子
            //sql = string.Format("SELECT AreaId FROM TblArea WHERE AreaPId={0}",areaId);;
            //var table = SqlHelper.ExcuteDataTable(con, CommandType.Text, sql);
            //for (int i = 0; i < table.Rows.Count; i++)
            //{
            //    DeleteNode((int)table.Rows[i][0]);
            //}
        }

        #endregion

        #region 递归删除数据2 深度遍历(树的后续遍历？)

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pid"></param>
        void DeleteNodeRecursive(int pid)
        {
            //1删除当前节点的子            
             List<TblArea> subAreas = (new TblAreaBll()).GetAreaById(pid);

            foreach (var area in subAreas)
	        {
                 DeleteNodeRecursive(area.AreaId);		 
	        }
         
            (new TblAreaBll()).DeleteAreaById(pid);
        }


        #endregion
    }
}
