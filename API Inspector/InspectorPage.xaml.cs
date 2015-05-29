using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using AnimeTrackingServiceWrapper;
using AnimeTrackingServiceWrapper.Implementation.HummingbirdV1;
using AnimeTrackingServiceWrapper.Service_Structures;
using System.Collections.ObjectModel;

namespace API_Inspector
{
    /// <summary>
    /// Interaction logic for InspectorPage.xaml
    /// </summary>
    public partial class InspectorPage : Page
    {
        AService HummingbirdV1;

        // Tasks
        Task<UserInfo> userInfoTask;
        Task<AnimeObject> getAnimeTask;
        Task<List<AnimeObject>> searchAnimeTask;
        Task<List<LibraryObject>> getAnimeLibraryTask;

        public InspectorPage()
        {
            Loaded += InspectorPage_Loaded;
            InitializeComponent();
        }

        void InspectorPage_Loaded(object sender, RoutedEventArgs e)
        {
            HummingbirdV1 = new HummingbirdV1Service("");
        }

        void ProgressChanged_StatusReport(object sender, APIProgressReport e)
        {
            statusBox.Text = e.StatusMessage;
        }

        #region TabControl
        #region Authenticate
        private async void Authenticate_ButtonClick(object sender, RoutedEventArgs e)
        {
            APIProgress progress = new APIProgress();
            progress.ProgressChanged += ProgressChanged_StatusReport;
            progress.ProgressChanged += ProgressChanged_Authenticate;
            userInfoTask = HummingbirdV1.Login(authenticate_usernameTextBox.Text, authenticate_passwordTextBox.Text, progress);
        }

        void ProgressChanged_Authenticate(object sender, APIProgressReport e)
        {
            if (e.Parameter != null)
            {
                var userInfo = ((UserInfo)e.Parameter);
                authenticate_authTokenTextBlock.Text = userInfo.AuthToken;
            }
        }
        #endregion

        #region Get Anime
        private void GetAnime_ButtonClick(object sender, RoutedEventArgs e)
        {
            APIProgress progress = new APIProgress();
            progress.ProgressChanged += ProgressChanged_StatusReport;
            progress.ProgressChanged += ProgressChanged_GetAnime;
            getAnimeTask = HummingbirdV1.AnimeAPI.GetAnime(getAnime_animeIDTextBox.Text, progress);
        }

        private void ProgressChanged_GetAnime(object sender, APIProgressReport e)
        {
            if (e.Parameter != null)
            {
                var animeObject = ((AnimeObject)e.Parameter);
                getAnime_CoverImageImage.Source = new BitmapImage(animeObject.CoverImageUrl);
                getAnime_RomanjiTitleTextBlock.Text = animeObject.RomanjiTitle;
                getAnime_EnglishTitleTextBlock.Text = animeObject.EnglishTitle;
                getAnime_KanjiTitleTextBlock.Text = animeObject.KanjiTitle;

                List<ServiceID> serviceIDs = new List<ServiceID>();
                serviceIDs.Add(animeObject.ID);
                serviceIDs.Add(animeObject.ID2);
                serviceIDs.AddRange(animeObject.AlternateIDs);
                getAnime_AnimeIDs.ItemsSource = serviceIDs;

                getAnime_AiringStatusTextBlock.Text = animeObject.AiringStatus.ToString();
                getAnime_WebUrlTextBlock.Text = animeObject.WebUrlString;
                getAnime_EpisodeCountTextBlock.Text = "Episode Count: " + animeObject.EpisodeCount.ToString();

                getAnime_AgeRatingTextBlock.Text = animeObject.AgeRating.ToString();
                getAnime_SynopsisTextBlock.Text = "Synopsis: " + animeObject.Synopsis;
                getAnime_MediaTypeTextBlock.Text = animeObject.MediaType.ToString();

                getAnime_FavouriteIDTextBlock.Text = "Favourite ID: " + animeObject.FavouriteID.ToString();
                getAnime_FavouriteRankTextBlock.Text = "Favourite Rank: " + animeObject.FavouriteRank.ToString();

                getAnime_Genres.ItemsSource = animeObject.Genres;
            }
        }
        #endregion

        #region Search Anime
        private void SearchAnime_ButtonClick(object sender, RoutedEventArgs e)
        {
            APIProgress progress = new APIProgress();
            progress.ProgressChanged += ProgressChanged_StatusReport;
            progress.ProgressChanged += ProgressChanged_SearchAnime;
            searchAnimeTask = HummingbirdV1.AnimeAPI.SearchAnime(searchAnime_searchTermsTextBox.Text, progress);
        }

        private void ProgressChanged_SearchAnime(object sender, APIProgressReport e)
        {
            if (e.Parameter != null)
            {
                var searchResults = ((List<AnimeObject>)e.Parameter);
                List<string> titles = new List<string>();
                foreach (var title in searchResults)
                    titles.Add(title.RomanjiTitle);

                searchAnime_TitlesListBox.ItemsSource = titles;
            }
        }
        #endregion

        #region Get Library
        private async void GetLibrary_ButtonClick(object sender, RoutedEventArgs e)
        {
            APIProgress progress = new APIProgress();
            progress.ProgressChanged += ProgressChanged_StatusReport;
            progress.ProgressChanged += ProgressChanged_GetLibrary;

            LibrarySection section = LibrarySection.None;
            switch (getLibrary_LibrarySelectionComboBox.SelectedIndex)
            {
                case 0: section = LibrarySection.All; break;
                case 1: section = LibrarySection.CurrentlyWatching; break;
                case 2: section = LibrarySection.PlanToWatch; break;
                case 3: section = LibrarySection.Completed; break;
                case 4: section = LibrarySection.OnHold; break;
                case 5: section = LibrarySection.Dropped; break;
            }

            getAnimeLibraryTask = HummingbirdV1.AnimeAPI.GetAnimeLibrary(getLibrary_usernameTextBox.Text, section, progress);
        }

        private void ProgressChanged_GetLibrary(object sender, APIProgressReport e)
        {
            if (e.Parameter != null)
            {
                var searchResults = ((List<LibraryObject>)e.Parameter);
                List<string> titles = new List<string>();
                foreach (var libraryObject in searchResults)
                    titles.Add(libraryObject.Anime.RomanjiTitle + ", " + libraryObject.Section.ToString());

                getLibrary_TitlesListBox.ItemsSource = titles;
            }
        }
        #endregion
        #endregion
    }
}
