﻿using AnimeTrackingServiceWrapper.UniversalServiceModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnimeTrackingServiceWrapper.Abstract
{
    public abstract class AService
    {
        public string Domain { get; protected set; }
        public string APIKey;

        public AAnimeAPI AnimeAPI;
        public AMangaAPI MangaAPI;

        public abstract Task<UserLoginInfo> Login(string username, string password, IProgress<APIProgressReport> progress, string otherAuth = "");
        public abstract Task<UserInfo> GetUserInfo(string username, IProgress<APIProgressReport> progress);

        public Uri CreateAPIServiceUri(string endpoint) { return new Uri(Domain + endpoint, UriKind.Absolute); }
    }
}
