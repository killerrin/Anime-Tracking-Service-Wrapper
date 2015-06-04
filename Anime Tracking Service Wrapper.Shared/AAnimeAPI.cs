using AnimeTrackingServiceWrapper.Service_Structures;
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
        public abstract Task<List<AnimeObject>> SearchAnime(string searchTerm, IProgress<APIProgressReport> progress);
        public abstract Task<List<LibraryObject>> GetAnimeLibrary(string username, LibrarySection section, IProgress<APIProgressReport> progress);
        public abstract Task<APIResponse> RemoveAnimeFromLibrary(UserLoginInfo userInfo, string animeID, IProgress<APIProgressReport> progress);
        public abstract Task<APIResponse> UpdateAnimeInLibrary(UserLoginInfo userInfo, LibraryObject libraryObject, IProgress<APIProgressReport> progress);
    }
}
