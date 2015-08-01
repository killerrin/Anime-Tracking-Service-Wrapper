using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AnimeTrackingServiceWrapper.Helpers
{
    public class ModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string property = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
