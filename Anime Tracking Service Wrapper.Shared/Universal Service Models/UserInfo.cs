using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.UniversalServiceModels
{
    public class UserInfo
    {
        public string Username;
        public Uri AvatarUrl;

        public string Location;
        public Uri Website;

        public UserInfo()
        {
            Username = "";
            AvatarUrl = new Uri("http://www.killerrin.com", UriKind.Absolute);

            Location = "";
            Website = new Uri("http://www.example.com", UriKind.Absolute);
        }
    }
}
