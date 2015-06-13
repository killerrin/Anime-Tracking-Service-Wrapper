using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.Abstract
{
    public abstract class AMangaAPI : AAPIModule
    {
        public abstract void GetManga(string mangaID, IProgress<APIProgressReport> progress);
        public abstract void SearchManga(string searchTerm, IProgress<APIProgressReport> progress);
        public abstract void GetMangaLibrary(IProgress<APIProgressReport> progress); // UserInfo, LibrarySection
        public abstract void RemoveMangaFromLibrary(string mangaID, IProgress<APIProgressReport> progress); // UserInfo, mangaID
    }
}
