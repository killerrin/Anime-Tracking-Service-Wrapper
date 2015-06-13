using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.Abstract
{
    public class AAPIModule
    {
        public AService Service { get; protected set; }
        public bool Supported { get; protected set; }
    }
}
