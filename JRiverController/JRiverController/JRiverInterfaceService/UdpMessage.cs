using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace JRiverInterfaceService
{
    class UdpMessage
    {
        private string m_strServerAddress;
        private int m_iServerPort;
        private byte[] m_byData;

        public UdpMessage(string strServerAddress, int iServerPort, byte[] byData)
        {
            m_strServerAddress = strServerAddress;
            m_iServerPort = iServerPort;
            m_byData = byData;
        }

        public void SendMessage()
        {
            IPEndPoint RemoteEndPoint = new IPEndPoint(IPAddress.Parse(m_strServerAddress), m_iServerPort);
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            client.SendTo(m_byData, m_byData.Length, SocketFlags.None, RemoteEndPoint);
        }
    }
}
