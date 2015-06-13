using AnimeTrackingServiceWrapper.UniversalServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.Converters
{
    public static class LibrarySectionConverter
    {
        public static LibrarySection StringToLibrarySelection(string librarySectionString)
        {
            switch (librarySectionString)
            {
                case "currently-watching":      return LibrarySection.CurrentlyWatching;
                case "currently-reading":       return LibrarySection.CurrentlyReading;

                case "plan-to-watch":           return LibrarySection.PlanToWatch;
                case "plan-to-read":            return LibrarySection.PlanToRead;

                case "completed":               return LibrarySection.Completed;
                case "on-hold":                 return LibrarySection.OnHold;
                case "dropped":                 return LibrarySection.Dropped;

                case "favourites":              return LibrarySection.Favourites;
                case "recent":                  return LibrarySection.Recent;
                case "search":                  return LibrarySection.Search;

                case "all":                     return LibrarySection.All;
                default:                        return LibrarySection.None;
            }
        }

        public static string LibrarySelectionToString(LibrarySection librarySection)
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

        public static string LibrarySelectionToIntelligableString(LibrarySection librarySection)
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
                    return "";
            }
        }
    }
}
