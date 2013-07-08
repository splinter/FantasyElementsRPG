using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FantasyElementsRPG.Server.PolicyServer
{
    class PolicyServer
    {
        private Socket m_listener;
        private byte[] m_policy;
        // pass in the path of an XML file containing the socket policy 
        public PolicyServer(string policyFile)
        {
            // Load the policy file 
            FileStream policyStream = new FileStream(policyFile, FileMode.Open);
            m_policy = new byte[policyStream.Length];
            policyStream.Read(m_policy, 0, m_policy.Length);
            policyStream.Close();
            Console.WriteLine(System.Text.Encoding.Default.GetString(m_policy));
            // Create the Listening Socket 
            m_listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // Put the socket into dual mode to allow a single socket 
            // to accept both IPv4 and IP connections 
            // Otherwise, server needs to listen on two sockets, 
            // one for IPv4 and one for IP 
            // NOTE: dual-mode sockets are supported on Vista and later 
            //m_listener.SetSocketOption(SocketOptionLevel.IP, (SocketOptionName)27, 0);
            m_listener.Bind(new IPEndPoint(IPAddress.Any, 943));
            m_listener.Listen(10);
            m_listener.BeginAccept(new AsyncCallback(OnConnection), null);
        }
        // Called when we receive a connection from a client 
        public void OnConnection(IAsyncResult res)
        {
            Socket client = null;
            try
            {
                client = m_listener.EndAccept(res);
            }
            catch (SocketException)
            {
                return;
            }
            // handle this policy request with a PolicyConnection 
            PolicyConnection pc = new PolicyConnection(client, m_policy);
            // look for more connections 
            m_listener.BeginAccept(new AsyncCallback(OnConnection), null);
        }
        public void Close()
        {
            m_listener.Close();
        }
    }
}
