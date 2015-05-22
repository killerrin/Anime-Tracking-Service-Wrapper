using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.Service_Structures
{
    public enum MediaType
    {
        Unknown,

        // Anime
        Anime,
        TV,
        OVA,
        OAV,
        Movie,

        // Manga
        Manga,
        LightNovel,

        // Audio
        Music,
        Soundtrack,
        CharacterCD,
        AudioBook,

        // Other
        Special,
        Game,
        Other,
    }
}
