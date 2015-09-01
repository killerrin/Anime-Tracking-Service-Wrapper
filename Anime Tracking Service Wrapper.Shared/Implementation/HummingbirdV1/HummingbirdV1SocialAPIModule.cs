using AnimeTrackingServiceWrapper.Abstract;
using AnimeTrackingServiceWrapper.Helpers;
using AnimeTrackingServiceWrapper.Implementation.HummingbirdV1.Models;
using AnimeTrackingServiceWrapper.UniversalServiceModels;
using AnimeTrackingServiceWrapper.UniversalServiceModels.ActivityFeed;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public override async Task<ObservableCollection<AActivityFeedItem>> GetActivityFeed(string username, int paginationIndex, IProgress<APIProgressReport> progress)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                if (progress != null)
                    progress.Report(new APIProgressReport(100.0, "Please enter a Username", APIResponse.Failed));
                return new ObservableCollection<AActivityFeedItem>();
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

                ObservableCollection<AActivityFeedItem> convertedActivityFeed = new ObservableCollection<AActivityFeedItem>();
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
                            LibrarySection librarySection = Converters.LibrarySectionConverter.StringToLibrarySection(aFO.substories[0].new_status);
                            intelligibleString = user.Username + " " + Converters.LibrarySectionConverter.LibrarySectionToIntelligableStatusString(librarySection);
                        }
                        else if (aFO.substories[0].substory_type == "watched_episode")
                        {
                            intelligibleString = user.Username + " watched episode " + aFO.substories[0].episode_number;
                        }

                        ServiceID mediaID = new ServiceID(ServiceName.Hummingbird, MediaType.Anime, aFO.media.slug);
                        Uri activityFeedImage = new Uri(aFO.media.cover_image, UriKind.Absolute);
                        convertedActivityFeed.Add(new ActivityFeedMediaUpdate(user, mediaID, activityFeedImage, aFO.media.title, intelligibleString, timestamp));
                    }
                    
                }

                if (progress != null)
                    progress.Report(new APIProgressReport(100.0, "Converted Successfully", APIResponse.Successful, convertedActivityFeed, activityFeedRaw));
                return convertedActivityFeed;
            }

            if (progress != null)
                progress.Report(new APIProgressReport(100.0, "API Call wasn't successul", APIResponse.Failed));
            return new ObservableCollection<AActivityFeedItem>();
        }

        /// <summary>
        /// Doesn't Work
        /// </summary>
        /// <param name="senderUserLoginInfo">The Senders LoginInfo</param>
        /// <param name="senderUserInfo">The Senders UserInfo</param>
        /// <param name="receiverUserInfo">The Recievers UserInfo</param>
        /// <param name="message">The Message to post</param>
        /// <param name="progress">To report progress and completion</param>
        /// <returns></returns>
        public override async Task<AActivityFeedItem> PostStatusUpdate(UserLoginInfo senderUserLoginInfo, UserInfo senderUserInfo, UserInfo receiverUserInfo, string message, IProgress<APIProgressReport> progress)
        {
            #region Early Exits
            if (!senderUserLoginInfo.IsUserLoggedIn)
            {
                if (progress != null)
                    progress.Report(new APIProgressReport(100.0, "You must be logged in to use this feature", APIResponse.Failed));
                return null;
            }

            if (senderUserInfo != null)
            {
                if (string.IsNullOrWhiteSpace(senderUserInfo.Username))
                {
                    if (progress != null)
                        progress.Report(new APIProgressReport(100.0, "Sender UserInfo has no Username", APIResponse.Failed));
                    return null;
                }
            }
            else
            {
                if (progress != null)
                    progress.Report(new APIProgressReport(100.0, "Sender UserInfo is Null", APIResponse.Failed));
                return null;
            }

            if (receiverUserInfo != null)
            {
                if (string.IsNullOrWhiteSpace(receiverUserInfo.Username))
                {
                    if (progress != null)
                        progress.Report(new APIProgressReport(100.0, "Receiver UserInfo has no Username", APIResponse.Failed));
                    return null;
                }
            }
            else
            {
                if (progress != null)
                    progress.Report(new APIProgressReport(100.0, "Receiver UserInfo is Null", APIResponse.Failed));
                return null;
            }

            if (string.IsNullOrWhiteSpace(message))
            {
                if (progress != null)
                    progress.Report(new APIProgressReport(100.0, "Please enter a status message", APIResponse.Failed));
                return null;
            }
            #endregion

            // Post
            // https://hummingbird.me/stories
            // Content
            //

            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, "http://hummingbird.me/users/" + receiverUserInfo.Username + "/comment.json");
            requestMessage.Headers.Add("accept", "application/json");
            requestMessage.Content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string,string>("auth_token", senderUserLoginInfo.AuthToken),
                    new KeyValuePair<string,string>("comment", message),
                });
            HttpResponseMessage response = await APIWebClient.MakeAPICall(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                string responseAsString = await response.Content.ReadAsStringAsync();

                ActivityFeedComment comment = new ActivityFeedComment(senderUserInfo, message, DateTime.UtcNow);
                if (progress != null)
                    progress.Report(new APIProgressReport(100.0, "Converted Successfully", APIResponse.Successful, comment, comment));
                return comment;
            }

            if (progress != null)
                progress.Report(new APIProgressReport(100.0, "API Call wasn't successul", APIResponse.Failed));
            return null;
        }
    }
}
