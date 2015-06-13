using AnimeTrackingServiceWrapper.UniversalServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.Implementation.HummingbirdV1.Models
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
            libraryObject.Section                   = Converters.LibrarySectionConverter.StringToLibrarySelection(oldObject.status);

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
