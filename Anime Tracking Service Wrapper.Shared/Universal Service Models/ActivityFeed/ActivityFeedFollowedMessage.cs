using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.UniversalServiceModels.ActivityFeed
{
    public class ActivityFeedFollowedMessage : AActivityFeedItem
    {
        private UserInfo m_followedUser = new UserInfo();
        public UserInfo FollowedUser
        {
            get { return m_followedUser; }
            set
            {
                if (m_followedUser == value) return;
                m_followedUser = value;
                RaisePropertyChanged(nameof(FollowedUser));
            }
        }

        public ActivityFeedFollowedMessage(UserInfo followingUser, UserInfo followedUser, DateTime timestamp )
            :base()
        {
            User = followingUser;
            FollowedUser = followedUser;
            Timestamp = timestamp;
        }
    }
}
