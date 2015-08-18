using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.UniversalServiceModels.ActivityFeed
{
    public class ActivityFeedComment : AActivityFeedItem
    {
        private string m_comment = "";
        public string Comment
        {
            get { return m_comment; }
            set
            {
                if (m_comment == value) return;
                m_comment = value;
                RaisePropertyChanged(nameof(Comment));
            }
        }

        public ActivityFeedComment(UserInfo commentingUser, string comment, DateTime timestamp)
            : base()
        {
            User = commentingUser;
            Comment = comment;
            Timestamp = timestamp;
        }
    }
}
