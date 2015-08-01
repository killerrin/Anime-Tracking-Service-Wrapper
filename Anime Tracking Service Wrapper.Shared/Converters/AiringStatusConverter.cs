using AnimeTrackingServiceWrapper.UniversalServiceModels;
using System;
using System.Collections.Generic;
using System.Text;
#if !DESKTOP
using Windows.UI.Xaml.Data;
#endif

namespace AnimeTrackingServiceWrapper.Converters
{
    public class AiringStatusConverter
#if !DESKTOP
        : IValueConverter
#endif
    {
        public static AiringStatus StringToAiringStatus(string airingStatusString)
        {
            if (string.IsNullOrWhiteSpace(airingStatusString)) return AiringStatus.Unknown;

            switch (airingStatusString)
            {
                case "Not Yet Aired":
                case "NotYetAired": return AiringStatus.NotYetAired;

                case "Currently Airing":
                case "CurrentlyAiring": return AiringStatus.CurrentlyAiring;

                case "Finished Airing":
                case "FinishedAiring": return AiringStatus.FinishedAiring;

                case "None":
                case "Unknown":
                default: return AiringStatus.Unknown;
            }
        }

        public static string AiringStatusToString(AiringStatus airingStatus)
        {
            switch (airingStatus)
            {
                case AiringStatus.Unknown:              return "Unknown";
                case AiringStatus.NotYetAired:          return "Not Yet Aired";
                case AiringStatus.CurrentlyAiring:      return "Currently Airing";
                case AiringStatus.FinishedAiring:       return "Finished Airing";
                default:                                return "";
            }
        }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is AiringStatus)
                return AiringStatusToString((AiringStatus)value);
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value is string)
                return StringToAiringStatus((string)value);
            return AiringStatus.Unknown;
        }
    }
}
