using AnimeTrackingServiceWrapper.UniversalServiceModels;
using System;
using System.Collections.Generic;
using System.Text;
#if !DESKTOP
using Windows.UI.Xaml.Data;
#endif

namespace AnimeTrackingServiceWrapper.Converters
{
    public class LibrarySectionConverter
#if !DESKTOP
        : IValueConverter
#endif
    {
        public static LibrarySection StringToLibrarySection(string librarySectionString)
        {
            string libSectionLower = librarySectionString.ToLower();

            switch (libSectionLower)
            {
                case "currently-watching": case "watching": case "currently watching":  return LibrarySection.CurrentlyWatching;
                case "currently-reading":  case "reading":  case "currently reading":   return LibrarySection.CurrentlyReading;

                case "plan-to-watch": case "plan to watch": case "plantowatch":     return LibrarySection.PlanToWatch;
                case "plan-to-read": case "plan to read": case "plantoread":        return LibrarySection.PlanToRead;

                case "completed":               return LibrarySection.Completed;
                case "on-hold": case "onhold": case "on hold":  return LibrarySection.OnHold;
                case "dropped":                 return LibrarySection.Dropped;

                case "favourite": case "favourites": case "favorites": case "favorite": return LibrarySection.Favourites;
                case "recent":                  return LibrarySection.Recent;
                case "search":                  return LibrarySection.Search;

                case "all":                     return LibrarySection.All;

                case "none":
                default:                        return LibrarySection.None;
            }
        }

        public static string LibrarySectionToString(LibrarySection librarySection)
        {
            switch (librarySection)
            {
                case LibrarySection.CurrentlyWatching:        return "currently-watching";
                case LibrarySection.CurrentlyReading:         return "currently-reading";

                case LibrarySection.PlanToWatch:              return "plan-to-watch";
                case LibrarySection.PlanToRead:               return "plan-to-read";

                case LibrarySection.Completed:                return "completed";
                case LibrarySection.OnHold:                   return "on-hold";
                case LibrarySection.Dropped:                  return "dropped";

                case LibrarySection.All:
                case LibrarySection.Favourites:
                case LibrarySection.Recent:
                case LibrarySection.Search:
                case LibrarySection.None:
                default:
                    return "";
            }
        }

        public static string LibrarySectionToIntelligableStatusString(LibrarySection librarySection)
        {
            switch (librarySection)
            {
                case LibrarySection.CurrentlyWatching:        return "is currently watching";
                case LibrarySection.CurrentlyReading:         return "is currently reading";

                case LibrarySection.PlanToWatch:              return "plans to watch";
                case LibrarySection.PlanToRead:               return "plans to read";

                case LibrarySection.Completed:                return "has completed";
                case LibrarySection.OnHold:                   return "has placed on hold";
                case LibrarySection.Dropped:                  return "has dropped";

                case LibrarySection.Favourites:               return "has favourited";

                case LibrarySection.All:
                case LibrarySection.Recent:
                case LibrarySection.Search:
                case LibrarySection.None:
                default:
                    return "has added to library";// + LibrarySectionToIntelligableString(librarySection);
            }
        }

        public static string LibrarySectionToIntelligableString(LibrarySection librarySection)
        {
            switch (librarySection)
            {
                case LibrarySection.CurrentlyWatching: return "Currently Watching";
                case LibrarySection.CurrentlyReading: return "Currently Reading";

                case LibrarySection.PlanToWatch: return "Plan to Watch";
                case LibrarySection.PlanToRead: return "Plan to Read";

                case LibrarySection.Completed: return "Completed";
                case LibrarySection.OnHold: return "On Hold";
                case LibrarySection.Dropped: return "Dropped";

                case LibrarySection.Favourites: return "Favourite";

                case LibrarySection.All:
                case LibrarySection.Recent:
                case LibrarySection.Search:
                case LibrarySection.None:
                default:
                    return librarySection.ToString();
            }
        }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is LibrarySection)
                return LibrarySectionToIntelligableString((LibrarySection)value);
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value is string)
                return StringToLibrarySection((string)value);
            return LibrarySection.None;
        }
    }
}
