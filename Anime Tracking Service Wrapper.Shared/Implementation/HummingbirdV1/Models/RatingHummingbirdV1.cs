using AnimeTrackingServiceWrapper.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.Implementation.HummingbirdV1.Models
{
    public class RatingHummingbirdV1 : ModelBase
    {
        private string m_type = "";
        public string type
        {
            get { return m_type; }
            set
            {
                m_type = value;
                RaisePropertyChanged(nameof(type));
            }
        }

        private string m_value = "";
        public string value
        {
            get { return m_value; }
            set
            {
                m_value = value;
                RaisePropertyChanged(nameof(value));
            }
        }
    }
}
