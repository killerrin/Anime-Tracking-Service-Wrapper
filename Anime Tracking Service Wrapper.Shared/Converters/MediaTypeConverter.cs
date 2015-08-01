using AnimeTrackingServiceWrapper.UniversalServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

#if !DESKTOP
using Windows.UI.Xaml.Data;
#endif

namespace AnimeTrackingServiceWrapper.Converters
{
    public class MediaTypeConverter
#if !DESKTOP
        : IValueConverter
#endif
    {
        public static MediaType StringToMediaType(string mediaTypeString)
        {
            switch (mediaTypeString)
            {
                case "Anime": return MediaType.Anime;
                case "TV": return MediaType.TV;
                case "OVA": return MediaType.OVA;
                case "OAV": return MediaType.OAV;
                case "Movie": return MediaType.Movie;
                case "Manga": return MediaType.Manga;
                case "LightNovel": return MediaType.LightNovel;
                case "Music": return MediaType.Music;
                case "Soundtrack": return MediaType.Soundtrack;
                case "CharacterCD": return MediaType.CharacterCD;
                case "DramaCD": return MediaType.DramaCD;
                case "AudioBook": return MediaType.AudioBook;
                case "Special": return MediaType.Special;
                case "Game": return MediaType.Game;
                case "Other": return MediaType.Other;
                case "None":
                case "Unknown":
                default: return MediaType.Unknown;
            }
        }

        public static string MediaTypeToString(MediaType mediaType)
        {
            switch (mediaType)
            {
                case MediaType.Unknown:         return MediaType.Unknown.ToString();
                case MediaType.Anime:           return MediaType.Anime.ToString();
                case MediaType.TV:              return MediaType.TV.ToString();
                case MediaType.OVA:             return MediaType.OVA.ToString();
                case MediaType.OAV:             return MediaType.OAV.ToString();
                case MediaType.Movie:           return MediaType.Movie.ToString();
                case MediaType.Manga:           return MediaType.Manga.ToString();
                case MediaType.LightNovel:      return "Light Novel";
                case MediaType.Music:           return MediaType.Music.ToString();
                case MediaType.Soundtrack:      return MediaType.Soundtrack.ToString();
                case MediaType.CharacterCD:     return "Character CD";
                case MediaType.DramaCD:         return "Drama CD";
                case MediaType.AudioBook:       return MediaType.AudioBook.ToString();
                case MediaType.Special:         return MediaType.Special.ToString();
                case MediaType.Game:            return MediaType.Game.ToString();
                case MediaType.Other:           return MediaType.Other.ToString();
                default:                        return "";
            }
        }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is MediaType)
                return MediaTypeToString((MediaType)value);
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value is string)
                return StringToMediaType((string)value);
            return MediaType.Unknown;
        }
    }
}
