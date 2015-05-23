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
                JObject o = JObject.Parse(responseAsString);
                AnimeObjectHummingbirdV1 animeObject = JsonConvert.DeserializeObject<AnimeObjectHummingbirdV1>(o.ToString());

                if (progress != null)
                    progress.Report(new APIProgressReport(50.0, "Recieved Anime From Server", APIResponse.ContinuingExecution));

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
                JObject o = JObject.Parse(responseAsString);
                List<AnimeObjectHummingbirdV1> hummingbirdSearchResults = JsonConvert.DeserializeObject<List<AnimeObjectHummingbirdV1>>(o.ToString());

                if (progress != null)
                    progress.Report(new APIProgressReport(50.0, "Recieved Search Results From Server", APIResponse.ContinuingExecution));

                List<AnimeObject> convertedSearchResults = new List<AnimeObject>();
                foreach (var anime in hummingbirdSearchResults)
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
                JObject o = JObject.Parse(responseAsString);
                List<LibraryObjectHummingbirdV1> hummingbirdLibraryObjects = JsonConvert.DeserializeObject<List<LibraryObjectHummingbirdV1>>(o.ToString());

                if (progress != null)
                    progress.Report(new APIProgressReport(50.0, "Recieved LibraryObjects From Server", APIResponse.ContinuingExecution));

                List<LibraryObject> convertedLibraryObjects = new List<LibraryObject>();
                foreach (var libraryObject in hummingbirdLibraryObjects)
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

        public override async Task<APIResponse> RemoveAnimeFromLibrary(UserInfo userInfo, string animeID, IProgress<APIProgressReport> progress)
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
    }
}
