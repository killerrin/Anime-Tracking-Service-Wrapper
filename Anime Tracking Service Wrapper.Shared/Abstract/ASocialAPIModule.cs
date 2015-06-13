using AnimeTrackingServiceWrapper.UniversalServiceModels;
using AnimeTrackingServiceWrapper.UniversalServiceModels.ActivityFeed;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnimeTrackingServiceWrapper.Abstract
{
    public abstract class ASocialAPIModule : AAPIModule
    {
        public abstract Task<List<AActivityFeedItem>> GetActivityFeed(string username, int paginationIndex, IProgress<APIProgressReport> progress);
        public abstract Task<AActivityFeedItem> PostStatusUpdate(UserLoginInfo userLoginInfo, string message, IProgress<APIProgressReport> progress);
    }
}
