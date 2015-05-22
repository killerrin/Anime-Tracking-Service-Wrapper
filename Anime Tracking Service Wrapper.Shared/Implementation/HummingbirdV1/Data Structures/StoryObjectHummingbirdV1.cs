using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.Implementation.HummingbirdV1.Data_Structures
{
    public class StoryObjectHummingbirdV1
    {
        public int id { get; set; }
        public string story_type { get; set; }
        public UserObjectMiniHummingbirdV1 user { get; set; }
        public string updated_at { get; set; }
        public bool self_post { get; set; }
        public UserObjectMiniHummingbirdV1 poster { get; set; }
        public AnimeObjectHummingbirdV1 media { get; set; }
        public int substories_count { get; set; }
        public List<SubstoryObjectHummingbirdV1> substories { get; set; }
    }
}
