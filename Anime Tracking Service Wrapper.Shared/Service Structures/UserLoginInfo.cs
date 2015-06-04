﻿using AnimeTrackingServiceWrapper.Service_Structures.Enumerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.Service_Structures
{
    public class UserLoginInfo
    {
        public LoginMethod LoginMethod;

        public string Username;
        public string Password;
        public string AuthToken;

        public bool IsLoggedInUser { get { return !(string.IsNullOrWhiteSpace(AuthToken)); } }

        public UserLoginInfo() { }
        public UserLoginInfo(string username, string password, string authtoken = "", LoginMethod loginMethod = LoginMethod.None)
        {
            Username = username;
            Password = password;
            AuthToken = authtoken;
            LoginMethod = loginMethod;
        }
    }
}
