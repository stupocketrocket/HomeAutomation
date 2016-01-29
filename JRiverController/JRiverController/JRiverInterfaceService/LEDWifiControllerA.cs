using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;
using System.Net;
using System.Net.Sockets;

/* Wifi controller connected to the summer house */

namespace JRiverInterfaceService
{
    class LEDWifiControllerA : LEDWifiControllersInterface
    {
        const string m_strServerAddress = "192.168.0.50";
        const int m_iPortAddress = 5000;

        const string m_strLEDWifiControllerID = "HF-A11ASSISTHREAD";
        const string m_strBroadcastAddress = "192.168.0.255";
        const int m_iBroadcastPort = 48899;

        private LEDWifiControllerProtocolA m_wifiControllerProtocolA = new LEDWifiControllerProtocolA();

        public LEDWifiControllerA()
        {
            //Thread udpMessageThread = new Thread(GetLEDWifiControllers);
            //udpMessageThread.Start();
        }

        public void TurnOnLights(bool bOn)
        {
            if (bOn)
                m_wifiControllerProtocolA.TurnOn();
            else
                m_wifiControllerProtocolA.TurnOff();

            SendProtocolMessage();
        }


        public void SetRGBStaticColor(byte byRed, byte byGreen, byte byBlue)
        {
            m_wifiControllerProtocolA.SetRGBStaticColor(byRed, byGreen, byBlue);
            SendProtocolMessage();
        }

        public void SetBuiltInDisplayMode(byte bySpeed, byte byPause, byte byProgram, byte byEffect)
        {
            m_wifiControllerProtocolA.SetBuiltInDisplayMode(bySpeed, byPause, byProgram, byEffect);
            SendProtocolMessage();
        }

        private void SendProtocolMessage()
        {
            byte[] packetToSend = m_wifiControllerProtocolA.GetControlPacket();

            TcpMessage ledMessage = new TcpMessage(m_strServerAddress, m_iPortAddress, packetToSend);

            Thread tcpMessageThread = new Thread(ledMessage.SendMessage);
            tcpMessageThread.Start();
        }

        public void GetLEDWifiControllers()
        {
            IPEndPoint receivingGrp = new IPEndPoint(IPAddress.Any, m_iBroadcastPort);
            IPEndPoint sendingGrp = new IPEndPoint(IPAddress.Parse(m_strBroadcastAddress), m_iBroadcastPort);

            UdpClient udpSend = new UdpClient(sendingGrp);
            udpSend.EnableBroadcast = true;
            byte[] sendBytes = Encoding.ASCII.GetBytes(m_strLEDWifiControllerID);
            udpSend.Send(sendBytes, sendBytes.Length);
            udpSend.Close();

            UdpClient udpReceive = new UdpClient(receivingGrp);
            udpReceive.EnableBroadcast = true;
            udpReceive.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 5000);

            bool bTimedOut = true;

            while (bTimedOut)
            {
                try
                {
                    byte[] receiveBuff = udpReceive.Receive(ref receivingGrp);
                    Console.WriteLine("Data Received");
                    bTimedOut = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("TimedOut - " + ex.Message);
                }
            }
        }
    }
}
