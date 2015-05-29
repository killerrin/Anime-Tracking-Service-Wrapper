using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.Service_Structures
{
    public class LibraryObject
    {
        public ServiceName Service;

        #region Properties
        public int RewatchedTimes { get; set; }
        public int EpisodesWatched { get; set; }

        public PrivacySettings Private { get; set; }
        public bool Rewatching { get; set; }

        public double Rating { get; set; }

        public string Notes { get; set; }

        public DateTime LastWatched { get; set; }
        public LibrarySection Section { get; set; }

        public AnimeObject Anime { get; set; }
        #endregion

    }
}
