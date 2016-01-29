using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JRiverInterfaceService
{
    class LEDWifiControllerContainer
    {
        List<LEDWifiControllersInterface> m_allWifiControllers = null;

        public LEDWifiControllerContainer()
        {
            LEDWifiControllersInterface ledWifiControllersInterfaceA = new LEDWifiControllerA();
            LEDWifiControllersInterface ledWifiControllersInterfaceB = new LEDWifiControllerB();

            m_allWifiControllers = new List<LEDWifiControllersInterface>();

            m_allWifiControllers.Add(ledWifiControllersInterfaceA);
            m_allWifiControllers.Add(ledWifiControllersInterfaceB);
        }

        public void TurnOnLights(bool bOn)
        {
            foreach (LEDWifiControllersInterface controller in m_allWifiControllers)
            {
                controller.TurnOnLights(bOn);
            }
        }

        public void SetRGBStaticColor(byte byRed, byte byGreen, byte byBlue)
        {
            foreach (LEDWifiControllersInterface controller in m_allWifiControllers)
            {
                controller.SetRGBStaticColor(byRed, byGreen, byBlue);
            }
        }

        public void SetBuiltInDisplayMode(byte bySpeed, byte byPause, byte byProgram, byte byEffect)
        {
            foreach (LEDWifiControllersInterface controller in m_allWifiControllers)
            {
                controller.SetBuiltInDisplayMode(bySpeed, byPause, byProgram, byEffect);
            }
        }

    }
}
