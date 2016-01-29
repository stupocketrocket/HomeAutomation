using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JRiverInterfaceService
{
    interface LEDWifiControllersInterface
    {
        void TurnOnLights(bool bOn);
        void SetRGBStaticColor(byte byRed, byte byGreen, byte byBlue);
        void SetBuiltInDisplayMode(byte bySpeed, byte byPause, byte byProgram, byte byEffect);
    }
}
