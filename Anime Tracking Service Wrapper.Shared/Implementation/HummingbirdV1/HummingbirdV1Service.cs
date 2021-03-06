﻿using AnimeTrackingServiceWrapper.Abstract;
using AnimeTrackingServiceWrapper.Helpers;
using AnimeTrackingServiceWrapper.Implementation.HummingbirdV1.Models;
using AnimeTrackingServiceWrapper.UniversalServiceModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AnimeTrackingServiceWrapper.Implementation.HummingbirdV1
{
    public class HummingbirdV1Service : AService
    {
        public readonly HummingbirdV1SocialAPIModule SocialAPI;
        public readonly HummingbirdV1CalendarAPIModule CalendarAPI;

        public HummingbirdV1Service(string apiKey)
            :base()
        {
            Domain = "https://hummingbird.me/api/v1";
            APIKey = apiKey;

            AnimeAPI = new HummingbirdV1AnimeAPI(this);
            MangaAPI = new HummingbirdV1MangaAPI(this);
            SocialAPI = new HummingbirdV1SocialAPIModule(this);
            CalendarAPI = new HummingbirdV1CalendarAPIModule(this);
        }

        public override async Task<UserLoginInfo> Login(string username, string password, IProgress<APIProgressReport> progress, string otherAuth = "")
        {
            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
            {
                if (progress != null)
                    progress.Report(new APIProgressReport(100.0, "Please type in your username/password", APIResponse.InfoNotEntered));
                return new UserLoginInfo();
            }
            if (username.Contains("@"))
            {
                if (progress != null)
                    progress.Report(new APIProgressReport(100.0, "Logging in through Email is not supported yet. Please use your Username", APIResponse.NotSupported));
                return new UserLoginInfo();
            }

            if (progress != null)
                progress.Report(new APIProgressReport(10.0, "Username/Password Okay", APIResponse.ContinuingExecution));

            // Create the Request Message
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, CreateAPIServiceUri("/users/authenticate/"));
            requestMessage.Headers.Add("accept", "application/json");
            requestMessage.Content = new FormUrlEncodedContent(new[]
                                                {
                                                    new KeyValuePair<string,string>("username", username),
                                                    new KeyValuePair<string,string>("password", password)
                                                });

            // Make the API Call
            HttpResponseMessage response = await APIWebClient.MakeAPICall(requestMessage);
            if (response.IsSuccessStatusCode)
            {
                if (progress != null)
                    progress.Report(new APIProgressReport(50.0, "Login Authorized", APIResponse.ContinuingExecution));

                string responseAsString = await response.Content.ReadAsStringAsync();

                //Parse the responseAsString to remove ""'s
                string userAuthToken = "";
                char[] txtarr = responseAsString.ToCharArray();
                foreach (char c in txtarr)
                {
                    switch (c)
                    {
                        case '"':
                            break;
                        default:
                            userAuthToken += c;
                            break;
                    }
                }

                UserLoginInfo userLoginInfo = new UserLoginInfo(username, password, userAuthToken, LoginMethod.Username);
                if (progress != null)
                    progress.Report(new APIProgressReport(100.0, "Successfully Logged In", APIResponse.Successful, userLoginInfo, userLoginInfo));

                return userLoginInfo;
            }

            if (await response.Content.ReadAsStringAsync() == "{\"error\":\"Invalid credentials\"}")
            {
                if (progress != null)
                    progress.Report(new APIProgressReport(100.0, "Invalid Login Credidentials", APIResponse.InvalidCredentials));
            }
            else
            {
                if (progress != null)
                    progress.Report(new APIProgressReport(100.0, "Error connecting to hummingbird.me. Try again later", APIResponse.InvalidCredentials));
            }

            return new UserLoginInfo();
        }

        public override async Task<UserInfo> GetUserInfo(string username, IProgress<APIProgressReport> progress)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                if (progress != null)
                    progress.Report(new APIProgressReport(100.0, "Please enter a Username", APIResponse.Failed));
                return new UserInfo();
            }

            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, CreateAPIServiceUri("/users/" + username));
            HttpResponseMessage response = await APIWebClient.MakeAPICall(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                string responseAsString = await response.Content.ReadAsStringAsync();

                if (progress != null)
                    progress.Report(new APIProgressReport(50.0, "Recieved User From Server", APIResponse.ContinuingExecution));

                JObject o = JObject.Parse(responseAsString);
                UserObjectHummingbirdV1 rawUserInfo = JsonConvert.DeserializeObject<UserObjectHummingbirdV1>(o.ToString());

                UserInfo convertedUserInfo = (UserInfo)rawUserInfo;

                if (progress != null)
                    progress.Report(new APIProgressReport(100.0, "Converted Successfully", APIResponse.Successful, convertedUserInfo, rawUserInfo));
                return convertedUserInfo;
            }

            if (progress != null)
                progress.Report(new APIProgressReport(100.0, "API Call wasn't successul", APIResponse.Failed));
            return new UserInfo();
        }

        public override async Task<List<UserInfo>> SearchUsers(string searchTerms, IProgress<APIProgressReport> progress)
        {
            if (string.IsNullOrWhiteSpace(searchTerms))
            {
                if (progress != null)
                    progress.Report(new APIProgressReport(100.0, "Please enter a search", APIResponse.Failed));
                return new List<UserInfo>();
            }

            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, "https://hummingbird.me/search.json?depth=full&scope=users&query=" + searchTerms);
            HttpResponseMessage response = await APIWebClient.MakeAPICall(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                string responseAsString = await response.Content.ReadAsStringAsync();

                if (progress != null)
                    progress.Report(new APIProgressReport(50.0, "Recieved User From Server", APIResponse.ContinuingExecution));

                JObject o = JObject.Parse(responseAsString);
                UserSearchHummingbird_UndocumentedV1 rawUserSearch = JsonConvert.DeserializeObject<UserSearchHummingbird_UndocumentedV1>(o.ToString());

                List<UserInfo> convertedSearchResult = new List<UserInfo>();
                foreach (var searchResult in rawUserSearch.search)
                {
                    if (searchResult.type != "user") continue;
                    UserInfo user = new UserInfo();
                    user.AvatarUrl = new Uri(searchResult.image, UriKind.Absolute);
                    user.Username = searchResult.title;
                    user.Biography = searchResult.desc;
                    convertedSearchResult.Add(user);
                }

                if (progress != null)
                    progress.Report(new APIProgressReport(100.0, "Converted Successfully", APIResponse.Successful, convertedSearchResult, rawUserSearch));
                return convertedSearchResult;
            }

            if (progress != null)
                progress.Report(new APIProgressReport(100.0, "API Call wasn't successul", APIResponse.Failed));
            return new List<UserInfo>();
        }
    }
}
