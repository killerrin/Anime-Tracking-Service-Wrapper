using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.Implementation.HummingbirdV1.Data_Structures
{
    public class AnimeObjectHummingbirdV1
    {
        public int id { get; set; }
        public int? mal_id { get; set; }
        public string slug { get; set; }
        public string status { get; set; }
        public string url { get; set; }
        public string title { get; set; }
        public string alternate_title { get; set; }
        public int? episode_count { get; set; }
        public int? episode_length { get; set; }
        public string cover_image { get; set; }
        public string synopsis { get; set; }
        public string show_type { get; set; }
        public string started_airing { get; set; }
        public string finished_airing { get; set; }
        public double community_rating { get; set; }
        public string age_rating { get; set; }
        public List<GenreHummingbirdV1> genres { get; set; }

        public int fav_rank { get; set; }
        public int fav_id { get; set; }
    }
}