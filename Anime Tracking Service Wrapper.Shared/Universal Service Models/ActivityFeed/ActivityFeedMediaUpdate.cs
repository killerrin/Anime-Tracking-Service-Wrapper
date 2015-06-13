using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.UniversalServiceModels.ActivityFeed
{
    public class ActivityFeedMediaUpdate : AActivityFeedItem
    {
        public ServiceID MediaID;
        public Uri ActivityFeedImage;
        public string Header;
        public string Content;

        public ActivityFeedMediaUpdate(UserInfo user, ServiceID mediaID, Uri activityFeedImage, DateTime timestamp)
            : base()
        {
            User = user;
            MediaID = mediaID;
            ActivityFeedImage = activityFeedImage;
            Timestamp = timestamp;
        }
    }
}
