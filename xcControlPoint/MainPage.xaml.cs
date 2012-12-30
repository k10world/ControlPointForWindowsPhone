using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Primitives;
using Microsoft.Phone.Controls;
using System.Windows.Media.Imaging;
using System.Net.NetworkInformation;
using System.Data.Services.Client;
using xcControlPoint.Auth;
using System.IO;
using Newtonsoft.Json;

namespace xcControlPoint
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();                        
        }

        Authorization auth;

        private void BtnGoClick(object sender, RoutedEventArgs e)
        {
            bool isConnected = NetworkInterface.GetIsNetworkAvailable();

            if (!isConnected) { tbResult.Text = "No network is available to serve the request!"; return; }

            if (!txtControlPointURL.Text.Contains("http://") && !txtControlPointURL.Text.Contains("https://")) { tbResult.Text = "Please enter the URL in the correct format."; return; }
            if(string.IsNullOrEmpty(tbUserName.Text)) {tbResult.Text = "Please enter a valid username.";}
            //if(string.IsNullOrEmpty(tbPassword.Text)) {tbResult.Text = "Please enter password.";}
       
            tbResult.Text = "Authenticating.....";

            auth = new Authorization(CredentialsAndURL.USER_NAME, CredentialsAndURL.USER_PASSWORD, txtControlPointURL.Text);

            auth.OnAuthenticated += auth_OnAuthenticated;
            auth.Authenticate();

            if (App.IsAuthenticated) { tbResult.Text = "Authenticated!"; NavigateToxcMain(); }
            else { tbResult.Text = "Authentication Failed!"; }
        }

        void auth_OnAuthenticated(object sender, AuthenticatedEventArgs e)
        {
            App.CookieJar = e.CookieJar;
            App.IsAuthenticated = true;

            //do some work
            //LoadTasks();               
        }

        void NavigateToxcMain()
        {
            NavigationService.Navigate(new Uri("/xcMain.xaml", UriKind.Relative));
        }

    }
}
