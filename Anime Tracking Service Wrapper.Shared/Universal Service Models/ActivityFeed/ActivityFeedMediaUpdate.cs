using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.UniversalServiceModels.ActivityFeed
{
    public class ActivityFeedMediaUpdate : AActivityFeedItem
    {
        private ServiceID m_MediaID;
        public ServiceID MediaID
        {
            get { return m_MediaID; }
            set
            {
                if (m_MediaID == value) return;
                m_MediaID = value;
                RaisePropertyChanged(nameof(MediaID));
            }
        }

        private Uri m_activityFeedImage = new Uri("http://www.example.com", UriKind.Absolute);
        public Uri ActivityFeedImage
        {
            get { return m_activityFeedImage; }
            set
            {
                if (m_activityFeedImage == value) return;
                m_activityFeedImage = value;
                RaisePropertyChanged(nameof(ActivityFeedImage));
            }
        }

        private string m_header = "";
        public string Header
        {
            get { return m_header; }
            set
            {
                if (m_header == value) return;
                m_header = value;
                RaisePropertyChanged(nameof(Header));
            }
        }

        private string m_content = "";
        public string Content
        {
            get { return m_content; }
            set
            {
                if (m_content == value) return;
                m_content = value;
                RaisePropertyChanged(nameof(Content));
            }
        }

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
