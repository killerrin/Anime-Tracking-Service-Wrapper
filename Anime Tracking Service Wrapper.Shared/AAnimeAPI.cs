﻿using AnimeTrackingServiceWrapper.Service_Structures;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnimeTrackingServiceWrapper
{
    public abstract class AAnimeAPI
    {
        public AService Service { get; protected set; }
        public bool Supported { get; protected set; }

        public abstract Task<AnimeObject> GetAnime(string animeID, IProgress<APIProgressReport> progress);
        public abstract void SearchAnime(string animeID, IProgress<APIProgressReport> progress);
        public abstract void GetAnimeLibrary(IProgress<APIProgressReport> progress); // UserInfo, LibrarySection
        public abstract void RemoveAnimeFromLibrary(string animeID, IProgress<APIProgressReport> progress); // UserInfo, animeID
    }
}
