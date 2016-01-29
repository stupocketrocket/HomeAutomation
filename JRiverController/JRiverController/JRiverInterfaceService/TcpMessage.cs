using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.Net.Sockets;

namespace JRiverInterfaceService
{
    class TcpMessage
    {
        private string m_strServerAddress;
        private int m_iServerPort;
        private byte[] m_byData;

        public TcpMessage(string strServerAddress, int iServerPort, byte[] byData)
        {
            m_strServerAddress = strServerAddress;
            m_iServerPort = iServerPort;
            m_byData = byData;
        }

        public void SendMessage()
        {
            TcpClient tcpClient = null;
            NetworkStream tcpDataStream = null;

            try
            {
                tcpClient = new TcpClient(m_strServerAddress, (int)m_iServerPort);
                tcpDataStream = tcpClient.GetStream();

                tcpDataStream.Write(m_byData, 0, m_byData.Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception raised - " + ex.Message);
            }
            finally
            {
                if (tcpDataStream != null)
                    tcpDataStream.Close();
                if (tcpClient != null)
                    tcpClient.Close();
            }
        }
    }
}
