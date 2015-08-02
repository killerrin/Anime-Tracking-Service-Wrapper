using AnimeTrackingServiceWrapper.Helpers;
using AnimeTrackingServiceWrapper.UniversalServiceModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnimeTrackingServiceWrapper.Abstract
{
    public abstract class AService : ModelBase
    {
        private string m_domain = "";
        public string Domain
        {
            get { return m_domain; }
            protected set
            {
                //if (m_domain == value) return;
                m_domain = value;
                RaisePropertyChanged(nameof(Domain));
            }
        }

        private string m_apiKey = "";
        public string APIKey
        {
            get { return m_apiKey; }
            protected set
            {
                //if (m_apiKey == value) return;
                m_apiKey = value;
                RaisePropertyChanged(nameof(APIKey));
            }
        }

        private AAnimeAPI m_animeAPI;
        public AAnimeAPI AnimeAPI
        {
            get { return m_animeAPI; }
            set
            {
                //if (m_animeAPI == value) return;
                m_animeAPI = value;
                RaisePropertyChanged(nameof(AnimeAPI));
            }
        }

        private AMangaAPI m_mangaAPI;
        public AMangaAPI MangaAPI
        {
            get { return m_mangaAPI; }
            protected set
            {
                //if (m_mangaAPI == value) return;
                m_mangaAPI = value;
                RaisePropertyChanged(nameof(MangaAPI));
            }
        }

        public abstract Task<UserLoginInfo> Login(string username, string password, IProgress<APIProgressReport> progress, string otherAuth = "");
        public abstract Task<UserInfo> GetUserInfo(string username, IProgress<APIProgressReport> progress);

        public Uri CreateAPIServiceUri(string endpoint) { return new Uri(Domain + endpoint, UriKind.Absolute); }
    }
}
