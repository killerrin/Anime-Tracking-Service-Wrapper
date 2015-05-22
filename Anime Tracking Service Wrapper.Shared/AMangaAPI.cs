using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper
{
    public abstract class AMangaAPI
    {
        public AService Service { get; protected set; }
        public bool Supported { get; protected set; }

        public abstract void GetManga(string mangaID, IProgress<APIProgressReport> progress);
        public abstract void SearchManga(string mangaID, IProgress<APIProgressReport> progress);
        public abstract void GetMangaLibrary(IProgress<APIProgressReport> progress); // UserInfo, LibrarySection
        public abstract void RemoveMangaFromLibrary(string mangaID, IProgress<APIProgressReport> progress); // UserInfo, mangaID
    }
}
