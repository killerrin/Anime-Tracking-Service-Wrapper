using AnimeTrackingServiceWrapper.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.Abstract
{
    public class AAPIModule : ModelBase
    {
        private AService m_service;
        public AService Service
        {
            get { return m_service; }
            protected set
            {
                //if (m_service == value) return;
                m_service = value;
                RaisePropertyChanged(nameof(Service));
            }
        }

        private bool m_supported = false;
        public bool Supported
        {
            get { return m_supported; }
            protected set
            {
                //if (m_supported == value) return;
                m_supported = value;
                RaisePropertyChanged(nameof(Supported));
            }
        }
    }
}
