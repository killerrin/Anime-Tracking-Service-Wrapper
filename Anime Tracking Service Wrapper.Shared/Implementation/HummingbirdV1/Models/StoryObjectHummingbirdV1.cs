using AnimeTrackingServiceWrapper.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.Implementation.HummingbirdV1.Models
{
    public class StoryObjectHummingbirdV1 : ModelBase
    {
        private int m_id = 0;
        public int id
        {
            get { return m_id; }
            set
            {
                m_id = value;
                RaisePropertyChanged(nameof(id));
            }
        }

        private string m_story_type = "";
        public string story_type
        {
            get { return m_story_type; }
            set
            {
                m_story_type = value;
                RaisePropertyChanged(nameof(story_type));
            }
        }

        private UserObjectMiniHummingbirdV1 m_user = new UserObjectMiniHummingbirdV1();
        public UserObjectMiniHummingbirdV1 user
        {
            get { return m_user; }
            set
            {
                m_user = value;
                RaisePropertyChanged(nameof(user));
            }
        }

        private string m_updated_at = "";
        public string updated_at
        {
            get { return m_updated_at; }
            set
            {
                m_updated_at = value;
                RaisePropertyChanged(nameof(updated_at));
            }
        }

        private bool? m_self_post = false;
        public bool? self_post
        {
            get { return m_self_post; }
            set
            {
                m_self_post = value;
                RaisePropertyChanged(nameof(self_post));
            }
        }

        private UserObjectMiniHummingbirdV1 m_poster = new UserObjectMiniHummingbirdV1();
        public UserObjectMiniHummingbirdV1 poster
        {
            get { return m_poster; }
            set
            {
                m_poster = value;
                RaisePropertyChanged(nameof(poster));
            }
        }

        private AnimeObjectHummingbirdV1 m_media = new AnimeObjectHummingbirdV1();
        public AnimeObjectHummingbirdV1 media
        {
            get { return m_media; }
            set
            {
                m_media = value;
                RaisePropertyChanged(nameof(media));
            }
        }

        private int m_substories_count = 0;
        public int substories_count
        {
            get { return m_substories_count; }
            set
            {
                m_substories_count = value;
                RaisePropertyChanged(nameof(substories_count));
            }
        }

        private List<SubstoryObjectHummingbirdV1> m_substories = new List<SubstoryObjectHummingbirdV1>();
        public List<SubstoryObjectHummingbirdV1> substories
        {
            get { return m_substories; }
            set
            {
                m_substories = value;
                RaisePropertyChanged(nameof(substories));
            }
        }
    }

    public class StoryObjectListHummingbirdV1
    {
        public List<StoryObjectHummingbirdV1> status_feed { get; set; }

        public static implicit operator List<StoryObjectHummingbirdV1>(StoryObjectListHummingbirdV1 storyObjectList)
        {
            return storyObjectList.status_feed;
        }
    }
}
