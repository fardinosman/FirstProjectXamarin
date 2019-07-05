using FirstProjectXamarin.Models;
using FirstProjectXamarin.View.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstProjectXamarin.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
            Init();
        }

         void Init()
        {
            BackgroundColor = Constants.BackgroundColor;
            Lbl_Username.TextColor = Constants.MainTextColor;
            Lbl_Password.TextColor = Constants.MainTextColor;
            ActivitySpinner.IsVisible = false;
            LoginIcon.HeightRequest = Constants.LoginIconHeight;

            App.StartCheckInternet(lbl_NoInternet, this);

            Entry_Username.Completed += (s, e) => Entry_Password.Focus();
            Entry_Password.Completed += (s, e) => SignInProcedure(s, e);
        }

        async void SignInProcedure(object sender, EventArgs e)
        {
            User user = new User(Entry_Username.Text, Entry_Password.Text);
            if (user.CheckInformation())
            {
                ActivitySpinner.IsVisible = true;
                //var result= await App.RestService.Login(user);
                var result = new Token();
                await DisplayAlert("Login", "Login Success", "Ok");
                
               
                if (result != null)
                {
                    ActivitySpinner.IsVisible = false;

                    // App.UserDatabase.SaveUser(user);
                    //App.TokenDatabase.SaveToken(result);
                    //await Navigation.PushAsync(new Dashboard());
                    if (Device.RuntimePlatform == Device.Android)
                    {
                        Application.Current.MainPage = new NavigationPage(new MasterDetail());
                    }
                }

            }
            else
            {
                await DisplayAlert("Login", "Login Not Correct", "empty username or password.", "Oke");
                ActivitySpinner.IsVisible = false;

            }
        }
    }
}