using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper
{
    public class APIProgress : Progress<APIProgressReport>
    {
        public APIProgress()
            :base()
        {
        }

        public APIProgress(Action<APIProgressReport> handler)
            :base(handler)
        {
        }
    }
    
    public struct APIProgressReport
    {
        public double Percentage;
        public string StatusMessage;
        public APIResponse CurrentAPIResonse;

        public object Parameter;

        public APIProgressReport(double percentage, string statusMessage, APIResponse apiResponse)
        {
            Percentage = percentage;
            StatusMessage = statusMessage;
            CurrentAPIResonse = apiResponse;

            Parameter = null;
        }
        public APIProgressReport(double percentage, string statusMessage, APIResponse apiResponse, object parameter)
        {
            Percentage = percentage;
            StatusMessage = statusMessage;
            CurrentAPIResonse = apiResponse;
            Parameter = parameter;
        }
    }
}
