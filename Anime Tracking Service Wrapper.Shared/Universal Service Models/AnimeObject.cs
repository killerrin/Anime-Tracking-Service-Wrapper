using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.UniversalServiceModels
{
    public class AnimeObject
    {
        public ServiceName Service;

        #region Properties
        public ServiceID ID { get; set; }
        public ServiceID ID2 { get; set; }
        public List<ServiceID> AlternateIDs { get; set; }


        public AiringStatus AiringStatus { get; set; }

        public Uri WebUrl { get; set; }
        public string WebUrlString
        {
            get { return WebUrl.OriginalString; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    WebUrl = new Uri(value, UriKind.Absolute);
            }
        }

        public string RomanjiTitle { get; set; }
        public string EnglishTitle { get; set; }
        public string KanjiTitle { get; set; }

        public int EpisodeCount { get; set; }

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
                if (!string.IsNullOrWhiteSpace(value))
                    m_coverImageUrl = new Uri(value, UriKind.Absolute);
            }
        }

        public AgeRating AgeRating { get; set; }

        public string Synopsis { get; set; }
        public MediaType MediaType { get; set; }

        public int FavouriteRank { get; set; }
        public int FavouriteID { get; set; }

        public List<MediaGenre> Genres { get; set; }
        #endregion

        public AnimeObject()
        {
            ID = new ServiceID(ServiceName.Unknown, MediaType.Unknown, -1);
            ID2 = new ServiceID(ServiceName.Unknown, MediaType.Unknown, -1);

            AlternateIDs = new List<ServiceID>();
            AiringStatus = UniversalServiceModels.AiringStatus.Unknown;
            WebUrl = new Uri("http://www.example.com", UriKind.Absolute);

            RomanjiTitle = "";
            EnglishTitle = "";
            KanjiTitle = "";
            EpisodeCount = 0;
            
            CoverImageUrl = new Uri("http://www.example.com", UriKind.Absolute);
            AgeRating = UniversalServiceModels.AgeRating.Unrated;
            Synopsis = "";
            MediaType = UniversalServiceModels.MediaType.Unknown;
            FavouriteID = 0;
            FavouriteRank = 0;
            Genres = new List<MediaGenre>();
        }
    }
}
