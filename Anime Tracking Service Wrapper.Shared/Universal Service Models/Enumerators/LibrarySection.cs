using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.UniversalServiceModels
{
    public enum LibrarySection
    {
        All,
        None,

        // Anime
        CurrentlyWatching,
        PlanToWatch,

        // Manga
        CurrentlyReading,
        PlanToRead,

        // Universal
        Completed,
        OnHold,
        Dropped,

        // Extra
        Favourites,
        Recent,
        Search,
    }
}
