using AnimeTrackingServiceWrapper.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AnimeTrackingServiceWrapper.UniversalServiceModels.ActivityFeed
{
    public abstract class AActivityFeedItem : ModelBase
    {
        private UserInfo m_user = new UserInfo();
        public UserInfo User
        {
            get { return m_user; }
            set
            {
                if (m_user == value) return;
                m_user = value;
                RaisePropertyChanged(nameof(User));
            }
        }

        private DateTime m_timeStamp = DateTime.MinValue;
        public DateTime Timestamp
        {
            get { return m_timeStamp; }
            set
            {
                if (m_timeStamp == value) return;
                m_timeStamp = value;
                RaisePropertyChanged(nameof(Timestamp));
            }
        }

        private ObservableCollection<AActivityFeedItem> m_replies = new ObservableCollection<AActivityFeedItem>();
        public ObservableCollection<AActivityFeedItem> Replies
        {
            get { return m_replies; }
            set
            {
                if (m_replies == value) return;

                m_replies = value;
                m_replies.CollectionChanged += M_replies_CollectionChanged;

                RaisePropertyChanged(nameof(Replies));
                if (HasReplies) RaisePropertyChanged(nameof(HasReplies));
            }
        }

        private void M_replies_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (HasReplies)
                RaisePropertyChanged(nameof(HasReplies));
        }

        public bool HasReplies
        {
            get { return Replies.Count > 0; }
        }
    }
}
