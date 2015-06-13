using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.UniversalServiceModels.ActivityFeed
{
    public abstract class AActivityFeedItem
    {
        public UserInfo User                         = new UserInfo();
        public DateTime Timestamp                    = DateTime.MinValue;
        public List<AActivityFeedItem> Replies       = new List<AActivityFeedItem>();
    }
}
