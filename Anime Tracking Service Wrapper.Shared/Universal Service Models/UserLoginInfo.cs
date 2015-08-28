using AnimeTrackingServiceWrapper.Helpers;
using AnimeTrackingServiceWrapper.UniversalServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.UniversalServiceModels
{
    public class UserLoginInfo : ModelBase
    {
        private LoginMethod m_loginMethod = LoginMethod.None;
        public LoginMethod LoginMethod
        {
            get { return m_loginMethod; }
            set
            {
                if (m_loginMethod == value) return;
                m_loginMethod = value;
                RaisePropertyChanged(nameof(LoginMethod));
            }
        }

        private string m_username = "";
        public string Username
        {
            get { return m_username; }
            set
            {
                if (m_username == value) return;
                m_username = value;
                RaisePropertyChanged(nameof(Username));
                RaisePropertyChanged(nameof(HasUsername));
            }
        }

        private string m_password = "";
        public string Password
        {
            get { return m_password; }
            set
            {
                if (m_password == value) return;
                m_password = value;
                RaisePropertyChanged(nameof(Password));
                RaisePropertyChanged(nameof(HasPassword));
            }
        }

        private string m_authtoken = "";
        public string AuthToken
        {
            get { return m_authtoken; }
            set
            {
                if (m_authtoken == value) return;
                m_authtoken = value;
                RaisePropertyChanged(nameof(AuthToken));
                RaisePropertyChanged(nameof(HasAuthToken));
                RaisePropertyChanged(nameof(IsUserLoggedIn));
            }
        }

        public bool HasUsername { get { return !(string.IsNullOrWhiteSpace(Username)); } }
        public bool HasPassword { get { return !(string.IsNullOrWhiteSpace(Password)); } }
        public bool HasAuthToken { get { return !(string.IsNullOrWhiteSpace(AuthToken)); } }
        public bool IsUserLoggedIn { get { return HasAuthToken; } }


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
