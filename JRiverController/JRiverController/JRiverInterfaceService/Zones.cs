using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace JRiverController
{
	class Zones
	{
		private List<Zone> m_zoneList = new List<Zone>();

		public Zones(string strZonesXML)
		{
			DeSerializeXML(strZonesXML);
		}

		private void DeSerializeXML(string strZonesXML)
		{
			XmlDocument doc = new XmlDocument();
			doc.Load(strZonesXML);

			XmlNodeList nodes = doc.DocumentElement.SelectNodes("/Zones/Zone");

			foreach (XmlNode node in nodes)
			{
				Zone zone = new Zone();

				zone.BeaconId = Convert.ToUInt32(node.SelectSingleNode("beaconId").InnerText);
				zone.ZoneName = node.SelectSingleNode("jRiverZoneName").InnerText;

				m_zoneList.Add(zone);
			}

			System.Console.WriteLine("Total zones: " + m_zoneList.Count);
		}

		public bool GetZoneFromBeacon(int iBeaconId, out string strZoneName)
		{
			strZoneName = "";

			foreach(Zone zone in m_zoneList)
			{
				if (zone.BeaconId == iBeaconId)
				{
					strZoneName = zone.ZoneName;
					return true;
				}
			}

			return false;
		}

	}

	class Zone
	{
		private UInt32 m_beaconId;
		private string m_zoneName;

		public UInt32 BeaconId
		{
			get { return m_beaconId; }
			set { m_beaconId = value; }
		}

		public string ZoneName
		{
			get { return m_zoneName; }
			set { m_zoneName = value; }
		}
	}
}
