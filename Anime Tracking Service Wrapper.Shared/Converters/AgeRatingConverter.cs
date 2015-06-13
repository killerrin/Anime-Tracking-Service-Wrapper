using AnimeTrackingServiceWrapper.UniversalServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.Converters
{
    public static class AgeRatingConverter
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
    }
}
