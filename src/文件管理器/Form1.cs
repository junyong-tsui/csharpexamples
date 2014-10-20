using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace 文件管理器
{
    public partial class Form1 : Form
    {

        /// <summary>
        /// 文件根路径
        /// </summary>
        private static readonly string RootPath;

        /// <summary>
        /// 相对路径
        /// </summary>
        private const string RelativePath = @"资料";


        static  Form1()
        {
              RootPath= Path.Combine(Directory.GetCurrentDirectory(), RelativePath);

              //RootPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }


        public Form1()
        {
            InitializeComponent();

            Load += Form1_Load;

            treeView1.NodeMouseDoubleClick += treeView1_NodeMouseDoubleClick;
    

        }

        void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            if (treeView1.SelectedNode == null || treeView1.SelectedNode.Name == "目录") return;

            string content = File.ReadAllText(treeView1.SelectedNode.Tag.ToString(), Encoding.Default);
            textBox1.Text = content;
        }

        void Form1_Load(object sender, EventArgs e)
        {
            var rootNode = new TreeNode
            {
                Text = RelativePath,
                Tag = RootPath,
                BackColor = Color.Red,
            };

            treeView1.Nodes.Add(rootNode);
            LoadFilesAndDirectories(rootNode);
        }

        /// <summary>
        /// 递归加载文件与目录
        /// </summary>
        /// <param name="argNode"></param>
        private void LoadFilesAndDirectories(TreeNode argNode)
        {
            string[] files = Directory.GetFiles(argNode.Tag.ToString(),"*.txt");
            string[] directories = Directory.GetDirectories(argNode.Tag.ToString());

            //加载文件
            foreach (string file in files)
            {
                TreeNode node = new TreeNode
                {
                    Text = Path.GetFileNameWithoutExtension(file)??"NoName",
                    Tag = file,
                    Name = "文件"
                };

                argNode.Nodes.Add(node);
            }

            //加载目录
            foreach (string directoryPath in directories)
            {
                var node = new TreeNode
                {
                    Text = Path.GetFileName(directoryPath) ?? "NoName",
                    Tag = directoryPath,
                    BackColor = Color.BlueViolet,
                    Name = "目录"
                };

                argNode.Nodes.Add(node);

                LoadFilesAndDirectories(node);
            }
        }
    }
}

