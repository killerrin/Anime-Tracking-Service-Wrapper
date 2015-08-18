using AnimeTrackingServiceWrapper.Helpers;
using AnimeTrackingServiceWrapper.UniversalServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.Implementation.HummingbirdV1.Models
{
    public class AnimeObjectHummingbirdV1 : ModelBase
    {
        private int m_id = 0;
        public int id
        {
            get { return m_id; }
            set
            {
                m_id = value;
                RaisePropertyChanged(nameof(id));
            }
        }

        private int? m_mal_id = 0;
        public int? mal_id
        {
            get { return m_mal_id; }
            set
            {
                m_mal_id = value;
                RaisePropertyChanged(nameof(mal_id));
            }
        }

        private string m_slug = "";
        public string slug
        {
            get { return m_slug; }
            set
            {
                m_slug = value;
                RaisePropertyChanged(nameof(slug));
            }
        }

        private string m_status = "";
        public string status
        {
            get { return m_status; }
            set
            {
                m_status = value;
                RaisePropertyChanged(nameof(status));
            }
        }

        private string m_url = "";
        public string url
        {
            get { return m_url; }
            set
            {
                m_url = value;
                RaisePropertyChanged(nameof(url));
            }
        }

        private string m_title = "";
        public string title
        {
            get { return m_title; }
            set
            {
                m_title = value;
                RaisePropertyChanged(nameof(title));
            }
        }

        private string m_alternate_title = "";
        public string alternate_title
        {
            get { return m_alternate_title; }
            set
            {
                m_alternate_title = value;
                RaisePropertyChanged(nameof(alternate_title));
            }
        }

        private int? m_episode_count = 0;
        public int? episode_count
        {
            get { return m_episode_count; }
            set
            {
                m_episode_count = value;
                RaisePropertyChanged(nameof(episode_count));
            }
        }

        private int? m_episode_length = 0;
        public int? episode_length
        {
            get { return m_episode_length; }
            set
            {
                m_episode_length = value;
                RaisePropertyChanged(nameof(episode_length));
            }
        }

        private string m_cover_image = "";
        public string cover_image
        {
            get { return m_cover_image; }
            set
            {
                m_cover_image = value;
                RaisePropertyChanged(nameof(cover_image));
            }
        }

        private string m_synopsis = "";
        public string synopsis
        {
            get { return m_synopsis; }
            set
            {
                m_synopsis = value;
                RaisePropertyChanged(nameof(synopsis));
            }
        }

        private string m_show_type = "";
        public string show_type
        {
            get { return m_show_type; }
            set
            {
                m_show_type = value;
                RaisePropertyChanged(nameof(show_type));
            }
        }

        private string m_started_airing = "";
        public string started_airing
        {
            get { return m_started_airing; }
            set
            {
                m_started_airing = value;
                RaisePropertyChanged(nameof(started_airing));
            }
        }

        private string m_finished_airing = "";
        public string finished_airing
        {
            get { return m_finished_airing; }
            set
            {
                m_finished_airing = value;
                RaisePropertyChanged(nameof(finished_airing));
            }
        }

        private double m_community_rating = 0.0;
        public double community_rating
        {
            get { return m_community_rating; }
            set
            {
                m_community_rating = value;
                RaisePropertyChanged(nameof(community_rating));
            }
        }

        private string m_age_rating = "";
        public string age_rating
        {
            get { return m_age_rating; }
            set
            {
                m_age_rating = value;
                RaisePropertyChanged(nameof(age_rating));
            }
        }

        private List<GenreHummingbirdV1> m_genres = new List<GenreHummingbirdV1>();
        public List<GenreHummingbirdV1> genres
        {
            get { return m_genres; }
            set
            {
                m_genres = value;
                RaisePropertyChanged(nameof(genres));
            }
        }

        private int m_fav_rank = 0;
        public int fav_rank
        {
            get { return m_fav_rank; }
            set
            {
                m_fav_rank = value;
                RaisePropertyChanged(nameof(fav_rank));
            }
        }

        private int m_fav_id = 0;
        public int fav_id
        {
            get { return m_fav_id; }
            set
            {
                m_fav_id = value;
                RaisePropertyChanged(nameof(fav_id));
            }
        }

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