using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.UniversalServiceModels
{
    public struct ServiceID
    {
        public ServiceName Service;
        public MediaType MediaType;

        public string ID;
        public int IDAsInt { 
            get
            {
                if (!string.IsNullOrWhiteSpace(ID)) return Int32.Parse(ID);
                return 0;
            }
            set { ID = value.ToString(); }
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
