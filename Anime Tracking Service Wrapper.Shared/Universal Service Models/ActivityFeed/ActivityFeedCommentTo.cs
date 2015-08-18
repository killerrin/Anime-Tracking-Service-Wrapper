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

        public ActivityFeedCommentTo(UserInfo sendingUser, UserInfo recievingUser, string comment, DateTime timestamp)
            : base()
        {
            User = sendingUser;
            RecievingUser = recievingUser;
            Comment = comment;
            Timestamp = timestamp;
        }
    }
}
