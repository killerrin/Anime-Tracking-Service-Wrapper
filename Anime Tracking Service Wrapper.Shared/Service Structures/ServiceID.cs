using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.Service_Structures
{
    public struct ServiceID
    {
        public ServiceName Service;

        public string ID;
        public int IDAsInt { 
            get
            {
                if (!string.IsNullOrWhiteSpace(ID)) return Int32.Parse(ID);
                return 0;
            } 
        }

        public ServiceID(ServiceName name, string id)
        {
            Service = name;
            ID = id;
        }
        public ServiceID(ServiceName name, int id)
        {
            Service = name;
            ID = id.ToString();
        }
    }
}
