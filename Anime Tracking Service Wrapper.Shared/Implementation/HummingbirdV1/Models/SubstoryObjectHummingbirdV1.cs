using AnimeTrackingServiceWrapper.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.Implementation.HummingbirdV1.Models
{
    public class SubstoryObjectHummingbirdV1 : ModelBase
    {
        private int m_id = 0;
        public int id
        {
            get { return m_id; }
            set
            {
                m_id = value;
                RaisePropertyChanged(nameof(id));
            }
        }

        private string m_substory_type = "";
        public string substory_type
        {
            get { return m_substory_type; }
            set
            {
                m_substory_type = value;
                RaisePropertyChanged(nameof(substory_type));
            }
        }

        private string m_created_at = "";
        public string created_at
        {
            get { return m_created_at; }
            set
            {
                m_created_at = value;
                RaisePropertyChanged(nameof(created_at));
            }
        }

        private string m_comment = "";
        public string comment
        {
            get { return m_comment; }
            set
            {
                m_comment = value;
                RaisePropertyChanged(nameof(comment));
            }
        }

        private string m_episode_number = "";
        public string episode_number
        {
            get { return m_episode_number; }
            set
            {
                m_episode_number = value;
                RaisePropertyChanged(nameof(episode_number));
            }
        }

        private UserObjectMiniHummingbirdV1 m_followed_user = new UserObjectMiniHummingbirdV1();
        public UserObjectMiniHummingbirdV1 followed_user
        {
            get { return m_followed_user; }
            set
            {
                m_followed_user = value;
                RaisePropertyChanged(nameof(followed_user));
            }
        }

        private string m_new_status = "";
        public string new_status
        {
            get { return m_new_status; }
            set
            {
                m_new_status = value;
                RaisePropertyChanged(nameof(new_status));
            }
        }

        private object m_service = new object();
        public object service
        {
            get { return m_service; }
            set
            {
                m_service = value;
                RaisePropertyChanged(nameof(service));
            }
        }

        private PermissionsHummingbirdV1 m_permissions = new PermissionsHummingbirdV1();
        public PermissionsHummingbirdV1 permissions
        {
            get { return m_permissions; }
            set
            {
                m_permissions = value;
                RaisePropertyChanged(nameof(permissions));
            }
        }
    }
}
