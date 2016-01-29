using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/* Implement protocol for WIFI Controller located in the Summer House */


namespace JRiverInterfaceService
{
    class LEDWifiControllerProtocolA : LEDWifiControllerProtocolInterface
    {
        private const int m_maxPacketSize = 20;
        private byte[] m_controllerPacket = new byte[m_maxPacketSize];

        // On / off commands
        private static byte[] m_onOffCommandHeader = new byte[] {0x9D, 0x62, 0x0D, 0x00, 0x00, 0x00, 0x60, 0xF0, 0x70, 0x00, 0x00, 0x00, 0x00, 0x50, 0xF0, 0x40};
        private static byte[] m_onCommand = new byte[] {0x10, 0x10, 0x10, 0x0B};
        private static byte[] m_offCommand = new byte[] {0x00, 0x10, 0x10, 0x0A};

        // RGB Static Color Commands
        private static byte[] m_RGBStaticCommandHeader = new byte[] {0x9D, 0x62, 0x06, 0x00, 0x00, 0x00, 0x60};
        private static byte[] m_RGBStaticCommandEnd = new byte[] {0x00, 0x00, 0xF0, 0x00, 0x00, 0x40, 0x10, 0x10, 0x10, 0x06};

        // Predefined modes / effects
        private static byte[] m_RGBModesCommandHeader = new byte[] {0x9D, 0x62, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00};
        private static byte[] m_RGBModesCommandEnd = new byte[] {0x00, 0x00, 0x10, 0x20, 0x10, 0x02};


        public LEDWifiControllerProtocolA()
        {
        }

        public byte[] GetControlPacket()
        {
            return m_controllerPacket;
        }

        public bool TurnOn()
        {
            System.Buffer.BlockCopy(m_onOffCommandHeader, 0, m_controllerPacket, 0, m_onOffCommandHeader.Length);
            System.Buffer.BlockCopy(m_onCommand, 0, m_controllerPacket, m_onOffCommandHeader.Length, m_onCommand.Length);
            return true;
        }

        public bool TurnOff()
        {
            System.Buffer.BlockCopy(m_onOffCommandHeader, 0, m_controllerPacket, 0, m_onOffCommandHeader.Length);
            System.Buffer.BlockCopy(m_offCommand, 0, m_controllerPacket, m_onOffCommandHeader.Length, m_offCommand.Length);
            return true;
        }

        public bool SetRGBStaticColor(byte byRed, byte byGreen, byte byBlue)
        {
            byte[] byRGB = new byte[] {byRed, byGreen, byBlue};

            System.Buffer.BlockCopy(m_RGBStaticCommandHeader, 0, m_controllerPacket, 0, m_RGBStaticCommandHeader.Length);
            System.Buffer.BlockCopy(byRGB, 0, m_controllerPacket, m_RGBStaticCommandHeader.Length, byRGB.Length);
            System.Buffer.BlockCopy(m_RGBStaticCommandEnd, 0, m_controllerPacket, m_RGBStaticCommandHeader.Length + byRGB.Length, m_RGBStaticCommandEnd.Length);
            return true;
        }

        public bool SetBuiltInDisplayMode(byte bySpeed, byte byPause, byte byProgram, byte byEffect)
        {
            byte[] bySpeedPauseProgramEffect = new byte[] {bySpeed, byPause, byProgram, byEffect};

            System.Buffer.BlockCopy(m_RGBModesCommandHeader, 0, m_controllerPacket, 0, m_RGBModesCommandHeader.Length);
            System.Buffer.BlockCopy(bySpeedPauseProgramEffect, 0, m_controllerPacket, m_RGBModesCommandHeader.Length, bySpeedPauseProgramEffect.Length);
            System.Buffer.BlockCopy(m_RGBModesCommandEnd, 0, m_controllerPacket, m_RGBStaticCommandHeader.Length + bySpeedPauseProgramEffect.Length, m_RGBModesCommandEnd.Length);
            return true;
        }
    }
}
