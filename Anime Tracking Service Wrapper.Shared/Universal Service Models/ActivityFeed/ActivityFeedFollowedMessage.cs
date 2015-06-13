using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.UniversalServiceModels.ActivityFeed
{
    public class ActivityFeedFollowedMessage : AActivityFeedItem
    {
        public UserInfo FollowedUser;

        public ActivityFeedFollowedMessage(UserInfo followingUser, UserInfo followedUser, DateTime timestamp )
            :base()
        {
            User = followingUser;
            FollowedUser = followedUser;
            Timestamp = timestamp;
        }
    }
}
