using AnimeTrackingServiceWrapper.Helpers;
using AnimeTrackingServiceWrapper.Universal_Service_Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.Implementation.HummingbirdV1.Models
{
    public class CalendarDatasetHummingbird_Undocumented : ModelBase
    {
        private string m_title = "";
        public string title
        {
            get { return m_title; }
            set
            {
                m_title = value;
                RaisePropertyChanged(nameof(title));
            }
        }

        private string m_sdate = "";
        public string sdate
        {
            get { return m_sdate; }
            set
            {
                m_sdate = value;
                RaisePropertyChanged(nameof(sdate));
            }
        }

        private int m_episd = 0;
        public int episd
        {
            get { return m_episd; }
            set
            {
                m_episd = value;
                RaisePropertyChanged(nameof(episd));
            }
        }

        public static explicit operator CalendarEntry(CalendarDatasetHummingbird_Undocumented dataset)
        {
            CalendarEntry entry = new CalendarEntry();

            // Set the Title/Miscellaneous
            entry.Title = dataset.title;

            // Parse the Date
            DateTime date;
            if (DateTime.TryParse(dataset.sdate, out date))
                entry.Date = date;
            else entry.Date = new DateTime();

            return entry;
        }
    }

    public class CalendarRootHummingbird_Undocumented : ModelBase
    {
        private bool m_success = false;
        public bool success
        {
            get { return m_success; }
            set
            {
                m_success = value;
                RaisePropertyChanged(nameof(success));
            }
        }

        private List<CalendarDatasetHummingbird_Undocumented> m_dataset = new List<CalendarDatasetHummingbird_Undocumented>();
        public List<CalendarDatasetHummingbird_Undocumented> dataset
        {
            get { return m_dataset; }
            set
            {
                m_dataset = value;
                RaisePropertyChanged(nameof(dataset));
            }
        }
    }
}
