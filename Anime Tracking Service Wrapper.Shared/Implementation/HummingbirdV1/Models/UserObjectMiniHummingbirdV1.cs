using AnimeTrackingServiceWrapper.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.Implementation.HummingbirdV1.Models
{
    public class UserObjectMiniHummingbirdV1 : ModelBase
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

        private string m_url = "";
        public string url
        {
            get { return m_url; }
            set
            {
                m_url = value;
                RaisePropertyChanged(nameof(url));
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

        private string m_avatar_small = "";
        public string avatar_small
        {
            get { return m_avatar_small; }
            set
            {
                m_avatar_small = value;
                RaisePropertyChanged(nameof(avatar_small));
            }
        }

        private bool m_nb = false;
        public bool nb
        {
            get { return m_nb; }
            set
            {
                m_nb = value;
                RaisePropertyChanged(nameof(nb));
            }
        }
    }
}
