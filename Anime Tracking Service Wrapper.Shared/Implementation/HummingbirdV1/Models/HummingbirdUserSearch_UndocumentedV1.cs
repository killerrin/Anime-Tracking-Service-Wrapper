using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.Implementation.HummingbirdV1.Models
{
    public class BadgeUserSearchHummingbird_UndocumentedV1
    {
        public string @class { get; set; }
        public string content { get; set; }
    }

    public class UserSearchItemHummingbird_UndocumentedV1
    {
        public string type { get; set; }
        public string title { get; set; }
        public string desc { get; set; }
        public string image { get; set; }
        public string link { get; set; }
        public double rank { get; set; }
        public List<BadgeUserSearchHummingbird_UndocumentedV1> badges { get; set; }
    }

    public class UserSearchHummingbird_UndocumentedV1
    {
        public List<UserSearchItemHummingbird_UndocumentedV1> search { get; set; }
    }
}
