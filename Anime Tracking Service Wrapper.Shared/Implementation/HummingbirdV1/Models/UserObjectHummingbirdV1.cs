using AnimeTrackingServiceWrapper.UniversalServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.Implementation.HummingbirdV1.Models
{
    public class UserObjectHummingbirdV1
    {
        public string name { get; set; }
        public string waifu { get; set; }
        public string waifu_or_husbando { get; set; }
        public string waifu_slug { get; set; }
        public string waifu_char_id { get; set; }
        public string location { get; set; }
        public string website { get; set; }
        public string avatar { get; set; }
        public string cover_image { get; set; }
        public string about { get; set; }
        public string bio { get; set; }
        public int karma { get; set; }
        public int life_spent_on_anime { get; set; }
        public bool show_adult_content { get; set; }
        public string title_language_preference { get; set; }
        public string last_library_update { get; set; }
        public bool online { get; set; }
        public bool following { get; set; }
        public List<FavoriteObjectHummingbirdV1> favorites { get; set; }

        public static explicit operator UserInfo(UserObjectHummingbirdV1 rawUserInfo)
        {
            UserInfo userInfo = new UserInfo();
            userInfo.Username = rawUserInfo.name;

            if (string.IsNullOrWhiteSpace(rawUserInfo.avatar))
                userInfo.AvatarUrl = new Uri("http://www.killerrin.com", UriKind.Absolute);
            else userInfo.AvatarUrl = new Uri(rawUserInfo.avatar, UriKind.Absolute);

            userInfo.Location = rawUserInfo.location;

            if (string.IsNullOrWhiteSpace(rawUserInfo.website))
                userInfo.Website = new Uri("http://www.example.com", UriKind.Absolute);
            else userInfo.Website = new Uri(rawUserInfo.website, UriKind.Absolute);

            return userInfo;
        }
    }
}
