using AnimeTrackingServiceWrapper.Service_Structures;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnimeTrackingServiceWrapper
{
    public abstract class AService
    {
        public string Domain { get; protected set; }
        public string APIKey;

        public AAnimeAPI AnimeAPI;
        public AMangaAPI MangaAPI;

        public abstract Task<UserLoginInfo> Login(string username, string password, IProgress<APIProgressReport> progress, string otherAuth = "");

        public Uri CreateAPIServiceUri(string endpoint) { return new Uri(Domain + endpoint, UriKind.Absolute); }
    }
}
