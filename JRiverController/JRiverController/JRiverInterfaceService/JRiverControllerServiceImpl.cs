#define STANDALONE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceProcess;
using System.Configuration;
using System.Configuration.Install;
using System.ComponentModel;
using System.ServiceModel;

using System.Threading;

using System.Net;
using System.Net.Sockets;


namespace JRiverInterfaceService
{
	public class JRiverControllerService : ServiceBase
	{
		public ServiceHost serviceHost = null;
		public JRiverControllerService()
		{
			// Name the Windows Service
			ServiceName = "JRiverInterfaceService";
		}

#if (STANDALONE)
		internal void TestStartupAndStop(string[] args)
		{
			this.OnStart(args);
			Console.ReadLine();
			this.OnStop();
		}
#endif

#if (!STANDALONE)
		public static void Main()
		{
			ServiceBase.Run(new JRiverControllerService());
		}
#endif

		// Start the Windows service.
		protected override void OnStart(string[] args)
		{
			if (serviceHost != null)
			{
				serviceHost.Close();
			}

			// Create a ServiceHost for the CalculatorService type and 
			// provide the base address.
			serviceHost = new ServiceHost(typeof(JRiverControllerServiceImpl));

			// Open the ServiceHostBase to create listeners and start 
			// listening for messages.
			try
			{
				serviceHost.Open();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		protected override void OnStop()
		{
			if (serviceHost != null)
			{
				serviceHost.Close();
				serviceHost = null;
			}
		}
	}


	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "JRiverControllerServiceImpl" in code, svc and config file together.
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
	public class JRiverControllerServiceImpl : IJRiverControllerServiceImpl
	{
		private JRiverControllerMessages m_jRiverControllerMessages = new JRiverControllerMessages();
        private LEDWifiControllerContainer m_ledWifiControllers = new LEDWifiControllerContainer();
        private Authentication m_authentication = new Authentication();
        DateTime dtLoggedOn = DateTime.MinValue;

        public JRiverControllerServiceImpl()
		{
			Console.WriteLine("JRiverControllerServiceImpl created");
		}

		public string XMLData(string id)
		{
			return "You requested product " + id;
		}

		public string JSONData(string id)
		{
			return "You requested product " + id;
		}

		public string SetZone(int beaconId, string userId)
		{
			return m_jRiverControllerMessages.SetPlaylistToZone(beaconId, userId);
		}

        public void TurnLightOn(int lightId)
        {
            m_ledWifiControllers.TurnOnLights(true);            
        }

        public void TurnLightOff()
        {
            m_ledWifiControllers.TurnOnLights(false);
        }

        public void SetRGBStaticColor(byte byRed, byte byGreen, byte byBlue)
        {
            m_ledWifiControllers.SetRGBStaticColor(byRed, byGreen, byBlue);
        }

        public void SetBuiltInDisplayMode(byte bySpeed, byte byPause, byte byProgram, byte byEffect)
        {
            m_ledWifiControllers.SetBuiltInDisplayMode(bySpeed, byPause, byProgram, byEffect);
        }

        public string Login(string strUsername, string strPassword)
        {
            return m_authentication.Login(strUsername, strPassword);

/*
            dtLoggedOn = DateTime.MinValue;

            if (strUsername == "SocketS" && strPassword == "Test")
            {
                dtLoggedOn = DateTime.Now;
                return "OK";
            }
            return "FAIL";
*/
        }

        public bool IsLoggedOn(string strUserToken)
        {
            return m_authentication.IsLoggedOn(strUserToken);

/*
            if (dtLoggedOn != DateTime.MinValue)
            {
                DateTime now = DateTime.Now;
                TimeSpan diff = now - dtLoggedOn;
                if (diff.TotalMinutes < 15)
                {
                    return true;
                }
            }

            dtLoggedOn = DateTime.MinValue;
            return false;
 */ 
        }
	}

#if (STANDALONE)
    class Program
    {
        static void Main(string[] args)
        {
            if (Environment.UserInteractive)
            {
                JRiverControllerService service1 = new JRiverControllerService();
                service1.TestStartupAndStop(args);
            }
            else
            {
                // Put the body of your old Main method here.
            }
        }
    }
#endif

	// Provide the ProjectInstaller class which allows 
	// the service to be installed by the Installutil.exe tool
	[RunInstaller(true)]
	public class ProjectInstaller : Installer
	{
		private ServiceProcessInstaller process;
		private ServiceInstaller service;

		public ProjectInstaller()
		{
			process = new ServiceProcessInstaller();
			process.Account = ServiceAccount.LocalSystem;
			service = new ServiceInstaller();
			service.ServiceName = "JRiverInterfaceService";
			Installers.Add(process);
			Installers.Add(service);
		}
	}
}
