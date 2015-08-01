using AnimeTrackingServiceWrapper.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AnimeTrackingServiceWrapper.UniversalServiceModels
{
    public class ServiceID : ModelBase
    {
        private ServiceName m_service = ServiceName.Unknown;
        public ServiceName Service
        {
            get { return m_service; }
            set
            {
                m_service = value;
                RaisePropertyChanged("Service");
            }
        }

        private MediaType m_mediaType = MediaType.Unknown; 
        public MediaType MediaType
        {
            get { return m_mediaType; }
            set {
                m_mediaType = value;
                RaisePropertyChanged("MediaType");
            }
        }

        private string m_id = "";
        public string ID
        {
            get { return m_id; }
            set
            {
                if (m_id == value) return;
                m_id = value;
                RaisePropertyChanged("ID");
            }
        }

        public int IDAsInt { 
            get
            {
                if (!string.IsNullOrWhiteSpace(ID)) return Int32.Parse(ID);
                return 0;
            }
            set { ID = value.ToString(); RaisePropertyChanged("IDAsInt"); }
        }

        public ServiceID(ServiceName name, MediaType mediaType, string id)
        {
            Service = name;
            MediaType = mediaType;
            ID = id;
        }
        public ServiceID(ServiceName name, MediaType mediaType, int id)
        {
            Service = name;
            MediaType = mediaType;
            ID = id.ToString();
        }

        public override string ToString()
        {
            return Service.ToString() + " | " + MediaType.ToString() + " | " + ID;
        }
    }
}
