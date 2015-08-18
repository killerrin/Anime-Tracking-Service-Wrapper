using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.UniversalServiceModels
{
    public class ConvertedRawAPICoupler
    {
        public object Converted;
        public object Raw;

        public bool HasConvertedData { get { return Converted != null; } }
        public bool HasRawData { get { return Raw != null; } }

        public ConvertedRawAPICoupler() { }
        public ConvertedRawAPICoupler(object converted, object raw)
        {
            Converted = converted;
            Raw = raw;
        }
    }
}
