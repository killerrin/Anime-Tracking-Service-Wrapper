using AnimeTrackingServiceWrapper.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.UniversalServiceModels
{
    public class UserInfo : ModelBase
    {
        private string m_username = "";
        public string Username
        {
            get { return m_username; }
            set
            {
                if (m_username == value) return;
                m_username = value;
                RaisePropertyChanged(nameof(Username));
            }
        }

        private Uri m_avatarURL = new Uri("http://www.example.com", UriKind.Absolute);
        public Uri AvatarUrl
        {
            get { return m_avatarURL; }
            set
            {
                if (m_avatarURL == value) return;
                m_avatarURL = value;
                RaisePropertyChanged(nameof(AvatarUrl));
            }
        }

        private string m_location = "";
        public string Location
        {
            get { return m_location; }
            set
            {
                if (m_location == value) return;
                m_location = value;
                RaisePropertyChanged(nameof(Location));
            }
        }

        private string m_biography = "";
        public string Biography
        {
            get { return m_biography; }
            set
            {
                if (m_biography == value) return;
                m_biography = value;
                RaisePropertyChanged(nameof(Biography));
            }
        }

        private Uri m_website = new Uri("http://www.example.com", UriKind.Absolute);
        public Uri Website
        {
            get { return m_website; }
            set
            {
                if (m_website == value) return;
                m_website = value;
                RaisePropertyChanged(nameof(Website));
            }
        }

        public UserInfo()
        {
            Username = "";
            AvatarUrl = new Uri("http://www.example.com", UriKind.Absolute);

            Location = "";
            Website = new Uri("http://www.example.com", UriKind.Absolute);
        }
        public UserInfo(string username)
        {
            Username = username;
            AvatarUrl = new Uri("http://www.example.com", UriKind.Absolute);

            Location = "";
            Website = new Uri("http://www.example.com", UriKind.Absolute);
        }
    }
}
