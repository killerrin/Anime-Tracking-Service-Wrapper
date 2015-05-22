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
                    progress.Report(new APIProgressReport(100.0, "Incorrect Anime ID", APIResponse.Failed));
                return new AnimeObject();
            }

            /// ------------------------------------------------ ///
            /// Double Check if _anime string is API Compliant.  ///
            /// ------------------------------------------------ ///
            string animeSearchTerm = animeID.ConvertToAPIConpliantString(' ', '-');

            // Create and Send the Request Message
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, Service.CreateAPIServiceUri("/anime/" + animeSearchTerm));
            HttpResponseMessage response = await APIWebClient.MakeAPICall(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                string responseAsString = await response.Content.ReadAsStringAsync();
                JObject o = JObject.Parse(responseAsString); // This would be the string you defined above
                AnimeObjectHummingbirdV1 animeObject = JsonConvert.DeserializeObject<AnimeObjectHummingbirdV1>(o.ToString()); ;

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
