using AnimeTrackingServiceWrapper.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using AnimeTrackingServiceWrapper.Implementation.HummingbirdV1.Models;

namespace AnimeTrackingServiceWrapper.Universal_Service_Models
{
    public class CalendarEntry : ModelBase
    {
        private string m_title = "";
        public string Title
        {
            get { return m_title; }
            set
            {
                if (m_title == value) return;
                m_title = value;
                RaisePropertyChanged(nameof(Title));
            }
        }

        private DateTime m_date = new DateTime();
        public DateTime Date
        {
            get { return m_date; }
            set
            {
                if (m_date == value) return;
                m_date = value;
                RaisePropertyChanged(nameof(Date));
            }
        }
    }
}
