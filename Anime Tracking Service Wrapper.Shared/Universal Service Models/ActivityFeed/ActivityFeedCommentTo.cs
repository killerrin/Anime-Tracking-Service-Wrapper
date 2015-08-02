using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.UniversalServiceModels.ActivityFeed
{
    public class ActivityFeedCommentTo : AActivityFeedItem
    {
        private UserInfo m_recievingUser = new UserInfo();
        public UserInfo RecievingUser
        {
            get { return m_recievingUser; }
            set
            {
                if (m_recievingUser == value) return;
                m_recievingUser = value;
                RaisePropertyChanged(nameof(RecievingUser));
            }
        }

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

        public ActivityFeedCommentTo(UserInfo sendingUser, UserInfo recievingUser, string content, DateTime timestamp)
            : base()
        {
            User = sendingUser;
            RecievingUser = recievingUser;
            Content = content;
            Timestamp = timestamp;
        }
    }
}
