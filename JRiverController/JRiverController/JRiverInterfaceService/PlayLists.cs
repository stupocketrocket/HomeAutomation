using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace JRiverController
{
	class PlayLists
	{
		private List<PlayList> m_playLists = new List<PlayList>();

		public PlayLists(string strPLayListsXML)
		{
			DeSerializeXML(strPLayListsXML);
		}

		private void DeSerializeXML(string strPLayListsXML)
		{
			XmlDocument doc = new XmlDocument();
			doc.LoadXml(strPLayListsXML);
			//doc.Load(@"E:\SubVersion\JRiverController\JRiverController\XMLFile1.xml");

			XmlNodeList nodes = doc.DocumentElement.SelectNodes("/Response/Item");

			foreach (XmlNode node in nodes)
            {
				PlayList playList = new PlayList();
				foreach (XmlNode childNode in node.ChildNodes)
				{

					if (childNode.Attributes["Name"].Value == "ID")
					{
						playList.Id = Convert.ToInt32(childNode.InnerText);
					}
					else
					if (childNode.Attributes["Name"].Value == "Name")
					{
						playList.Name = childNode.InnerText;
					}
					else
					if (childNode.Attributes["Name"].Value == "Path")
					{
						playList.Path = childNode.InnerText;
					}
					else
					if (childNode.Attributes["Name"].Value == "Type")
					{
						playList.Type = childNode.InnerText;
					}
				}
				m_playLists.Add(playList);
            }

			System.Console.WriteLine("Total playlists: " + m_playLists.Count);
		}


		public bool GetPlaylistId(string strPlaylistName, out Int32 i32PlaylistId)
		{
			i32PlaylistId = 0;

			foreach (PlayList playList in m_playLists)
			{
				if (playList.Name == strPlaylistName)
				{
					i32PlaylistId = playList.Id;
					return true;
				}
			}

			return false;
		}

	}

	class PlayList
	{
		private Int32 m_id;
		private string m_name;
		private string m_path;
		private string m_type;

		public Int32 Id
		{
			get { return m_id; }
			set { m_id = value; }
		}

		public string Name
		{
			get { return m_name; }
			set { m_name = value; }
		}

		public string Path
		{
			get { return m_path; }
			set { m_path = value; }
		}

		public string Type
		{
			get { return m_type; }
			set { m_type = value; }
		}
	}
}
