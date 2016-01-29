using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace JRiverInterfaceService
{
    class LEDWifiControllerB : LEDWifiControllersInterface
    {
        const string m_strServerAddress = "192.168.0.58";
        const int m_iPortAddress = 1112;

        const string m_strLEDWifiControllerID = "HF-A11ASSISTHREAD";
        const string m_strBroadcastAddress = "192.168.0.255";
        const int m_iBroadcastPort = 48899;
        private LEDWifiControllerProtocolB m_wifiControllerProtocolB = new LEDWifiControllerProtocolB();

        public void TurnOnLights(bool bOn)
        {
            if (bOn)
                m_wifiControllerProtocolB.TurnOn();
            else
                m_wifiControllerProtocolB.TurnOff();

            SendProtocolMessage();
        }


        public void SetRGBStaticColor(byte byRed, byte byGreen, byte byBlue)
        {
            m_wifiControllerProtocolB.SetRGBStaticColor(byRed, byGreen, byBlue);
            SendProtocolMessage();
        }

        public void SetBuiltInDisplayMode(byte bySpeed, byte byPause, byte byProgram, byte byEffect)
        {
            m_wifiControllerProtocolB.SetBuiltInDisplayMode(bySpeed, byPause, byProgram, byEffect);
            SendProtocolMessage();
        }

        private void SendProtocolMessage()
        {
            byte[] packetToSend = m_wifiControllerProtocolB.GetControlPacket();

            TcpMessage ledMessage = new TcpMessage(m_strServerAddress, m_iPortAddress, packetToSend);

            Thread tcpMessageThread = new Thread(ledMessage.SendMessage);
            tcpMessageThread.Start();
        }

    }
}
