﻿using FirstProjectXamarin.Data;
using FirstProjectXamarin.Models;
using FirstProjectXamarin.View;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstProjectXamarin
{
    public partial class App : Application
    {
        static TokenDatabaseController tokenDatabase;
        static UserDatabaseController userDatabase;
        static RestService restService;
        private static Label labelScreen;
        private static Page currentpage;
        private static Timer timer;
        private static bool hasInternet;
        private static bool notInterShow;

        public App()
        {
            InitializeComponent();

            MainPage = new Login();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
        public static UserDatabaseController UserDatabase
        {
            get
            {
                if (userDatabase==null)
                {
                    userDatabase = new UserDatabaseController();
                }
                return userDatabase;
            }
           
        }
        public static TokenDatabaseController TokenDatabase
        {
            get
            {
                if (tokenDatabase == null)
                {
                    tokenDatabase = new TokenDatabaseController();
                }
                return tokenDatabase;
            }

        }
        public static RestService RestService
        {
            get
            {
                if (restService == null)
                {
                    restService = new RestService();
                }
                return restService;
            }
        }

        public static void StartCheckInternet(Label label, Page page)
        {
            labelScreen = label;
            label.Text = Constants.NoInternetText;
            label.IsVisible = true;
            currentpage = page;
            if (timer==null)
            {
                timer = new Timer((e) =>
                {
                    CheckIfInternetOverTime();
                }, null, 10, (int)TimeSpan.FromSeconds(3).TotalMilliseconds) ;
              
            }
        }

        private static void CheckIfInternetOverTime()
        {
            var networkConnection = DependencyService.Get<INetworkConnection>();
            networkConnection.CheckNetworkConnection();
            if (!networkConnection.IsConnected)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    if (hasInternet)
                    {
                        if (!notInterShow)
                        {
                            hasInternet = false;
                            labelScreen.IsVisible = true;
                            await ShowDisplayAlert();
                        }

                    }
                });
            }
            else
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    hasInternet = true;
                    labelScreen.IsVisible = false;
                });
            }
        }
        public static async Task<bool> CheckIfInternet()
        {
            var networkConnection = DependencyService.Get<INetworkConnection>();
            networkConnection.CheckNetworkConnection();
            return networkConnection.IsConnected;
        }
        public static async Task<bool> CheckIfInternetAlert()
        {
            var networkConnection = DependencyService.Get<INetworkConnection>();
            networkConnection.CheckNetworkConnection();
            if (!networkConnection.IsConnected)
            {
                if (!notInterShow)
                {
                    await ShowDisplayAlert();
                }
            }
            return true;
        }

     

        private static async Task ShowDisplayAlert()
        {
            notInterShow = false;
            await currentpage.DisplayAlert("Internet", "Device has not Internet, please reconnect", "Ok");
            notInterShow = false;
        }
    }
}
