using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace JRiverInterfaceService
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IJRiverControllerServiceImpl" in both code and config file together.
	[ServiceContract(Namespace = "http://JRiverInterfaceService")]
	public interface IJRiverControllerServiceImpl
	{
		[OperationContract]
		[WebInvoke(Method = "GET",
			ResponseFormat = WebMessageFormat.Xml,
			BodyStyle = WebMessageBodyStyle.Wrapped,
			UriTemplate = "xml?param1={id}")]
		string XMLData(string id);

		[OperationContract]
		[WebInvoke(Method = "GET",
			ResponseFormat = WebMessageFormat.Json,
			BodyStyle = WebMessageBodyStyle.Wrapped,
			UriTemplate = "json/{id}")]
		string JSONData(string id);

		[OperationContract]
		[WebInvoke(Method = "GET",
			ResponseFormat = WebMessageFormat.Xml,
			BodyStyle = WebMessageBodyStyle.Wrapped,
			UriTemplate = "SetZone?BeaconId={beaconId}&UserId={userId}")]
		string SetZone(int beaconId, string userId);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "TurnLightOn?SelectedLight={lightId}")]
        void TurnLightOn(int lightId);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "TurnLightOff")]
        void TurnLightOff();

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "SetRGBStaticColor?Red={byRed}&Green={byGreen}&Blue={byBlue}")]
        void SetRGBStaticColor(byte byRed, byte byGreen, byte byBlue);
        
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "SetBuiltInDisplayMode?Speed={bySpeed}&Pause={byPause}&Program={byProgram}&Effect={byEffect}")]
        void SetBuiltInDisplayMode(byte bySpeed, byte byPause, byte byProgram, byte byEffect);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Login?Username={strUsername}&Password={strPassword}")]
        string Login(string strUsername, string strPassword);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "IsLoggedOn?UserToken={strUserToken}")]
        bool IsLoggedOn(string strUserToken);

	}
}
