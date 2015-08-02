using AnimeTrackingServiceWrapper.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.UniversalServiceModels.ActivityFeed
{
    public abstract class AActivityFeedItem : ModelBase
    {
        private UserInfo m_user = new UserInfo();
        public UserInfo User
        {
            get { return m_user; }
            set
            {
                if (m_user == value) return;
                m_user = value;
                RaisePropertyChanged(nameof(User));
            }
        }

        private DateTime m_timeStamp = DateTime.MinValue;
        public DateTime Timestamp
        {
            get { return m_timeStamp; }
            set
            {
                if (m_timeStamp == value) return;
                m_timeStamp = value;
                RaisePropertyChanged(nameof(Timestamp));
            }
        }

        private List<AActivityFeedItem> m_replies = new List<AActivityFeedItem>();
        public List<AActivityFeedItem> Replies
        {
            get { return m_replies; }
            set
            {
                if (m_replies == value) return;
                m_replies = value;
                RaisePropertyChanged(nameof(Replies));
            }
        }
    }
}
