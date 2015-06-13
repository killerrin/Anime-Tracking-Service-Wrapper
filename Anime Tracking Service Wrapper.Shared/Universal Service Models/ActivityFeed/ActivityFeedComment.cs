using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.UniversalServiceModels.ActivityFeed
{
    public class ActivityFeedComment : AActivityFeedItem
    {
        public string Content;

        public ActivityFeedComment(UserInfo commentingUser, string content, DateTime timestamp)
            : base()
        {
            User = commentingUser;
            Content = content;
            Timestamp = timestamp;
        }
    }
}
