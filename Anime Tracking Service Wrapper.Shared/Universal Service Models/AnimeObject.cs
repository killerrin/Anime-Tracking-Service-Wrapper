using AnimeTrackingServiceWrapper.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.UniversalServiceModels
{
    public class AnimeObject : ModelBase
    {
        public ServiceName Service;

        #region Properties
        private ServiceID m_id;
        public ServiceID ID
        {
            get { return m_id; }
            set
            {
                if (m_id == value) return;
                m_id = value;
                RaisePropertyChanged(nameof(ID));
            }
        }

        private ServiceID m_id2;
        public ServiceID ID2
        {
            get { return m_id2; }
            set
            {
                if (m_id2 == value) return;
                m_id2 = value;
                RaisePropertyChanged(nameof(ID2));
            }
        }

        private List<ServiceID> m_alternateIDs = new List<ServiceID>();
        public List<ServiceID> AlternateIDs
        {
            get { return m_alternateIDs; }
            set
            {
                if (m_alternateIDs == value) return;
                m_alternateIDs = value;
                RaisePropertyChanged(nameof(AlternateIDs));
            }
        }

        private AiringStatus m_airingStatus = AiringStatus.Unknown;
        public AiringStatus AiringStatus
        {
            get { return m_airingStatus; }
            set
            {
                if (m_airingStatus == value) return;
                m_airingStatus = value;
                RaisePropertyChanged(nameof(AiringStatus));
            }
        }

        private Uri m_webUrl = new Uri("http://www.example.com", UriKind.Absolute);
        public Uri WebUrl
        {
            get { return m_webUrl; }
            set
            {
                if (m_webUrl == value) return;
                m_webUrl = value;
                RaisePropertyChanged(nameof(WebUrl));
            }
        }
        public string WebUrlString
        {
            get { return WebUrl.OriginalString; }
            set { if (!string.IsNullOrWhiteSpace(value)) WebUrl = new Uri(value, UriKind.Absolute); }
        }

        private string m_romanjiTitle = "";
        public string RomanjiTitle
        {
            get { return m_romanjiTitle; }
            set
            {
                if (m_romanjiTitle == value) return;
                m_romanjiTitle = value;
                RaisePropertyChanged(nameof(RomanjiTitle));
            }
        }

        private string m_englishTitle = "";
        public string EnglishTitle
        {
            get { return m_englishTitle; }
            set
            {
                if (m_englishTitle == value) return;
                m_englishTitle = value;
                RaisePropertyChanged(nameof(EnglishTitle));
            }
        }

        private string m_kanjiTitle = "";
        public string KanjiTitle
        {
            get { return m_kanjiTitle; }
            set
            {
                if (m_kanjiTitle == value) return;
                m_kanjiTitle = value;
                RaisePropertyChanged(nameof(KanjiTitle));
            }
        }

        private int m_episodeCount = 0;
        public int EpisodeCount
        {
            get { return m_episodeCount; }
            set
            {
                if (m_episodeCount == value) return;
                m_episodeCount = value;
                RaisePropertyChanged(nameof(EpisodeCount));
            }
        }

        private Uri m_coverImageUrl = new Uri("http://www.example.com", UriKind.Absolute);
        public Uri CoverImageUrl
        {
            get { return m_coverImageUrl; }
            set
            {
                if (m_coverImageUrl == value) return;
                if (value == null) return;

                m_coverImageUrl = value;
                RaisePropertyChanged(nameof(CoverImageUrl));
            }
        }

        public string CoverImageUrlString
        {
            get { return m_coverImageUrl.OriginalString; }
            set { if (!string.IsNullOrWhiteSpace(value)) CoverImageUrl = new Uri(value, UriKind.Absolute); }
        }

        private AgeRating m_ageRating = AgeRating.Unrated;
        public AgeRating AgeRating
        {
            get { return m_ageRating; }
            set
            {
                if (m_ageRating == value) return;
                m_ageRating = value;
                RaisePropertyChanged(nameof(AgeRating));
            }
        }

        private string m_synopsis = "";
        public string Synopsis
        {
            get { return m_synopsis; }
            set
            {
                if (m_synopsis == value) return;
                m_synopsis = value;
                RaisePropertyChanged(nameof(Synopsis));
            }
        }

        private MediaType m_mediaType = MediaType.Unknown;
        public MediaType MediaType
        {
            get { return m_mediaType; }
            set
            {
                if (m_mediaType == value) return;
                m_mediaType = value;
                RaisePropertyChanged(nameof(MediaType));
            }
        }

        private int m_favouriteRank = 0;
        public int FavouriteRank
        {
            get { return m_favouriteRank; }
            set
            {
                if (m_favouriteRank == value) return;
                m_favouriteRank = value;
                RaisePropertyChanged(nameof(FavouriteRank));
            }
        }

        private int m_favouriteID = 0;
        public int FavouriteID
        {
            get { return m_favouriteID; }
            set
            {
                if (m_favouriteID == value) return;
                m_favouriteID = value;
                RaisePropertyChanged(nameof(FavouriteID));
            }
        }

        private List<MediaGenre> m_genres = new List<MediaGenre>();
        public List<MediaGenre> Genres
        {
            get { return m_genres; }
            set
            {
                if (m_genres == value) return;
                m_genres = value;
                RaisePropertyChanged(nameof(Genres));
            }
        }
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
