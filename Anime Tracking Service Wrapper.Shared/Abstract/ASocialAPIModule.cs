using AnimeTrackingServiceWrapper.UniversalServiceModels;
using AnimeTrackingServiceWrapper.UniversalServiceModels.ActivityFeed;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace AnimeTrackingServiceWrapper.Abstract
{
    public abstract class ASocialAPIModule : AAPIModule
    {
        public abstract Task<ObservableCollection<AActivityFeedItem>> GetActivityFeed(string username, int paginationIndex, IProgress<APIProgressReport> progress);
        public abstract Task<AActivityFeedItem> PostStatusUpdate(UserLoginInfo senderUserLoginInfo, UserInfo senderUserInfo, UserInfo receiverUserInfo, string message, IProgress<APIProgressReport> progress);
    }
}
