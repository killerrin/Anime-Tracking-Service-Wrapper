using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.Implementation.HummingbirdV1.Data_Structures
{
    public class FavoriteObjectHummingbirdV1
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int item_id { get; set; }
        public string item_type { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public int fav_rank { get; set; }
    }
}
