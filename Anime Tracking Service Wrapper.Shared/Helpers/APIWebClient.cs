using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AnimeTrackingServiceWrapper.Helpers
{
    public static class APIWebClient
    {
        public static async Task<HttpResponseMessage> MakeAPICall(this HttpRequestMessage requestMessage)
        {
            // Create a client
            HttpClient httpClient = new HttpClient();

            // Send a Message
            HttpResponseMessage response = await httpClient.SendAsync(requestMessage);

            // Send back the Response Message
            return response;
        }
    }
}
