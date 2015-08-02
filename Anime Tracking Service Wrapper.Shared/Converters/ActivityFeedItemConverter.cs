using AnimeTrackingServiceWrapper.UniversalServiceModels.ActivityFeed;
using System;
using System.Collections.Generic;
using System.Text;
#if !DESKTOP
using Windows.UI.Xaml.Data;
#endif

namespace AnimeTrackingServiceWrapper.Converters
{
    public class ActivityFeedItemConverter
#if !DESKTOP
        : IValueConverter
#endif
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is AActivityFeedItem)
            {
                AActivityFeedItem abstractActivityFeedItem = (AActivityFeedItem)value;
                if (abstractActivityFeedItem is ActivityFeedComment) {
                    return (ActivityFeedComment)abstractActivityFeedItem;
                }
                else if (abstractActivityFeedItem is ActivityFeedCommentTo) {
                    return (ActivityFeedCommentTo)abstractActivityFeedItem;
                }
                else if (abstractActivityFeedItem is ActivityFeedFollowedMessage) { 
                    return (ActivityFeedFollowedMessage)abstractActivityFeedItem;
                }
                else if (abstractActivityFeedItem is ActivityFeedMediaUpdate) {
                    return (ActivityFeedMediaUpdate)abstractActivityFeedItem;
                }
                return abstractActivityFeedItem;
            }
            return new ActivityFeedComment(new UniversalServiceModels.UserInfo("System"), "Message Could not Be Determined", DateTime.Now);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return (AActivityFeedItem)value;
        }
    }
}
