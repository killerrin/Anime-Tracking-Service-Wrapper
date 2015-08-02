using AnimeTrackingServiceWrapper.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.Implementation.HummingbirdV1.Models
{
    public class FavoriteObjectHummingbirdV1 : ModelBase
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

        private int m_user_id = 0;
        public int user_id
        {
            get { return m_user_id; }
            set
            {
                m_user_id = value;
                RaisePropertyChanged(nameof(user_id));
            }
        }

        private int m_item_id = 0;
        public int item_id
        {
            get { return m_item_id; }
            set
            {
                m_item_id = value;
                RaisePropertyChanged(nameof(item_id));
            }
        }

        private string m_item_type = "";
        public string item_type
        {
            get { return m_item_type; }
            set
            {
                m_item_type = value;
                RaisePropertyChanged(nameof(item_type));
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

        private string m_updated_at = "";
        public string updated_at
        {
            get { return m_updated_at; }
            set
            {
                m_updated_at = value;
                RaisePropertyChanged(nameof(updated_at));
            }
        }

        private int m_fav_rank = 0;
        public int fav_rank
        {
            get { return m_fav_rank; }
            set
            {
                m_fav_rank = value;
                RaisePropertyChanged(nameof(fav_rank));
            }
        }
    }
}
