using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.Implementation.HummingbirdV1.Models
{
    public class SubstoryObjectHummingbirdV1
    {
        public int id { get; set; }
        public string substory_type { get; set; }
        public string created_at { get; set; }
        public string comment { get; set; }
        public string episode_number { get; set; }
        public UserObjectMiniHummingbirdV1 followed_user { get; set; }
        public string new_status { get; set; }
        public object service { get; set; }
        public PermissionsHummingbirdV1 permissions { get; set; }
    }
}
