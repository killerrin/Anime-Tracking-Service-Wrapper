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

        public ActivityFeedMediaUpdate(UserInfo user, ServiceID mediaID, Uri activityFeedImage, string header, string content, DateTime timestamp)
            : base()
        {
            User = user;
            MediaID = mediaID;
            ActivityFeedImage = activityFeedImage;
            Header = header;
            Content = content;
            Timestamp = timestamp;
        }
    }
}
