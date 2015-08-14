using AnimeTrackingServiceWrapper.Universal_Service_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public double Percentage { get; set; }
        public string StatusMessage { get; set; }
        public APIResponse CurrentAPIResonse { get; set; }

        public ConvertedRawAPICoupler Parameter { get; set; }

        public APIProgressReport(double percentage, string statusMessage, APIResponse apiResponse)
        {
            Percentage = percentage;
            StatusMessage = statusMessage;
            CurrentAPIResonse = apiResponse;
            Parameter = new ConvertedRawAPICoupler();
        }
        public APIProgressReport(double percentage, string statusMessage, APIResponse apiResponse, ConvertedRawAPICoupler parameter)
        {
            Percentage = percentage;
            StatusMessage = statusMessage;
            CurrentAPIResonse = apiResponse;
            Parameter = parameter;
        }
        public APIProgressReport(double percentage, string statusMessage, APIResponse apiResponse, object convertedParameter, object rawParameter)
        {
            Percentage = percentage;
            StatusMessage = statusMessage;
            CurrentAPIResonse = apiResponse;
            Parameter = new ConvertedRawAPICoupler(convertedParameter, rawParameter);
        }

        public override string ToString()
        {
            return string.Format("{0} | {1}, {2}", CurrentAPIResonse, Percentage, StatusMessage);
        }
    }
}
