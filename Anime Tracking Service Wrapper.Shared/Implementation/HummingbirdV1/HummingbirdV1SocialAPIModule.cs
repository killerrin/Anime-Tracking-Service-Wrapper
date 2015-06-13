using AnimeTrackingServiceWrapper.Abstract;
using AnimeTrackingServiceWrapper.Helpers;
using AnimeTrackingServiceWrapper.Implementation.HummingbirdV1.Models;
using AnimeTrackingServiceWrapper.UniversalServiceModels;
using AnimeTrackingServiceWrapper.UniversalServiceModels.ActivityFeed;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AnimeTrackingServiceWrapper.Implementation.HummingbirdV1
{
    public class HummingbirdV1SocialAPIModule : ASocialAPIModule
    {
        public HummingbirdV1SocialAPIModule(AService service)
            : base()
        {
            Service = service;
            Supported = true;
        }

        public override async Task<List<AActivityFeedItem>> GetActivityFeed(string username, int paginationIndex, IProgress<APIProgressReport> progress)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                if (progress != null)
                    progress.Report(new APIProgressReport(100.0, "Please enter a Username", APIResponse.Failed));
                return new List<AActivityFeedItem>();
            }

            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, Service.CreateAPIServiceUri("/users/" + username + "/feed?page=" + paginationIndex));
            HttpResponseMessage response = await APIWebClient.MakeAPICall(requestMessage);
   
            if (response.IsSuccessStatusCode)
            {
                string responseAsString = await response.Content.ReadAsStringAsync();

                if (progress != null)
                    progress.Report(new APIProgressReport(50.0, "Recieved Activity Feed From Server", APIResponse.ContinuingExecution));

                JObject o = JObject.Parse("{\"status_feed\":" + responseAsString + "}");
                StoryObjectListHummingbirdV1 activityFeedRaw = JsonConvert.DeserializeObject<StoryObjectListHummingbirdV1>(o.ToString());

                List<AActivityFeedItem> convertedActivityFeed = new List<AActivityFeedItem>();
                foreach(var aFO in activityFeedRaw.status_feed)
                {
                    string tts = aFO.updated_at.Substring(0, aFO.updated_at.Length - 1);
                    string[] tS = tts.Split('T');

                    UserInfo user = new UserInfo();
                    DateTime timestamp;
                    if (!DateTime.TryParse(tts, out timestamp))
                        timestamp = DateTime.MinValue;

                    if (aFO.story_type == "comment")
                    {
                        user.Username = aFO.poster.name;
                        user.AvatarUrl = new Uri(aFO.poster.avatar, UriKind.Absolute);

                        convertedActivityFeed.Add(new ActivityFeedComment(user, aFO.substories[0].comment, timestamp));
                    }
                    else if (aFO.story_type == "media_story")
                    {
                        user.Username = aFO.user.name;
                        user.AvatarUrl = new Uri(aFO.user.avatar, UriKind.Absolute);

                        string intelligibleString = "";
                        if (aFO.substories[0].substory_type == "watchlist_status_update")
                        {
                            LibrarySection librarySection = Converters.LibrarySectionConverter.StringToLibrarySelection(aFO.substories[0].new_status);
                            intelligibleString = user.Username + " " + Converters.LibrarySectionConverter.LibrarySelectionToIntelligableString(librarySection);
                        }
                        else if (aFO.substories[0].substory_type == "watched_episode")
                        {
                            intelligibleString = user.Username + " watched episode " + aFO.substories[0].episode_number;
                        }

                        ServiceID mediaID = new ServiceID(ServiceName.Hummingbird, MediaType.Anime, aFO.media.slug);
                        Uri activityFeedImage = new Uri(aFO.media.cover_image, UriKind.Absolute);
                    }
                    
                }

                if (progress != null)
                    progress.Report(new APIProgressReport(100.0, "Converted Successfully", APIResponse.Successful, convertedActivityFeed, activityFeedRaw));
                return convertedActivityFeed;
            }

            if (progress != null)
                progress.Report(new APIProgressReport(100.0, "API Call wasn't successul", APIResponse.Failed));
            return new List<AActivityFeedItem>();
        }

        public override async Task<AActivityFeedItem> PostStatusUpdate(UserLoginInfo userLoginInfo, string message, IProgress<APIProgressReport> progress)
        {
            if (progress != null)
                progress.Report(new APIProgressReport(100.0, "API Call is not supported on the V1 API", APIResponse.NotSupported));
            return null;

            if (progress != null)
                progress.Report(new APIProgressReport(100.0, "API Call wasn't successul", APIResponse.Failed));
            return null;
        }
    }
}
