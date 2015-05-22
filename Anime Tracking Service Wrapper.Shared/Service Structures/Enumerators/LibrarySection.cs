using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.Service_Structures
{
    public enum LibrarySection
    {
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
