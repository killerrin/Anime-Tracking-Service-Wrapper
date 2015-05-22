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
        public string EpisodesWatchedString
        {
            get
            {
                //if (EpisodesWatched == 0) return "?";
                return EpisodesWatched.ToString();
            }
            set
            {
                if (string.IsNullOrEmpty(value)) { EpisodesWatched = 0; }
                else if (value.Contains("?")) { EpisodesWatched = 0; }
                else
                {
                    try { EpisodesWatched = Convert.ToInt32(value); }
                    catch (Exception) { EpisodesWatched = 0; }
                }
            }
        }

        public PrivacySettings Private { get; set; }
        public bool Rewatching { get; set; }

        public double Rating { get; set; }

        public string Notes { get; set; }

        public DateTime LastWatched { get; set; }
        public LibrarySection Status { get; set; }

        public AnimeObject Anime { get; set; }
        #endregion

    }
}
