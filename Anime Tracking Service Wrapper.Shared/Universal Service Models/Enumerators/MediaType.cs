﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.UniversalServiceModels
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
        DramaCD,
        AudioBook,

        // Other
        Special,
        Game,
        Other,
    }
}
