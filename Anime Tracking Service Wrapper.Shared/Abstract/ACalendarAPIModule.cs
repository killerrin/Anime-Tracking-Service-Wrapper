using AnimeTrackingServiceWrapper.Universal_Service_Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnimeTrackingServiceWrapper.Abstract
{
    public abstract class ACalendarAPIModule : AAPIModule
    {
        public abstract Task<List<CalendarEntry>> GetCalendar(string username, IProgress<APIProgressReport> progress);
    }
}
