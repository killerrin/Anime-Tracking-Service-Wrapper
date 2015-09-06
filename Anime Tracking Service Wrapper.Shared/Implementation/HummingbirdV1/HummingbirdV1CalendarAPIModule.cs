using AnimeTrackingServiceWrapper.Abstract;
using AnimeTrackingServiceWrapper.Helpers;
using AnimeTrackingServiceWrapper.Implementation.HummingbirdV1.Models;
using AnimeTrackingServiceWrapper.Universal_Service_Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AnimeTrackingServiceWrapper.Implementation.HummingbirdV1
{
    public class HummingbirdV1CalendarAPIModule : ACalendarAPIModule
    {
        public HummingbirdV1CalendarAPIModule(AService service)
            : base()
        {
            Service = service;
            Supported = true;
        }

        public override async Task<List<CalendarEntry>> GetCalendar(string username, IProgress<APIProgressReport> progress)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                if (progress != null)
                    progress.Report(new APIProgressReport(100.0, "Please enter a Username", APIResponse.Failed));
                return new List<CalendarEntry>();
            }

            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, "http://cal.hb.cybrox.eu/api.php?user=" + username);
            HttpResponseMessage response = await APIWebClient.MakeAPICall(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                string responseAsString = await response.Content.ReadAsStringAsync();

                if (progress != null)
                    progress.Report(new APIProgressReport(50.0, "Received Calendar Feed From Server", APIResponse.ContinuingExecution));

                // Parse the Raw Entries
                JObject o = JObject.Parse(responseAsString);
                CalendarRootHummingbird_Undocumented rawCalendarInfo = JsonConvert.DeserializeObject<CalendarRootHummingbird_Undocumented>(o.ToString()); ;

                // Now convert them to the universal entries
                List<CalendarEntry> convertedCalendarEntryList = new List<CalendarEntry>();
                foreach (var entry in rawCalendarInfo.dataset)
                {
                    convertedCalendarEntryList.Add((CalendarEntry)entry);
                }

                if (progress != null)
                    progress.Report(new APIProgressReport(100.0, "Converted Successfully", APIResponse.Successful, convertedCalendarEntryList, rawCalendarInfo));
                return convertedCalendarEntryList;
            }

            if (progress != null)
                progress.Report(new APIProgressReport(100.0, "API Call wasn't successful", APIResponse.Failed));
            return new List<CalendarEntry>();
        }
    }
}
