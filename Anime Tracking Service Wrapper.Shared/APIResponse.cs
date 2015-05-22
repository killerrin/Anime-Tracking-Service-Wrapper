using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper
{
    public enum APIResponse
    {
        ContinuingExecution,
        Successful,
        Failed,

        //-- Standard Errors
        APIError,
        NetworkError,
        ServerError,
        UnknownError,

        //-- Specialized Errors
        NotSupported,
        InvalidAuthorizationKey,

        // Login
        InfoNotEntered,
        InvalidCredentials,
    }
}
