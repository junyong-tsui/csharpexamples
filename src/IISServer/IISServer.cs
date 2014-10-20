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

namespace IISServer
{
    public partial class IISServer : Form
    {
        public IISServer()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //1创建socket对象
            Socket socket = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);           

            var ip=  Dns.GetHostAddresses(Dns.GetHostName()).SingleOrDefault(ipAddress =>
                ipAddress.AddressFamily == AddressFamily.InterNetwork); 

            socket.Bind(new IPEndPoint(ip, Convert.ToInt32(txtPort.Text)));

            //2开启侦听：侦听浏览器发来的连接请求
            socket.Listen(10);

            //3处理浏览器的连接请求 由于浏览器请求无状态，所以请求完了就关闭连接
            ThreadPool.QueueUserWorkItem((obj) =>
            {
                //保存浏览器发来的请求报文
                byte[] msg = new byte[1024 * 1024];

                while (true)
                {
                    //给浏览器的连接请求指派代理套接字和其通信
                    var proxySocket = socket.Accept();

                    //获取浏览器的请求报文
                    int realLength = proxySocket.Receive(msg, SocketFlags.None);
                    string requestContext = Encoding.UTF8.GetString(msg, 0, realLength);

                    //根据请求报文创建http请求的上下文
                    HttpContext context = new HttpContext(requestContext);

                    //处理当前http请求
                    HttpApplication application = new HttpApplication();
                    application.ProcessRequest(context);

                    //返回请求的结果
                    proxySocket.Send(context.HttpResponse.Header);
                    proxySocket.Send(context.HttpResponse.Body);

                    //关掉当前连接
                    proxySocket.Shutdown(SocketShutdown.Both);
                    proxySocket.Close();
                }

            }, null);
        }
    }
}
