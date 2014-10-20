using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketDemo
{
    /// <summary>
    /// 聊天程序服务端的主界面
    /// </summary>
    public partial class ServerFrm : Form
    {
        /// <summary>
        /// 客户端的请求套接字集合
        /// </summary>
        Dictionary<string, Socket> clientSockets = new Dictionary<string, Socket>();

        #region Constructor

        public ServerFrm()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;//掩耳盗铃法            
        }
        
        #endregion        

        /// <summary>
        /// 启动服务开始处理请求
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            //socket服务器端的逻辑

            //1、创建socket对象            
            //设置网络寻址协议。SocketType 数据传输方式  。ProtocolType 设置通信的协议
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //2、绑定Ip(取主机Ipv4的ip)和端口
            IPAddress ip =Dns.GetHostAddresses(Dns.GetHostName()).SingleOrDefault(ipAddress=>ipAddress.AddressFamily==AddressFamily.InterNetwork);
            IPEndPoint ipEndPoint = new IPEndPoint(ip, Convert.ToInt32(txtPort.Text));
            socket.Bind(ipEndPoint);

            //3开始侦听 设置请求队列存放连接请求个数最大为10 超过10则丢掉请求 这个时候侦听的连接请求开始向请求队列放
            socket.Listen(10);//超过队列的后续连接请求会被丢掉，客户端会收到一个refuse的消息

            //4 处理请求队列中的连接请求 处理的方式调用socket.Accept()方法
            //若accept方法放在主线程中，则一旦执行就会阻塞主线程，这样主线程无法和用户交互，
            //同时队列中的后续连接连接请求也无法处理。所以这里必须将处理客户的请求任务让其他线程完成，主程序可以继续和用户交互
            ThreadPool.QueueUserWorkItem(AcceptClient,socket);
        }

        /// <summary>
        /// 处理客户端的连接请求 
        /// </summary>
        /// <param name="obj"></param>
        private void AcceptClient(object obj)
        {
            /*-----------处理客户端请求的逻辑
             * ------01从请求队列中获取连接请求，然后创建处理该请求的代理套接字proxySocket =》侦听套接字.Accetp()完成01
             * ------02处理接收当前请求发送的消息问题
             * ----------proxySocket负责和客户端请求的套接字负责通信，那么通信的具体代码也应该写在另一个线程里面吗？
             *           --------答案是肯定得呀。
             *           -----03proxySocket.receive()肯定是放在循环里面，这样才能接收到客户端发送的数据，但是
             *           ---receive方法会阻塞处理当前线程，那么意味着当前线程无法处理队列中的后续请求了
             *----sum:执行此方法的线程只负责01从队列中获取请求并指派代理套接字和客户端通信，02指派子线程来完成代理套接字当前请求通信
             */

            var socket = (Socket)obj;
            while (true)
            {
                //创建代理套接字处理当前的请求 这个地方也可能发生异常应该try{}catch{}到
                var proxSocket = socket.Accept();

                //将和客户端通信的套接字放在集合中，便于发送消息的时候用于发送消息。
                clientSockets.Add(proxSocket.RemoteEndPoint.ToString(), proxSocket);

                //显示客户端到界面上
                this.listClients.Items.Add(proxSocket.RemoteEndPoint.ToString());

                //处理代理套接字接受客户端消息
                ThreadPool.QueueUserWorkItem(ReceiveMsg,proxSocket);
            }
        }

        /// <summary>
        /// 代理套接字和客户端通信
        /// </summary>
        /// <param name="obj"></param>
        private void ReceiveMsg(object obj)
        {
            var proxySocket = (Socket)obj;

            //接受客户端消息的缓冲区应该在外面创建，放在while里面那就是shit.
            byte[] msg = new byte[1024 * 1024];

            //客户端发送的数据长度
            int realLength;

            while (true)
            {

                try
                {
                    //1接受客户端的消息
                    realLength = proxySocket.Receive(msg, 0, msg.Length, SocketFlags.None);                   
                }
                catch
                {
                    //显示该用户异常退出
                    this.richTextMsg.Text = proxySocket.RemoteEndPoint.ToString() +
                        ":此用户异常退出" + Environment.NewLine+this.richTextMsg.Text;

                    //关闭此套接字
                    proxySocket.Shutdown(SocketShutdown.Both);
                    proxySocket.Close();

                    //让方法结束就是终结当前接受客户端数据的异步方式线程
                    return;
                }

                //2正常退出 
                if (realLength <= 0)
                {
                    //显示该用户正常退出
                    this.richTextMsg.Text = proxySocket.RemoteEndPoint.ToString() +
                        ":此用户正常退出" + Environment.NewLine + this.richTextMsg.Text;

                    //清空相应的数据
                    clientSockets.Remove(proxySocket.RemoteEndPoint.ToString());
                    listClients.Items.Remove(proxySocket.RemoteEndPoint.ToString());

                    //关闭此套接字
                    proxySocket.Shutdown(SocketShutdown.Both);
                    proxySocket.Close();

                    //让方法结束就是终结当前接受客户端数据的异步方式线程
                    return;
                }

                //3显示客户端的消息到主界面
                string decryptMsg = Encoding.Default.GetString(msg, 0, realLength);
                this.richTextMsg.Text = proxySocket.RemoteEndPoint.ToString() + ":"
                    + decryptMsg + Environment.NewLine + this.richTextMsg.Text;
            }
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            //01根据选择获取代理套接字
            if (listClients.SelectedItem==null)
            {
                MessageBox.Show("请选择发送的客户端");
                return;
            }
            string proxySocketKey=listClients.SelectedItem.ToString();
            if (!clientSockets.ContainsKey(proxySocketKey))return;
            var proxySocket = clientSockets[proxySocketKey];

            //02获取发送的消息
            string sendMsg = txtSendMsg.Text.Trim();
            byte[] encryptMsg = Encoding.Default.GetBytes(sendMsg);

            //03发送消息
            proxySocket.Send(encryptMsg);
        }
    }
}
