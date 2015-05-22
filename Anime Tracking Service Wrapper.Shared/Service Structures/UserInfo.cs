using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.Service_Structures
{
    public class UserInfo
    {
        public string Username;
        public string Password;
        public string AuthToken;

        public bool IsLoggedInUser { get { return !(string.IsNullOrWhiteSpace(AuthToken)); } }

        public UserInfo() { }
        public UserInfo(string username, string password, string authtoken = "")
        {
            Username = username;
            Password = password;
            AuthToken = authtoken;
        }
    }
}
