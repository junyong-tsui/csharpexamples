using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P2PDemo
{
    /// <summary>
    /// P2P通信主窗体
    /// </summary>
    public partial class P2PMainFrom : Form
    {
        #region Field       
       
        /// <summary>
        /// 局域网的所有用户
        /// </summary>
        List<User> localUsers = new List<User>();

        /// <summary>
        /// 服务端的套接字
        /// </summary>
        Socket serverSocket;

        /// <summary>
        /// 服务端的端口号
        /// </summary>
        int serverPort = 55555;
       

        #endregion

        #region Construcor

        public P2PMainFrom()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            this.Load += Form1_Load;          
            this.listUsers.MouseDoubleClick += listUsers_MouseDoubleClick;
            this.notifyIcon1.MouseDoubleClick += notifyIcon1_MouseDoubleClick;
            this.notifyIcon1.Text = "P2p GZR 我的软件";
        }

        void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }      

        #endregion       

        #region Load the User in Local Network

        /// <summary>
        /// 加载局域网数据并开始处理会话请求
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Form1_Load(object sender, EventArgs e)
        {
            //1加载个人信息
            txtIndividualMsg.Text = Dns.GetHostName();

            //2加载局域网的用户
            try
            {
                LoadLocalUsers();
            }
            catch 
            {
                
                
            }
            
            this.listUsers.Items.AddRange(localUsers.ToArray());
            
            //3处理连接请求
            StartProcessRequest();
        }

        /// <summary>
        /// 获取Active Directory中的计算机节点
        /// </summary>
        private void LoadLocalUsers()
        {
            using (DirectoryEntry root = new DirectoryEntry("WinNT:"))
            {
                foreach (DirectoryEntry domain in root.Children)
                {
                    foreach (DirectoryEntry computer in domain.Children)
                    {
                        if (computer.Name == "Schema")
                        {
                            continue;
                        }

                        try
                        {
                            User user = new User();
                            user.IP = Dns.GetHostEntry(computer.Name).AddressList[0].ToString();
                            user.UserHostName = computer.Name;
                            user.LoginState = State.OnLine;
                            localUsers.Add(user);
                        }
                        catch
                        {

                        }
                    }
                }
            }
        }

        #endregion

        #region To Be a Client        
        
        /// <summary>
        /// 开启和选中项的通话
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void listUsers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listUsers.SelectedItem == null) return;
            var user = listUsers.SelectedItem as User;
            Socket socket=new Socket(AddressFamily.InterNetworkV6,SocketType.Stream,ProtocolType.Tcp);            
            try
            {
                socket.Connect(new IPEndPoint(IPAddress.Parse(user.IP), serverPort));
                CommunicationFrm clientFrm = new CommunicationFrm(socket);
                clientFrm.Text = "客户端:" + socket.ToString();
                clientFrm.Show();
            }
            catch (Exception err)
            {
                MessageBox.Show("服务器未启动:"+err.Message);
            }           
        }

        #endregion

        #region To Be a Server

        /// <summary>
        /// 开始处理回话请求
        /// </summary>
        private void StartProcessRequest()
        {
            //服务端套字创建
            serverSocket = new Socket(AddressFamily.InterNetworkV6, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ip = Dns.GetHostAddresses(Dns.GetHostName()).FirstOrDefault(); 
            serverSocket.Bind(new IPEndPoint(ip, serverPort));

            //开启侦听
            serverSocket.Listen(10);


            //处理请求
            ThreadPool.QueueUserWorkItem((obj) =>
            {

                while (true)
                {
                    //1处理连接请求获取代理套接字
                    var proxySocket = serverSocket.Accept();

                    //2创建与客户端通信的窗体
                    CommunicationFrm proxyServerFrm = new CommunicationFrm(proxySocket);
                    proxyServerFrm.Text = "服务端:"+proxySocket.ToString();
                    Application.Run(proxyServerFrm);
                  
                    //这个地方用proxyServerFrm.ShowDialog()也可以，本质和上面区别不大                    
                }

            }, null);
        }       

        #endregion       
        
    }
}
