using AnimeTrackingServiceWrapper.Service_Structures;
using AnimeTrackingServiceWrapper.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using AnimeTrackingServiceWrapper.Implementation.HummingbirdV1.Data_Structures;
using Newtonsoft.Json;

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

        public override async Task<AnimeObject> GetAnime(string animeID, IProgress<APIProgressReport> progress)
        {
            if (string.IsNullOrWhiteSpace(animeID))
            {
                if (progress != null)
                    progress.Report(new APIProgressReport(100.0, "Please enter an AnimeID", APIResponse.Failed));
                return new AnimeObject();
            }

            string compliantAnimeID = animeID.ConvertToAPIConpliantString(' ', '-');

            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, Service.CreateAPIServiceUri("/anime/" + compliantAnimeID + "?title_language_preference=romanized"));
            HttpResponseMessage response = await APIWebClient.MakeAPICall(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                string responseAsString = await response.Content.ReadAsStringAsync();

                if (progress != null)
                    progress.Report(new APIProgressReport(50.0, "Recieved Anime From Server", APIResponse.ContinuingExecution));

                JObject o = JObject.Parse(responseAsString);
                AnimeObjectHummingbirdV1 animeObject = JsonConvert.DeserializeObject<AnimeObjectHummingbirdV1>(o.ToString());

                AnimeObject convertedAnimeObject = (AnimeObject)animeObject;

                if (progress != null)
                    progress.Report(new APIProgressReport(100.0, "Converted Successfully", APIResponse.Successful, convertedAnimeObject));
                return convertedAnimeObject;
            }

            if (progress != null)
                progress.Report(new APIProgressReport(100.0, "API Call wasn't successul", APIResponse.Failed));
            return new AnimeObject();
        }

        public override async Task<List<AnimeObject>> SearchAnime(string searchTerm, IProgress<APIProgressReport> progress)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                if (progress != null)
                    progress.Report(new APIProgressReport(100.0, "Please enter Search Terms", APIResponse.Failed));
                return new List<AnimeObject>();
            }

            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, Service.CreateAPIServiceUri("/search/anime?query=" + searchTerm));
            HttpResponseMessage response = await APIWebClient.MakeAPICall(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                string responseAsString = await response.Content.ReadAsStringAsync();

                if (progress != null)
                    progress.Report(new APIProgressReport(50.0, "Recieved Search Results From Server", APIResponse.ContinuingExecution));

                JObject o = JObject.Parse("{\"anime\":" + responseAsString + "}");
                AnimeObjectListHummingbirdV1 hummingbirdSearchResults = JsonConvert.DeserializeObject<AnimeObjectListHummingbirdV1>(o.ToString());

                List<AnimeObject> convertedSearchResults = new List<AnimeObject>();
                foreach (var anime in hummingbirdSearchResults.anime)
                {
                    convertedSearchResults.Add((AnimeObject)anime);
                }

                if (progress != null)
                    progress.Report(new APIProgressReport(100.0, "Converted Successfully", APIResponse.Successful, convertedSearchResults));
                return convertedSearchResults;
            }

            if (progress != null)
                progress.Report(new APIProgressReport(100.0, "API Call wasn't successul", APIResponse.Failed));
            return new List<AnimeObject>();
        }

        public override async Task<List<LibraryObject>> GetAnimeLibrary(string username, LibrarySection section, IProgress<APIProgressReport> progress)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                if (progress != null)
                    progress.Report(new APIProgressReport(100.0, "Please enter a Username", APIResponse.Failed));
                return new List<LibraryObject>();
            }

            string statusString = Converters.LibrarySectionConverter.LibrarySelectionToString(section);
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, Service.CreateAPIServiceUri("/users/" + username + "/library?status=" + statusString));
            HttpResponseMessage response = await APIWebClient.MakeAPICall(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                string responseAsString = await response.Content.ReadAsStringAsync();

                if (progress != null)
                    progress.Report(new APIProgressReport(50.0, "Recieved LibraryObjects From Server", APIResponse.ContinuingExecution));

                JObject o = JObject.Parse("{\"library\":" + responseAsString + "}");
                LibraryObjectListHummingbirdV1 hummingbirdLibraryObjects = JsonConvert.DeserializeObject<LibraryObjectListHummingbirdV1>(o.ToString());

                List<LibraryObject> convertedLibraryObjects = new List<LibraryObject>();
                foreach (var libraryObject in hummingbirdLibraryObjects.library)
                {
                    convertedLibraryObjects.Add((LibraryObject)libraryObject);
                }

                if (progress != null)
                    progress.Report(new APIProgressReport(100.0, "Converted Successfully", APIResponse.Successful, convertedLibraryObjects));
                return convertedLibraryObjects;
            }

            if (progress != null)
                progress.Report(new APIProgressReport(100.0, "API Call wasn't successul", APIResponse.Failed));
            return new List<LibraryObject>();

        }

        public override async Task<APIResponse> RemoveAnimeFromLibrary(UserLoginInfo userInfo, string animeID, IProgress<APIProgressReport> progress)
        {
            if (!userInfo.IsLoggedInUser)
            {
                if (progress != null)
                    progress.Report(new APIProgressReport(100.0, "This user is not logged in", APIResponse.Failed));
                return APIResponse.Failed;
            }
            if (string.IsNullOrWhiteSpace(animeID))
            {
                if (progress != null)
                    progress.Report(new APIProgressReport(100.0, "Please enter an AnimeID", APIResponse.Failed));
                return APIResponse.Failed;
            }

            string compliantAnimeID = animeID.ConvertToAPIConpliantString(' ', '-');

            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, Service.CreateAPIServiceUri("/libraries/" + compliantAnimeID + "/remove"));
            requestMessage.Headers.Add("accept", "application/json");
            requestMessage.Content = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string,string>("auth_token", userInfo.AuthToken),//Consts.settings.auth_token),
                    });

            HttpResponseMessage response = await APIWebClient.MakeAPICall(requestMessage);
            if (response.IsSuccessStatusCode)
            {
                if (progress != null)
                    progress.Report(new APIProgressReport(100.0, "Anime Removed", APIResponse.Successful, APIResponse.Successful));
                return APIResponse.Successful;
            }

            if (progress != null)
                progress.Report(new APIProgressReport(100.0, "API Call wasn't successul", APIResponse.Failed));
            return APIResponse.Failed;
        }

        public override async Task<APIResponse> UpdateAnimeInLibrary(UserLoginInfo userInfo, LibraryObject libraryObject, IProgress<APIProgressReport> progress)
        {
            if (!userInfo.IsLoggedInUser)
            {
                if (progress != null)
                    progress.Report(new APIProgressReport(100.0, "This user is not logged in", APIResponse.Failed));
                return APIResponse.Failed;
            }
            if (libraryObject == null)
            {
                if (progress != null)
                    progress.Report(new APIProgressReport(100.0, "Please supply a valid LibraryObject", APIResponse.Failed));
                return APIResponse.Failed;
            }
            if (libraryObject.Anime == null)
            {
                if (progress != null)
                    progress.Report(new APIProgressReport(100.0, "There is no valid AnimeObject attacked to the LibraryObject", APIResponse.Failed));
                return APIResponse.Failed;
            }

            string compliantAnimeID = libraryObject.Anime.ID.ID.ConvertToAPIConpliantString(' ', '-');
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, Service.CreateAPIServiceUri("/libraries/" + compliantAnimeID));
            requestMessage.Headers.Add("accept", "application/json");
            requestMessage.Content = new FormUrlEncodedContent(new[]
                        {
                            new KeyValuePair<string,string>("auth_token", userInfo.AuthToken),
                            new KeyValuePair<string,string>("status", Converters.LibrarySectionConverter.LibrarySelectionToString(libraryObject.Section)),
                            new KeyValuePair<string,string>("privacy", Converters.PrivacySettingsConverter.PrivacySettingsToString(libraryObject.Private)), // Can be "public", "private"
                            new KeyValuePair<string,string>("sane_rating_update", libraryObject.Rating.ToString()), // none = None Selected, 0-2 = Unhappy, 3 = Neutral, 4-5 = Happy
                            //new KeyValuePair<string,string>("rewatching", (false.ToString()).ToLower()),
                            new KeyValuePair<string,string>("rewatched_times", libraryObject.RewatchedTimes.ToString()),
                            new KeyValuePair<string,string>("notes", libraryObject.Notes),
                            new KeyValuePair<string,string>("episodes_watched", libraryObject.EpisodesWatched.ToString()),
                            new KeyValuePair<string,string>("increment_episodes", (false.ToString()).ToLower())
                        });
            HttpResponseMessage response = await APIWebClient.MakeAPICall(requestMessage);
            if (response.IsSuccessStatusCode)
            {
                if (progress != null)
                    progress.Report(new APIProgressReport(100.0, "Anime Removed", APIResponse.Successful, APIResponse.Successful));
                return APIResponse.Successful;
            }

            if (progress != null)
                progress.Report(new APIProgressReport(100.0, "API Call wasn't successul", APIResponse.Failed));
            return APIResponse.Failed;
        }
    }
}
