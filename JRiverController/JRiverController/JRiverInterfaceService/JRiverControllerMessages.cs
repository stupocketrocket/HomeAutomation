using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JRiverController;
using System.Net;
using System.IO;


namespace JRiverInterfaceService
{
	class JRiverControllerMessages
	{
		private Zones m_zones;
		private Users m_users;
		private PlayLists m_playLists;

		private string m_strZoneConfigFile = "ZonesConfigXML.xml";
		private string m_strUsersConfigFile = "UserConfigXML.xml";

		//private string m_strServerAddress = "127.0.0.1";
		private string m_strServerAddress = "192.168.0.32";
		private string m_strServerPort = "52199";

		public JRiverControllerMessages()
		{
			string strExeDirectory = AppDomain.CurrentDomain.BaseDirectory;

			m_zones = new Zones(strExeDirectory + m_strZoneConfigFile);
			m_users = new Users(strExeDirectory + m_strUsersConfigFile);
		}

		public string SetPlaylistToZone(int beaconId, string userId)
		{
			bool bVal = false;

			string strZoneName = "";
			string strPlaylistName = "";
			bVal = m_zones.GetZoneFromBeacon(beaconId, out strZoneName);
			bVal &= m_users.GetUserPlaylistFromUserId(userId, out strPlaylistName);

			if (!bVal)
			{
				return "failure";
			}

			string strPlaylistResponse = "";
			bVal &= GetPlaylistsList(out strPlaylistResponse);

			if (!bVal)
			{
				return "failure";
			}

			PlayLists playLists = new PlayLists(strPlaylistResponse);

			Int32 i32PlaylistId = 0;
			bVal &= playLists.GetPlaylistId(strPlaylistName, out i32PlaylistId);

			if (!bVal)
			{
				return "failure";
			}

			string strSetPlaylistResponse = "";
			bVal &= SetPlaylist(i32PlaylistId, strZoneName, out strSetPlaylistResponse);

			if (!bVal)
			{
				return "failure";
			}

			return "success";
		}


		private string GetBaseURL()
		{
			string strBaseURL = "http://" + m_strServerAddress + ":" + m_strServerPort + "/MCWS/v1/";
			return strBaseURL;
		}

		private bool GetPlaylistsList(out string strPlaylistResponse)
		{
			strPlaylistResponse = null;
			bool bStatus = false;

			string strJRiverCommand = GetBaseURL() + "Playlists/List";

			try
			{
				WebRequest request = WebRequest.Create(strJRiverCommand);
				WebResponse webResponse = request.GetResponse();

				Stream responseStream = webResponse.GetResponseStream();
				StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8);
				strPlaylistResponse = streamReader.ReadToEnd();
				bStatus = true;
			}
			catch (Exception ex)
			{
				strPlaylistResponse = ex.Message;
			}

			return bStatus;
		}

		private bool SetPlaylist(Int32 i32PlaylistId, string strZoneName, out string strSetPlayListResponse)
		{
			bool bStatus = false;
			strSetPlayListResponse = "";

			string strJRiverCommand = GetBaseURL() + "Playlist/Files?PlaylistType=ID&Action=Play";

			// Add playlist id
			strJRiverCommand += "&Playlist=" + i32PlaylistId.ToString();

			// Add zone
			strJRiverCommand += "&Zone=" + strZoneName + "&ZoneType=Name";

			//http://localhost:52199/MCWS/v1/Playlist/Files?PlaylistType=ID&Action=Play&Playlist=531723557&Zone=AirPlay&ZoneType=Name

			try
			{
				WebRequest request = WebRequest.Create(strJRiverCommand);
				WebResponse webResponse = request.GetResponse();

				Stream responseStream = webResponse.GetResponseStream();
				StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8);
				strSetPlayListResponse = streamReader.ReadToEnd();
				bStatus = true;
			}
			catch (Exception ex)
			{
				strSetPlayListResponse = ex.Message;
			}

			return bStatus;
		}
	}
}
