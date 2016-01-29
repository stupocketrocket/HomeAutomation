using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace JRiverInterfaceService
{
    class Authentication
    {
        private const int m_kiTokenExpiry = 5; // Token expiry 5 minutes
        private Dictionary<string, string> userList = new Dictionary<string, string>();

        public string Login(string strUserName, string strPassword)
        {
            if (strUserName == "SocketS" && strPassword == "Test")
            {
                userList[strUserName] = CreateUserToken(strUserName, strPassword, 0);
                return userList[strUserName];
            }

            return "FAIL";
        }

        public bool IsLoggedOn(string strUserToken)
        {
            string strUserName = "";
            string strToken = "";

            GetUserNameAndToken(strUserToken, ref strUserName, ref strToken);

            if (userList.ContainsKey(strUserName))
            {
                string strIssuedToken = userList[strUserName];
                if (strIssuedToken != null)
                {
                    if (strUserToken == strIssuedToken)
                    {
                        // Hardcoded password, needs to be user specific
                        if (ValidateToken(strToken, strUserName, "Test", 0))
                        {
                            return true;
                        }
                        userList[strUserName] = null;
                    }
                }
            }

            return false;
        }

        private string Hash(string ToHash)
        {
            // First we need to convert the string into bytes,
            // which means using a text encoder.
            Encoder enc = System.Text.Encoding.ASCII.GetEncoder();

            // Create a buffer large enough to hold the string
            byte[] data = new byte[ToHash.Length];
            enc.GetBytes(ToHash.ToCharArray(), 0, ToHash.Length, data, 0, true);

            // This is one implementation of the abstract class MD5.
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(data);

            return BitConverter.ToString(result).Replace("-", "").ToLower();
        }

        private string CreateToken(string strUserName, string strPassword, int iMinutes)
        {
            string strNewHash;
            string strResultToken;

            DateTime dt = DateTime.Now;
            System.TimeSpan minute = new System.TimeSpan(0, 0, iMinutes, 0, 0);
            dt = dt - minute;
            //before hashing we have:
            //USERNAME|PassWord|YYYYMMDD|HHMM
            strNewHash = strUserName.ToUpper() + "|" + strPassword + "|" + dt.ToString("yyyyMMdd") +
                                                 "|" + dt.ToString("HHmm");
            strResultToken = Hash(strNewHash);

            return strResultToken;
        }

        private string CreateUserToken(string strUserName, string strPassword, int iMinutes)
        {
            string strResultToken = CreateToken(strUserName, strPassword, iMinutes);
            strResultToken += "|" + strUserName;

            return strResultToken;
        }

        private void GetUserNameAndToken(string strUserToken, ref string strUserName, ref string strToken)
        {
            string[] strArrayItems;

            // Key string: HASH|User|OptionalData
            strArrayItems = strUserToken.Split('|');
            strToken = strArrayItems[0];
            strUserName = strArrayItems[1];
        }

        private bool ValidateToken(string strTokenToValidate, string strUserName, string strPassword, int iMinutes)
        {
            string strTokenToCheck = CreateToken(strUserName, strPassword, iMinutes);

            if (strTokenToCheck == strTokenToValidate)
                return true;
            else
            if (iMinutes <= m_kiTokenExpiry)
                return ValidateToken(strTokenToValidate, strUserName, strPassword, iMinutes + 1);
            else
                return false;
        }

    }
}
