using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceProcess;
using System.Configuration;
using System.Configuration.Install;
using System.ComponentModel;

namespace JRiverControllerService
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "JRiverControllerServiceImpl" in code, svc and config file together.
	public class JRiverControllerServiceImpl : IJRiverControllerServiceImpl
	{
		public string XMLData(string id)
		{
			return "You requested product " + id;
		}

		public string JSONData(string id)
		{
			return "You requested product " + id;
		}
	}


	public class JRiverControllerService : ServiceBase
	{
		public ServiceHost serviceHost = null;
		public JRiverControllerService()
		{
			// Name the Windows Service
			ServiceName = "JRiverControllerService";
		}

		public static void Main()
		{
			ServiceBase.Run(new JRiverControllerService());
		}

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
			serviceHost.Open();
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
			service.ServiceName = "JRiverControllerService";
			Installers.Add(process);
			Installers.Add(service);
		}
	}





}
