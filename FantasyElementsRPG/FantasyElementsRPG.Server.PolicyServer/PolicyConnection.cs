﻿using FantasyElementsRPG.Server.PolicyServer.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FantasyElementsRPG.Server.PolicyServer
{
    class PolicyConnection
    {
        private Socket m_connection;
        // buffer to receive the request from the client 
        private byte[] m_buffer;
        private int m_received;
        // the policy to return to the client 
        private byte[] m_policy;
        // the request that we're expecting from the client 
        private static string s_policyRequestString = "<policy-file-request/>";
        public PolicyConnection(Socket client, byte[] policy)
        {
            m_connection = client;
            m_policy = policy;
            m_buffer = new byte[s_policyRequestString.Length];
            m_received = 0;
            try
            {
                // receive the request from the client 
                m_connection.BeginReceive(m_buffer, 0, s_policyRequestString.Length, SocketFlags.None, new AsyncCallback(OnReceive), null);
            }
            catch (SocketException e)
            {
                PolicyServerLogger.PolicyServerLog.CreateErrorLog();
                PolicyServerLogger.PolicyServerLog.WriteErrorLog(this.GetType().Name, e.Message);
                m_connection.Close();
            }
        }
        // Called when we receive data from the client 
        private void OnReceive(IAsyncResult res)
        {
            try
            {
                m_received += m_connection.EndReceive(res);
                // if we haven't gotten enough for a full request yet, receive again 
                if (m_received < s_policyRequestString.Length)
                {
                    m_connection.BeginReceive(m_buffer, m_received, s_policyRequestString.Length - m_received, SocketFlags.None, new AsyncCallback(OnReceive), null);
                    return;
                }
                // make sure the request is valid 
                string request = System.Text.Encoding.UTF8.GetString(m_buffer, 0, m_received);
                if (StringComparer.InvariantCultureIgnoreCase.Compare(request, s_policyRequestString) != 0)
                {
                    m_connection.Close();
                    return;
                }
                // send the policy 
                m_connection.BeginSend(m_policy, 0, m_policy.Length, SocketFlags.None, new AsyncCallback(OnSend), null);
            }
            catch (SocketException e)
            {
                PolicyServerLogger.PolicyServerLog.CreateErrorLog();
                PolicyServerLogger.PolicyServerLog.WriteErrorLog(this.GetType().Name, e.Message);
                m_connection.Close();
            }
        }
        // called after sending the policy to the client; close the connection. 
        public void OnSend(IAsyncResult res)
        {
            try
            {
                m_connection.EndSend(res);
                IPEndPoint temp = m_connection.RemoteEndPoint as IPEndPoint;
                PolicyServerLogger.PolicyServerLog.WriteLog(this.GetType().Name, "Sent XML Policy to: " + temp.Address + " at port:" + temp.Port);
            }
            finally
            {
                m_connection.Close();
            }
        }
    }
}
