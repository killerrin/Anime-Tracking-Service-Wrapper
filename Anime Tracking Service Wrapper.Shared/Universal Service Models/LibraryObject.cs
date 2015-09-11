using AnimeTrackingServiceWrapper.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.UniversalServiceModels
{
    public class LibraryObject : ModelBase
    {
        private ServiceName m_service = ServiceName.Unknown;
        public ServiceName Service
        {
            get { return m_service; }
            set
            {
                if (m_service == value) return;
                m_service = value;
                RaisePropertyChanged(nameof(Service));
            }
        }

        #region Properties
        private int m_rewatchedTimes = 0;
        public int RewatchedTimes
        {
            get { return m_rewatchedTimes; }
            set
            {
                if (m_rewatchedTimes == value) return;
                m_rewatchedTimes = value;
                RaisePropertyChanged(nameof(RewatchedTimes));
            }
        }

        private int m_episodesWatched = 0;
        public int EpisodesWatched
        {
            get { return m_episodesWatched; }
            set
            {
                if (m_episodesWatched == value) return;
                m_episodesWatched = value;
                RaisePropertyChanged(nameof(EpisodesWatched));
            }
        }

        private PrivacySettings m_private = PrivacySettings.Public;
        public PrivacySettings Private
        {
            get { return m_private; }
            set
            {
                if (m_private == value) return;
                m_private = value;
                RaisePropertyChanged(nameof(Private));
            }
        }

        private bool m_rewatching = false;
        public bool Rewatching
        {
            get { return m_rewatching; }
            set
            {
                if (m_rewatching == value) return;
                m_rewatching = value;
                RaisePropertyChanged(nameof(Rewatching));
            }
        }

        private double m_rating = 0.0;
        public double Rating
        {
            get { return m_rating; }
            set
            {
                if (m_rating == value) return;
                m_rating = value;
                RaisePropertyChanged(nameof(Rating));
            }
        }

        private string m_notes = "";
        public string Notes
        {
            get { return m_notes; }
            set
            {
                if (m_notes == value) return;
                m_notes = value;
                RaisePropertyChanged(nameof(Notes));
            }
        }

        private DateTime m_lastWatched = DateTime.MinValue;
        public DateTime LastWatched
        {
            get { return m_lastWatched; }
            set
            {
                if (m_lastWatched == value) return;
                m_lastWatched = value;
                RaisePropertyChanged(nameof(LastWatched));
            }
        }

        private LibrarySection m_section = LibrarySection.None;
        public LibrarySection Section
        {
            get { return m_section; }
            set
            {
                if (m_section == value) return;
                m_section = value;
                RaisePropertyChanged(nameof(Section));
            }
        }

        private AnimeObject m_anime;
        public AnimeObject Anime
        {
            get { return m_anime; }
            set
            {
                if (m_anime == value) return;
                m_anime = value;
                RaisePropertyChanged(nameof(Anime));
            }
        }
        #endregion

        public LibraryObject()
        {

        }

        public LibraryObject(AnimeObject anime)
        {
            Anime = anime;
            Service = Anime.Service;
        }
    }
}
