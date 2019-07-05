using FirstProjectXamarin.Models;
using FirstProjectXamarin.View.DetailView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstProjectXamarin.View.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashboard : ContentPage
    {
        public Dashboard()
        {
            InitializeComponent();
            Init();
        }

        void Init()
        {
            BackgroundColor = Constants.BackgroundColor;
            App.StartCheckInternet(lbl_NoInternet, this);  

        }
        async void SelectedScreen1(object sender,EventArgs e)
        {
            await Navigation.PushAsync(new InfoScreen1());
        }
    }
}