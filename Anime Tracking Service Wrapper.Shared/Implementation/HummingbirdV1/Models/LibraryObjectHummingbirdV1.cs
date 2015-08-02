using AnimeTrackingServiceWrapper.Helpers;
using AnimeTrackingServiceWrapper.UniversalServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.Implementation.HummingbirdV1.Models
{
    public class LibraryObjectHummingbirdV1 : ModelBase
    {
        private int m_id = 0;
        public int id
        {
            get { return m_id; }
            set
            {
                m_id = value;
                RaisePropertyChanged(nameof(id));
            }
        }

        private int m_episodes_watched = 0;
        public int episodes_watched
        {
            get { return m_episodes_watched; }
            set
            {
                m_episodes_watched = value;
                RaisePropertyChanged(nameof(episodes_watched));
            }
        }

        private string m_last_watched = "";
        public string last_watched
        {
            get { return m_last_watched; }
            set
            {
                m_last_watched = value;
                RaisePropertyChanged(nameof(last_watched));
            }
        }

        private string m_updated_at = "";
        public string updated_at
        {
            get { return m_updated_at; }
            set
            {
                m_updated_at = value;
                RaisePropertyChanged(nameof(updated_at));
            }
        }

        private int m_rewatched_times = 0;
        public int rewatched_times
        {
            get { return m_rewatched_times; }
            set
            {
                m_rewatched_times = value;
                RaisePropertyChanged(nameof(rewatched_times));
            }
        }

        private string m_notes = "";
        public string notes
        {
            get { return m_notes; }
            set
            {
                m_notes = value;
                RaisePropertyChanged(nameof(notes));
            }
        }

        private bool? m_notes_present = false;
        public bool? notes_present
        {
            get { return m_notes_present; }
            set
            {
                m_notes_present = value;
                RaisePropertyChanged(nameof(notes_present));
            }
        }

        private string m_status = "";
        public string status
        {
            get { return m_status; }
            set
            {
                m_status = value;
                RaisePropertyChanged(nameof(status));
            }
        }

        private bool m_private = false;
        public bool @private
        {
            get { return m_private; }
            set
            {
                m_private = value;
                RaisePropertyChanged(nameof(@private));
            }
        }

        private bool m_rewatching = false;
        public bool rewatching
        {
            get { return m_rewatching; }
            set
            {
                m_rewatching = value;
                RaisePropertyChanged(nameof(rewatching));
            }
        }

        private AnimeObjectHummingbirdV1 m_anime = new AnimeObjectHummingbirdV1();
        public AnimeObjectHummingbirdV1 anime
        {
            get { return m_anime; }
            set
            {
                m_anime = value;
                RaisePropertyChanged(nameof(anime));
            }
        }

        private RatingHummingbirdV1 m_rating = new RatingHummingbirdV1();
        public RatingHummingbirdV1 rating
        {
            get { return m_rating; }
            set
            {
                m_rating = value;
                RaisePropertyChanged(nameof(rating));
            }
        }

        public static explicit operator LibraryObject(LibraryObjectHummingbirdV1 oldObject)
        {
            LibraryObject libraryObject = new LibraryObject();
            libraryObject.Service = ServiceName.Hummingbird;

            libraryObject.Anime                     = (AnimeObject)oldObject.anime;
            libraryObject.EpisodesWatched           = oldObject.episodes_watched;

            DateTime _lastWatched;
            if (DateTime.TryParse(oldObject.last_watched, out _lastWatched))
            {
                libraryObject.LastWatched           = _lastWatched;
            }

            if (string.IsNullOrWhiteSpace(oldObject.notes))
                libraryObject.Notes                 = "";
            else
                libraryObject.Notes                 = oldObject.notes;

            libraryObject.Private                   = Converters.PrivacySettingsConverter.BoolToPrivacySettings(oldObject.@private);
            libraryObject.Rating                    = Convert.ToDouble(oldObject.rating.value);
            libraryObject.RewatchedTimes            = oldObject.rewatched_times;
            libraryObject.Rewatching                = oldObject.rewatching;
            libraryObject.Section                   = Converters.LibrarySectionConverter.StringToLibrarySection(oldObject.status);

            return libraryObject;
        }
    }

    public class LibraryObjectListHummingbirdV1
    {
        public List<LibraryObjectHummingbirdV1> library { get; set; }

        public static implicit operator List<LibraryObjectHummingbirdV1>(LibraryObjectListHummingbirdV1 libraryObject)
        {
            return libraryObject.library;
        }
    }
}
