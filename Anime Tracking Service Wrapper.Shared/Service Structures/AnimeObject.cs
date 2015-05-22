using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.Service_Structures
{
    public class AnimeObject
    {
        public ServiceName Service;

        #region Properties
        public string ServiceID { get; set; }
        public string ServiceID2 { get; set; }

        public AiringStatus AiringStatus { get; set; }

        public Uri WebUrl { get; set; }
        public string WebUrlString
        {
            get { return WebUrl.OriginalString; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    WebUrl = new Uri(value, UriKind.Absolute);
                }
            }
        }

        public string RomanjiTitle { get; set; }
        public string EnglishTitle { get; set; }
        public string KanjiTitle { get; set; }

        public int EpisodeCount { get; set; }
        public string EpisodeCountString
        {
            get
            {
                if (EpisodeCount == 0) return "?";
                return EpisodeCount.ToString();
            }
            set
            {
                if (string.IsNullOrEmpty(value)) { EpisodeCount = 0; }
                else if (value.Contains("?")) { EpisodeCount = 0; }
                else
                {
                    try { EpisodeCount = Convert.ToInt32(value); }
                    catch (Exception) { EpisodeCount = 0; }
                }
            }
        }

        private Uri m_coverImageUrl;
        public Uri CoverImageUrl
        {
            get { return m_coverImageUrl; }
            set
            {
                if (value != null)
                {
                    m_coverImageUrl = value;
                }
            }
        }

        public string CoverImageUrlString
        {
            get { return m_coverImageUrl.OriginalString; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    m_coverImageUrl = new Uri(value, UriKind.Absolute);
                }
            }
        }

        public string Synopsis { get; set; }
        public MediaType MediaType { get; set; }

        public int FavouriteRank { get; set; }
        public int FavouriteID { get; set; }

        public List<MediaGenre> Genres { get; set; }
        #endregion
    }
}
