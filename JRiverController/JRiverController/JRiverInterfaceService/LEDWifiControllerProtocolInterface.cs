using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JRiverInterfaceService
{
    interface LEDWifiControllerProtocolInterface
    {
        byte[] GetControlPacket();
        bool TurnOn();
        bool TurnOff();
        bool SetRGBStaticColor(byte byRed, byte byGreen, byte byBlue);
        bool SetBuiltInDisplayMode(byte bySpeed, byte byPause, byte byProgram, byte byEffect);
    }
}
