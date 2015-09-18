using AnimeTrackingServiceWrapper.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AnimeTrackingServiceWrapper.UniversalServiceModels
{
    public class ServiceID : ModelBase
    {
        [JsonIgnore]
        public static ServiceID Empty { get { return new ServiceID(); } }

        private ServiceName m_service = ServiceName.Unknown;
        public ServiceName Service
        {
            get { return m_service; }
            set
            {
                m_service = value;
                RaisePropertyChanged(nameof(Service));
            }
        }

        private MediaType m_mediaType = MediaType.Unknown; 
        public MediaType MediaType
        {
            get { return m_mediaType; }
            set {
                m_mediaType = value;
                RaisePropertyChanged(nameof(MediaType));
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
                RaisePropertyChanged(nameof(ID));
            }
        }

        [JsonIgnore]
        public int IDAsInt { 
            get
            {
                if (!string.IsNullOrWhiteSpace(ID)) return Int32.Parse(ID);
                return 0;
            }
            set { ID = value.ToString(); RaisePropertyChanged(nameof(IDAsInt)); }
        }

        public ServiceID()
        {

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

        public override bool Equals(object obj)
        {
            if (obj is ServiceID) return Equals((ServiceID)obj);
            return false;
        }

        public bool Equals(ServiceID id)
        {
            if (m_id == id.ID) return true;
            return false;
        }
    }
}
