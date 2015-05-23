using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.Implementation.HummingbirdV1
{
    public class HummingbirdV1MangaAPI : AMangaAPI
    {
        public HummingbirdV1MangaAPI(AService service)
            : base()
        {
            Service = service;
            Supported = false;
        }


        public override void GetManga(string mangaID, IProgress<APIProgressReport> progress)
        {
            if (progress != null)
                progress.Report(new APIProgressReport(100.0, "", APIResponse.NotSupported));
        }

        public override void SearchManga(string searchTerm, IProgress<APIProgressReport> progress)
        {
            if (progress != null)
                progress.Report(new APIProgressReport(100.0, "", APIResponse.NotSupported));
        }

        public override void GetMangaLibrary(IProgress<APIProgressReport> progress)
        {
            if (progress != null)
                progress.Report(new APIProgressReport(100.0, "", APIResponse.NotSupported));
        }

        public override void RemoveMangaFromLibrary(string mangaID, IProgress<APIProgressReport> progress)
        {
            if (progress != null)
                progress.Report(new APIProgressReport(100.0, "", APIResponse.NotSupported));
        }
    }
}
