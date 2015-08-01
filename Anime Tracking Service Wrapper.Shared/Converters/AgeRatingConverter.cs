using AnimeTrackingServiceWrapper.UniversalServiceModels;
using System;
using System.Collections.Generic;
using System.Text;
#if !DESKTOP
using Windows.UI.Xaml.Data;
#endif

namespace AnimeTrackingServiceWrapper.Converters
{
    public class AgeRatingConverter
#if !DESKTOP
        : IValueConverter
#endif
    {
        public static AgeRating StringToAgeRating(string ageRatingString)
        {
            switch (ageRatingString)
            {
                case "G":           return AgeRating.G;
                case "PG":          return AgeRating.PG;
                case "PG13":        return AgeRating.PG13;
                case "R17+":        return AgeRating.R17;
                case "R18+":        return AgeRating.R18;
                case "Unknown":
                case "Unrated":
                default:            return AgeRating.Unrated;
            }
        }

        public static string AgeRatingToString(AgeRating ageRating)
        {
            switch (ageRating)
            {
                case AgeRating.G:           return "G";
                case AgeRating.PG:          return "PG";
                case AgeRating.PG13:        return "PG13";
                case AgeRating.R17:         return "R17+";
                case AgeRating.R18:         return "R18+";
                case AgeRating.Unrated:
                default:                    return "Unrated";
            }
        }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is AgeRating)
                return AgeRatingToString((AgeRating)value);
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value is string)
                return StringToAgeRating((string)value);
            return AgeRating.Unrated;
        }
    }
}
