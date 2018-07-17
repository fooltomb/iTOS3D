using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace iTOS3D.NET
{
    public class Server
    {
#region Members
        private IPEndPoint _ipEndpoint;
        private Socket _serverSocket;
        private Socket _u3dSocket;
        private byte[] msg;
#endregion      
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ipAddress">ip地址</param>
        /// <param name="port">端口号</param>
        public Server(string ipAddress,int port)
        {
            _ipEndpoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);
            msg = new byte[1024];
        }
#region Mathed
        public void Start()
        {
            _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _serverSocket.Bind(_ipEndpoint);
            _serverSocket.Listen(1);
            _serverSocket.BeginAccept(AcceptCallBack, null);
        }
        private void AcceptCallBack(IAsyncResult ar)
        {
            _u3dSocket = _serverSocket.EndAccept(ar);
            _u3dSocket.BeginReceive(msg, 0, msg.Length, SocketFlags.None, ReceiveCallBack, null);
        }
        //处理接收的数据
        private void ReceiveCallBack(IAsyncResult ar)
        {
            try
            {
                int count = _u3dSocket.EndReceive(ar);
                if(count==0)
                {
                    Close();
                }
                else
                {
                    //TODO
                }
                _u3dSocket.BeginReceive(msg, 0, msg.Length, SocketFlags.None, ReceiveCallBack, null);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
                Close();
            }
        }
        public void SendMessage(byte[] msg)
        {
            if (_u3dSocket != null && _u3dSocket.Connected)
                _u3dSocket.Send(msg);
        }
        public void Close()
        {
            if (_u3dSocket != null)
                _u3dSocket.Close();
            if (_serverSocket != null)
                _serverSocket.Close();
        }
#endregion
    }
}
