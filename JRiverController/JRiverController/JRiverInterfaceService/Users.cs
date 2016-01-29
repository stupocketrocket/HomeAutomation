using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace JRiverController
{
	class Users
	{
		private List<User> m_userList = new List<User>();

		public Users(string strUsersXML)
		{
			DeSerializeXML(strUsersXML);
		}

		private void DeSerializeXML(string strUsersXML)
		{
			XmlDocument doc = new XmlDocument();
			doc.Load(strUsersXML);

			XmlNodeList nodes = doc.DocumentElement.SelectNodes("/Users/User");

			foreach (XmlNode node in nodes)
			{
				User user = new User();

				user.UserName = node.SelectSingleNode("userName").InnerText;
				user.UserId = node.SelectSingleNode("userId").InnerText;
				user.PlayList = node.SelectSingleNode("playList").InnerText;

				m_userList.Add(user);
			}

			System.Console.WriteLine("Total users: " + m_userList.Count);
		}


		public bool GetUserPlaylistFromUserId(string strUserId, out string strPlaylistName)
		{
			strPlaylistName = "";

			strUserId = strUserId.Replace("\"", "");

			foreach (User user in m_userList)
			{
				if (user.UserId == strUserId)
				{
					strPlaylistName = user.PlayList;
					return true;
				}
			}

			return false;
		}
	}

	class User
	{
		private string m_userName;
		private string m_userId;
		private string m_playList;

		public string UserName
		{
			get { return m_userName; }
			set { m_userName = value; }
		}

		public string UserId
		{
			get { return m_userId; }
			set { m_userId = value; }
		}

		public string PlayList
		{
			get { return m_playList; }
			set { m_playList = value; }
		}
	}
}
