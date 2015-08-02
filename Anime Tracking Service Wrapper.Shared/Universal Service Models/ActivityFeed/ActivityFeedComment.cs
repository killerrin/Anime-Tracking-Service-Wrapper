using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.UniversalServiceModels.ActivityFeed
{
    public class ActivityFeedComment : AActivityFeedItem
    {
        private string m_content = "";
        public string Content
        {
            get { return m_content; }
            set
            {
                if (m_content == value) return;
                m_content = value;
                RaisePropertyChanged(nameof(Content));
            }
        }

        public ActivityFeedComment(UserInfo commentingUser, string content, DateTime timestamp)
            : base()
        {
            User = commentingUser;
            Content = content;
            Timestamp = timestamp;
        }
    }
}
