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
            APIProgress authenticateProgress = new APIProgress();
            authenticateProgress.ProgressChanged += ProgressChanged_StatusReport;
            authenticateProgress.ProgressChanged += ProgressChanged_Authenticate;
            userInfoTask = HummingbirdV1.Login(authenticate_usernameTextBox.Text, authenticate_passwordTextBox.Text, authenticateProgress);
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
        #endregion
    }
}
