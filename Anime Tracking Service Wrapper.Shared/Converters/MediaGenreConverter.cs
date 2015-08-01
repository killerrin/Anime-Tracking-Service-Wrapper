using AnimeTrackingServiceWrapper.UniversalServiceModels;
using System;
using System.Collections.Generic;
using System.Text;
#if !DESKTOP
using Windows.UI.Xaml.Data;
#endif

namespace AnimeTrackingServiceWrapper.Converters
{
    public class MediaGenreConverter
#if !DESKTOP
        : IValueConverter
#endif
    {
        public static MediaGenre StringToMediaGenre(string genreString)
        {
            if (string.IsNullOrWhiteSpace(genreString)) return MediaGenre.None;

            switch (genreString)
            {
                case "Action": return MediaGenre.Action;
                case "Adventure": return MediaGenre.Adventure;
                case "Anime Influenced": return MediaGenre.AnimeInfluenced;
                case "Cars": return MediaGenre.Cars;
                case "Comedy": return MediaGenre.Comedy;
                case "Dementia": return MediaGenre.Dementia;
                case "Demons": return MediaGenre.Demons;
                case "Drama": return MediaGenre.Drama;
                case "Ecchi": return MediaGenre.Ecchi;
                case "Fantasy": return MediaGenre.Fantasy;
                case "Game": return MediaGenre.Game;
                case "Harem": return MediaGenre.Harem;
                case "Historical": return MediaGenre.Historical;
                case "Horror": return MediaGenre.Horror;
                case "Kids": return MediaGenre.Kids;
                case "Magic": return MediaGenre.Magic;
                case "Martial Arts": return MediaGenre.MartialArts;
                case "Mecha": return MediaGenre.Mecha;
                case "Military": return MediaGenre.Military;
                case "Music": return MediaGenre.Music;
                case "Mystery": return MediaGenre.Mystery;
                case "Parody": return MediaGenre.Parody;
                case "Psychological": return MediaGenre.Psychological;
                case "Romance": return MediaGenre.Romance;
                case "Samurai": return MediaGenre.Samurai;
                case "School": return MediaGenre.School;
                case "Sci-Fi": return MediaGenre.SciFi;
                case "Shoujo Ai": return MediaGenre.ShoujoAi;
                case "Shounen Ai": return MediaGenre.ShounenAi;
                case "Slice of Life": return MediaGenre.SliceOfLife;
                case "Space": return MediaGenre.Space;
                case "Sports": return MediaGenre.Sports;
                case "Supernatural": return MediaGenre.Supernatural;
                case "Super Power": return MediaGenre.SuperPower;
                case "Thriller": return MediaGenre.Thriller;
                case "Vampire": return MediaGenre.Vampire;
                case "None":
                case "Unknown":
                default: return MediaGenre.Unknown;
            }
        }

        public static string MediaGenreToString(MediaGenre genre)
        {
            switch (genre)
            {
                case MediaGenre.Unknown:               return MediaGenre.Unknown.ToString();
                case MediaGenre.Action:                return MediaGenre.Action.ToString();
                case MediaGenre.Adventure:             return MediaGenre.Adventure.ToString();;
                case MediaGenre.AnimeInfluenced:       return "Anime Influenced";
                case MediaGenre.Cars:                  return MediaGenre.Cars.ToString();
                case MediaGenre.Comedy:                return MediaGenre.Comedy.ToString();
                case MediaGenre.Dementia:              return MediaGenre.Dementia.ToString();
                case MediaGenre.Demons:                return MediaGenre.Demons.ToString();
                case MediaGenre.Drama:                 return MediaGenre.Drama.ToString();
                case MediaGenre.Ecchi:                 return MediaGenre.Ecchi.ToString();
                case MediaGenre.Fantasy:               return MediaGenre.Fantasy.ToString();
                case MediaGenre.Game:                  return MediaGenre.Game.ToString();
                case MediaGenre.Harem:                 return MediaGenre.Harem.ToString();
                case MediaGenre.Historical:            return MediaGenre.Historical.ToString();
                case MediaGenre.Horror:                return MediaGenre.Horror.ToString();
                case MediaGenre.Kids:                  return MediaGenre.Kids.ToString();
                case MediaGenre.Magic:                 return MediaGenre.Magic.ToString();
                case MediaGenre.MartialArts:           return "Martial Arts";
                case MediaGenre.Mecha:                 return MediaGenre.Mecha.ToString();
                case MediaGenre.Military:              return MediaGenre.Military.ToString();
                case MediaGenre.Music:                 return MediaGenre.Music.ToString();
                case MediaGenre.Mystery:               return MediaGenre.Mystery.ToString();
                case MediaGenre.Parody:                return MediaGenre.Parody.ToString();
                case MediaGenre.Psychological:         return MediaGenre.Psychological.ToString();
                case MediaGenre.Romance:               return MediaGenre.Romance.ToString();
                case MediaGenre.Samurai:               return MediaGenre.Samurai.ToString();
                case MediaGenre.School:                return MediaGenre.School.ToString();
                case MediaGenre.SciFi:                 return MediaGenre.SciFi.ToString();
                case MediaGenre.ShoujoAi:              return "Shoujo Ai";
                case MediaGenre.ShounenAi:             return "Shounen Ai";
                case MediaGenre.SliceOfLife:           return "Slice Of Life";
                case MediaGenre.Space:                 return MediaGenre.Space.ToString();
                case MediaGenre.Sports:                return MediaGenre.Sports.ToString();
                case MediaGenre.Supernatural:          return MediaGenre.Supernatural.ToString();
                case MediaGenre.SuperPower:            return "Super Power";
                case MediaGenre.Thriller:              return MediaGenre.Thriller.ToString();
                case MediaGenre.Vampire:               return MediaGenre.Vampire.ToString();

                case MediaGenre.None:
                default:                               return "";
            }
        }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is MediaGenre)
                return MediaGenreToString((MediaGenre)value);
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value is string)
                return StringToMediaGenre((string)value);
            return MediaGenre.None;
        }
    }
}
