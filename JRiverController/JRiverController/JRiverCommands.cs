using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace JRiverController
{
	class JRiverCommands
	{
		private string m_strServerIP = "0.0.0.0";
		private string m_strServerPort = "1234";

		public JRiverCommands()
		{

		}

		public JRiverCommands(string strServerIP, string strServerPort)
		{
			m_strServerIP = strServerIP;
			m_strServerPort = strServerPort;
		}

		private string GetBaseURL()
		{
			string strBaseURL = "http://" + m_strServerIP + ":" + m_strServerPort + "/MCWS/v1/";
			return strBaseURL;
		}

		public string GetPlaylistsList()
		{
			string strWebResponse = null;

			string strJRiverCommand = GetBaseURL() + "Playlists/List";

			try
			{
				WebRequest request = WebRequest.Create(strJRiverCommand);
				WebResponse webResponse = request.GetResponse();

				Stream responseStream = webResponse.GetResponseStream();
				StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8);
				strWebResponse = streamReader.ReadToEnd();
			}
			catch (Exception ex)
			{
				strWebResponse = ex.Message;
				PlayLists playLists = new PlayLists(strWebResponse);
				Zones zones = new Zones(@"E:\SubVersion\JRiverController\JRiverController\ZonesConfigXML.xml");
				Users users = new Users(@"E:\SubVersion\JRiverController\JRiverController\UserConfigXML.xml");
			}

			return strWebResponse;
		}

		public string TestWebServiceResponse()
		{
			WebRequest request = WebRequest.Create("http://api.flickr.com/services/rest/?method=flickr.interestingness.getList&api_key=*&extras=");
			WebResponse webResponse = request.GetResponse();

			Stream responseStream = webResponse.GetResponseStream();
			StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8);
			return streamReader.ReadToEnd();
		}
	}
}

//http://localhost:52199/MCWS/v1/Playlists/List
//Then like this to play it
//http://localhost:52199/MCWS/v1/Playlist/Files?PlaylistType=ID&Action=Play&Playlist=531723557&Zone=AirPlay&ZoneType=Name


