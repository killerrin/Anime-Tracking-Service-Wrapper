using AnimeTrackingServiceWrapper.UniversalServiceModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnimeTrackingServiceWrapper.Abstract
{
    public abstract class AAnimeAPI : AAPIModule
    {
        public abstract Task<AnimeObject> GetAnime(string animeID, IProgress<APIProgressReport> progress);
        public abstract Task<List<AnimeObject>> SearchAnime(string searchTerm, IProgress<APIProgressReport> progress);
        public abstract Task<List<LibraryObject>> GetAnimeLibrary(string username, LibrarySection section, IProgress<APIProgressReport> progress);
        public abstract Task<APIResponse> RemoveAnimeFromLibrary(UserLoginInfo userInfo, string animeID, IProgress<APIProgressReport> progress);
        public abstract Task<APIResponse> UpdateAnimeInLibrary(UserLoginInfo userInfo, LibraryObject libraryObject, IProgress<APIProgressReport> progress);
        public abstract Task<List<AnimeObject>> GetAnimeFavourites(string username, IProgress<APIProgressReport> progress);

    }
}
