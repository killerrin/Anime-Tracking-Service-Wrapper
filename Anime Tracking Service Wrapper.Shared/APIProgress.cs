using AnimeTrackingServiceWrapper.Universal_Service_Models;
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

        public ConvertedRawAPICoupler Parameter;

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
    }
}
