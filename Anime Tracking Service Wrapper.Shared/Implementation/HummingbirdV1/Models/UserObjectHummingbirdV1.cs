using AnimeTrackingServiceWrapper.Helpers;
using AnimeTrackingServiceWrapper.UniversalServiceModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.Implementation.HummingbirdV1.Models
{
    public class UserObjectHummingbirdV1 : ModelBase
    {
        private string m_name = "";
        public string name
        {
            get { return m_name; }
            set
            {
                m_name = value;
                RaisePropertyChanged(nameof(name));
            }
        }

        private string m_waifu = "";
        public string waifu
        {
            get { return m_waifu; }
            set
            {
                m_waifu = value;
                RaisePropertyChanged(nameof(waifu));
            }
        }

        private string m_waifu_or_husbando = "";
        public string waifu_or_husbando
        {
            get { return m_waifu_or_husbando; }
            set
            {
                m_waifu_or_husbando = value;
                RaisePropertyChanged(nameof(waifu_or_husbando));
            }
        }

        private string m_waifu_slug = "";
        public string waifu_slug
        {
            get { return m_waifu_slug; }
            set
            {
                m_waifu_slug = value;
                RaisePropertyChanged(nameof(waifu_slug));
            }
        }

        private string m_waifu_char_id = "";
        public string waifu_char_id
        {
            get { return m_waifu_char_id; }
            set
            {
                m_waifu_char_id = value;
                RaisePropertyChanged(nameof(waifu_char_id));
            }
        }

        private string m_location = "";
        public string location
        {
            get { return m_location; }
            set
            {
                m_location = value;
                RaisePropertyChanged(nameof(location));
            }
        }
        private string m_website = "";
        public string website
        {
            get { return m_website; }
            set
            {
                m_website = value;
                RaisePropertyChanged(nameof(website));
            }
        }

        private string m_avatar = "";
        public string avatar
        {
            get { return m_avatar; }
            set
            {
                m_avatar = value;
                RaisePropertyChanged(nameof(avatar));
            }
        }

        private string m_cover_image = "";
        public string cover_image
        {
            get { return m_cover_image; }
            set
            {
                m_cover_image = value;
                RaisePropertyChanged(nameof(cover_image));
            }
        }

        private string m_about = "";
        public string about
        {
            get { return m_about; }
            set
            {
                m_about = value;
                RaisePropertyChanged(nameof(about));
            }
        }

        private string m_bio = "";
        public string bio
        {
            get { return m_bio; }
            set
            {
                m_bio = value;
                RaisePropertyChanged(nameof(bio));
            }
        }

        private int m_karma = 0;
        public int karma
        {
            get { return m_karma; }
            set
            {
                m_karma = value;
                RaisePropertyChanged(nameof(karma));
            }
        }

        private int m_life_spent_on_anime = 0;
        public int life_spent_on_anime
        {
            get { return m_life_spent_on_anime; }
            set
            {
                m_life_spent_on_anime = value;
                RaisePropertyChanged(nameof(life_spent_on_anime));
            }
        }

        private bool m_show_adult_content = false;
        public bool show_adult_content
        {
            get { return m_show_adult_content; }
            set
            {
                m_show_adult_content = value;
                RaisePropertyChanged(nameof(show_adult_content));
            }
        }

        private string m_title_language_preference = "";
        public string title_language_preference
        {
            get { return m_title_language_preference; }
            set
            {
                m_title_language_preference = value;
                RaisePropertyChanged(nameof(title_language_preference));
            }
        }

        private string m_last_library_update = "";
        public string last_library_update
        {
            get { return m_last_library_update; }
            set
            {
                m_last_library_update = value;
                RaisePropertyChanged(nameof(last_library_update));
            }
        }

        private bool m_online = true;
        public bool online
        {
            get { return m_online; }
            set
            {
                m_online = value;
                RaisePropertyChanged(nameof(online));
            }
        }

        private bool m_following = false;
        public bool following
        {
            get { return m_following; }
            set
            {
                m_following = value;
                RaisePropertyChanged(nameof(following));
            }
        }

        private List<FavoriteObjectHummingbirdV1> m_favorites = new List<FavoriteObjectHummingbirdV1>();
        public List<FavoriteObjectHummingbirdV1> favorites
        {
            get { return m_favorites; }
            set
            {
                m_favorites = value;
                RaisePropertyChanged(nameof(favorites));
            }
        }

        #region Extensions
        [JsonIgnore]
        public bool HasWaifu
        {
            get { return !string.IsNullOrWhiteSpace(waifu); }
        }

        [JsonIgnore]
        public Uri WaifuImageUri
        {
            get { return GetWaifuPictureURI(); }
        }

        public Uri GetWaifuPictureURI()
        {
            if (string.IsNullOrWhiteSpace(waifu_char_id))
                return new Uri("https://hummingbird.me/default_avatar.jpg", UriKind.Absolute);

            string beginningUrl = "http://static.hummingbird.me/characters/images/000/0";
            string firstTwo = "" + waifu_char_id[0] + waifu_char_id[1] + "/";
            string lastThree = "" + waifu_char_id[2] + waifu_char_id[3] + waifu_char_id[4] + '/';
            string afterCutID = "thumb_small/";
            string fullWaifuIDExtension = waifu_char_id + ".jpg?1375255551";

            string fullUrl = beginningUrl + firstTwo + lastThree + afterCutID + fullWaifuIDExtension;
            return new Uri(fullUrl, UriKind.Absolute);
        }
        #endregion

        public static explicit operator UserInfo(UserObjectHummingbirdV1 rawUserInfo)
        {
            UserInfo userInfo = new UserInfo();
            userInfo.Username = rawUserInfo.name;

            if (string.IsNullOrWhiteSpace(rawUserInfo.avatar))
                userInfo.AvatarUrl = new Uri("http://www.killerrin.com", UriKind.Absolute);
            else userInfo.AvatarUrl = new Uri(rawUserInfo.avatar, UriKind.Absolute);

            userInfo.Location = rawUserInfo.location;
            userInfo.Biography = rawUserInfo.bio;

            if (string.IsNullOrWhiteSpace(rawUserInfo.website))
                userInfo.Website = new Uri("http://www.example.com", UriKind.Absolute);
            else userInfo.Website = new Uri(rawUserInfo.website, UriKind.Absolute);

            return userInfo;
        }
    }
}
