using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.Implementation.HummingbirdV1.Data_Structures
{
    public class LibraryObjectHummingbirdV1
    {
        public int id { get; set; }
        public int episodes_watched { get; set; }
        public string last_watched { get; set; }
        public string updated_at { get; set; }
        public int rewatched_times { get; set; }
        public string notes { get; set; }
        public bool? notes_present { get; set; }
        public string status { get; set; }
        public bool @private { get; set; }
        public bool rewatching { get; set; }
        public AnimeObjectHummingbirdV1 anime { get; set; }
        public RatingHummingbirdV1 rating { get; set; }
    }
}
