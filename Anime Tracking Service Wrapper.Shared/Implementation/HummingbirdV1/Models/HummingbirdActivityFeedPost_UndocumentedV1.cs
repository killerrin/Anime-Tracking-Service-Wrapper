using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.Implementation.HummingbirdV1.Models
{
    public class HummingbirdActivityFeedPostStory_UndocumentedV1
    {
        public string type { get; set; }
        public object created_at { get; set; }
        public string comment { get; set; }
        public object substory_count { get; set; }
        public object total_votes { get; set; }
        public bool is_liked { get; set; }
        public bool adult { get; set; }
        public string user_id { get; set; }
        public string poster_id { get; set; }
        public object group_id { get; set; }
        public object media_id { get; set; }
        public object media_type { get; set; }
    }

    public class HummingbirdActivityFeedPost_UndocumentedV1
    {
        public HummingbirdActivityFeedPostStory_UndocumentedV1 story { get; set; }
    }
}
