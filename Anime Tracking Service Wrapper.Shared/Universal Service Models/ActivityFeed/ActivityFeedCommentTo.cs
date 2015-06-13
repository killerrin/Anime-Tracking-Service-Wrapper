using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.UniversalServiceModels.ActivityFeed
{
    public class ActivityFeedCommentTo : AActivityFeedItem
    {
        UserInfo RecievingUser;
        public string Content;

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
