using AnimeTrackingServiceWrapper.UniversalServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.Implementation.HummingbirdV1.Models
{
    public class AnimeObjectHummingbirdV1
    {
        public int id { get; set; }
        public int? mal_id { get; set; }
        public string slug { get; set; }
        public string status { get; set; }
        public string url { get; set; }
        public string title { get; set; }
        public string alternate_title { get; set; }
        public int? episode_count { get; set; }
        public int? episode_length { get; set; }
        public string cover_image { get; set; }
        public string synopsis { get; set; }
        public string show_type { get; set; }
        public string started_airing { get; set; }
        public string finished_airing { get; set; }
        public double community_rating { get; set; }
        public string age_rating { get; set; }
        public List<GenreHummingbirdV1> genres { get; set; }

        public int fav_rank { get; set; }
        public int fav_id { get; set; }

        public static explicit operator AnimeObject(AnimeObjectHummingbirdV1 oldObject)
        {
            AnimeObject animeObject = new AnimeObject();
            animeObject.Service             = ServiceName.Hummingbird;
            
            animeObject.AgeRating           = Converters.AgeRatingConverter.StringToAgeRating(oldObject.age_rating);
            animeObject.AiringStatus        = Converters.AiringStatusConverter.StringToAiringStatus(oldObject.status);

            animeObject.AlternateIDs = new List<ServiceID>();
            if (oldObject.mal_id.HasValue)
                animeObject.AlternateIDs.Add(new ServiceID(ServiceName.MyAnimeList, MediaType.Anime, oldObject.mal_id.Value));

            animeObject.CoverImageUrlString = oldObject.cover_image;


            if (oldObject.episode_count.HasValue)
                animeObject.EpisodeCount  = oldObject.episode_count.Value;
            else animeObject.EpisodeCount = 0;

            animeObject.FavouriteID         = oldObject.fav_id;
            animeObject.FavouriteRank       = oldObject.fav_rank;

            animeObject.Genres = new List<MediaGenre>();
            foreach (var genre in oldObject.genres)
            {
                animeObject.Genres.Add(Converters.MediaGenreConverter.StringToMediaGenre(genre.name));
            }

            animeObject.ID                  = new ServiceID(ServiceName.Hummingbird, MediaType.Anime, oldObject.slug);
            animeObject.ID2                 = new ServiceID(ServiceName.Hummingbird, MediaType.Anime, oldObject.id);

            animeObject.RomanjiTitle        = oldObject.title;
            animeObject.EnglishTitle        = oldObject.alternate_title;
            animeObject.KanjiTitle          = "";
            animeObject.MediaType           = Converters.MediaTypeConverter.StringToMediaType(oldObject.show_type);

            animeObject.Synopsis            = oldObject.synopsis;
            animeObject.WebUrlString        = oldObject.url;

            return animeObject;
        }
    }

    public class AnimeObjectListHummingbirdV1
    {
        public List<AnimeObjectHummingbirdV1> anime { get; set; }

        public static implicit operator List<AnimeObjectHummingbirdV1> (AnimeObjectListHummingbirdV1 animeObject) {
            return animeObject.anime;
        }
    }
}