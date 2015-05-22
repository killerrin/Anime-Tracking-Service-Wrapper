using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.Implementation.HummingbirdV1
{
    public class HummingbirdV1AnimeAPI : AAnimeAPI
    {
        public HummingbirdV1AnimeAPI(AService service)
            : base()
        {
            Service = service;
            Supported = true;
        }

        public override async void GetAnime(string animeID, IProgress<APIProgressReport> progress)
        {
            throw new NotImplementedException();
        }

        public override async void SearchAnime(string animeID, IProgress<APIProgressReport> progress)
        {
            throw new NotImplementedException();
        }

        public override async void GetAnimeLibrary(IProgress<APIProgressReport> progress)
        {
            throw new NotImplementedException();
        }

        public override async void RemoveAnimeFromLibrary(string animeID, IProgress<APIProgressReport> progress)
        {
            throw new NotImplementedException();
        }
    }
}
