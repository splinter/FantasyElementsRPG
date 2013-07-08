using System;
using System.Net;
using System.Net.Sockets;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace FantasyElements.Client.Core.SocketFactory
{
    public class WebSocketClient : ISocketClient
    {
        Socket wSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        SocketAsyncEventArgs args = new SocketAsyncEventArgs() 
        {
            RemoteEndPoint = new DnsEndPoint("localhost",4502)
        };

        public WebSocketClient()
        {
            args.Completed+=OnConnected;

            buffer = new byte[GetBytes("happy").Length];

        }

        private void OnConnected(object sender, SocketAsyncEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.SocketError == SocketError.Success)
            {
                BeginRead();

                SocketAsyncEventArgs args = new SocketAsyncEventArgs();
                args.SetBuffer(GetBytes("happy"), 0, GetBytes("happy").Length);

                wSocket.SendAsync(args);
            }
        }

        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        public string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            string str = new string(chars);
            return str;
        }

        byte[] buffer;
        int bytesRec=0;

        void BeginRead()
        {
            SocketAsyncEventArgs args = new SocketAsyncEventArgs();
            args.SetBuffer(buffer, bytesRec, buffer.Length - bytesRec);

            args.Completed += args_OnReceived;

            wSocket.ReceiveAsync(args);
        }

        private void args_OnReceived(object sender, SocketAsyncEventArgs e)
        {
            this.bytesRec += e.BytesTransferred;

            if (this.bytesRec == buffer.Length)
            {
                bytesRec = 0;
                Console.WriteLine(Convert.ToBase64String(buffer));
            }
            BeginRead();
            //throw new NotImplementedException();
        }

        #region ISocketClient Members

        public void Connect()
        {
            //throw new NotImplementedException();
            //wSocket.Open();
            
            wSocket.ConnectAsync(args);
        }

        #endregion
    }
}
