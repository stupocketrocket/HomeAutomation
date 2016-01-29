using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JRiverInterfaceService
{
    class LEDWifiControllerProtocolB : LEDWifiControllerProtocolInterface
    {
        private const int m_maxPacketSize = 20;
        private byte[] m_controllerPacket = new byte[m_maxPacketSize];

        // On / off commands
        private static byte[] m_onCommand = new byte[] {0xCD, 0xFF};
        private static byte[] m_offCommand = new byte[] {0xD1, 0xFF};

        // RGB Static Color Commands
        private static byte[] m_RGBStaticCommandHeader = new byte[] {0xC9};
        private static byte[] m_RGBStaticCommandEnd = new byte[] {0xFF};

        // Predefined modes / effects
        private static byte[] m_RGBModesCommandHeader = new byte[] {0xCB};
        private static byte[] m_RGBModesCommandEnd = new byte[] {0xFF};

        public LEDWifiControllerProtocolB()
        {
        }

        public byte[] GetControlPacket()
        {
            return m_controllerPacket;
        }

        public bool TurnOn()
        {
            System.Buffer.BlockCopy(m_onCommand, 0, m_controllerPacket, 0, m_onCommand.Length);
            return true;
        }

        public bool TurnOff()
        {
            System.Buffer.BlockCopy(m_offCommand, 0, m_controllerPacket, 0, m_offCommand.Length);
            return true;
        }

        public bool SetRGBStaticColor(byte byRed, byte byGreen, byte byBlue)
        {
            // Command, RGB values, command
            byte[] byRGB = new byte[] { byRed, byGreen, byBlue };

            System.Buffer.BlockCopy(m_RGBStaticCommandHeader, 0, m_controllerPacket, 0, m_RGBStaticCommandHeader.Length);
            System.Buffer.BlockCopy(byRGB, 0, m_controllerPacket, m_RGBStaticCommandHeader.Length, byRGB.Length);
            System.Buffer.BlockCopy(m_RGBStaticCommandEnd, 0, m_controllerPacket, m_RGBStaticCommandHeader.Length + byRGB.Length, m_RGBStaticCommandEnd.Length);
            return true;
        }

        public bool SetBuiltInDisplayMode(byte bySpeed, byte byPause, byte byProgram, byte byEffect)
        {
            // Program value range from 0 - 19
            // Speed value range from 0 - 29

            // Good flash 0x0B, 0x13
            // Flashing fast 0x13, 0x1D

            byte[] bySpeedPauseProgramEffect = new byte[] { byProgram, bySpeed };

            System.Buffer.BlockCopy(m_RGBModesCommandHeader, 0, m_controllerPacket, 0, m_RGBModesCommandHeader.Length);
            System.Buffer.BlockCopy(bySpeedPauseProgramEffect, 0, m_controllerPacket, m_RGBModesCommandHeader.Length, bySpeedPauseProgramEffect.Length);
            System.Buffer.BlockCopy(m_RGBModesCommandEnd, 0, m_controllerPacket, m_RGBStaticCommandHeader.Length + bySpeedPauseProgramEffect.Length, m_RGBModesCommandEnd.Length);
            return true;
        }
    }
}
