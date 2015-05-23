using AnimeTrackingServiceWrapper.Helpers;
using AnimeTrackingServiceWrapper.Service_Structures;
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
        public HummingbirdV1Service(string apiKey)
            :base()
        {
            Domain = "https://hummingbird.me/api/v1";
            APIKey = apiKey;


            AnimeAPI = new HummingbirdV1AnimeAPI(this);
            MangaAPI = new HummingbirdV1MangaAPI(this);
        }

        public override async Task<UserInfo> Login(string username, string password, IProgress<APIProgressReport> progress, string otherAuth = "")
        {
            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
            {
                if (progress != null)
                    progress.Report(new APIProgressReport(100.0, "Please type in your username/password", APIResponse.InfoNotEntered));
                return new UserInfo();
            }
            if (username.Contains("@"))
            {
                if (progress != null)
                    progress.Report(new APIProgressReport(100.0, "Logging in through Email is not supported yet. Please use your Username", APIResponse.NotSupported));
                return new UserInfo();
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

                UserInfo userInfo = new UserInfo(username, password, userAuthToken);
                if (progress != null)
                    progress.Report(new APIProgressReport(100.0, "Successfully Logged In", APIResponse.Successful, userInfo));

                return userInfo;
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

            return new UserInfo();
        }
    }
}
