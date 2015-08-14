using AnimeTrackingServiceWrapper.UniversalServiceModels;
using System;
using System.Collections.Generic;
using System.Text;
#if !DESKTOP
using Windows.UI.Xaml.Data;
#endif

namespace AnimeTrackingServiceWrapper.Converters
{
    public class ServiceNameConverter
#if !DESKTOP
        : IValueConverter
#endif
    {
        public static ServiceName StringToServiceName(string serviceNameString)
        {
            switch (serviceNameString)
            {
                case "Hummingbird":                         return ServiceName.Hummingbird;
                case "MyAnimeList": case "My Anime List":   return ServiceName.MyAnimeList;
                case "Unknown":
                default: return ServiceName.Unknown;
            }
        }

        public static string ServiceNameToString(ServiceName serviceName)
        {
            switch (serviceName)
            {
                case ServiceName.Hummingbird:   return "Hummingbird";
                case ServiceName.MyAnimeList:   return "MyAnimeList";
                case ServiceName.Unknown:
                default: return "Unknown";
            }
        }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is ServiceName)
                return ServiceNameToString((ServiceName)value);
            return "Unknown";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value is string)
                return StringToServiceName((string)value);
            return ServiceName.Unknown;
        }
    }
}
