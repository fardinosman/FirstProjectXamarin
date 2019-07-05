using FirstProjectXamarin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstProjectXamarin.View.DetailView;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstProjectXamarin.View.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : ContentPage
    {
        public ListView ListView { get { return listview; } }
        public List<MasterMenuItem> item;
        public MasterPage()
        {
            InitializeComponent();
            SetItems();
        }
        void SetItems()
        {
            item = new List<MasterMenuItem>();
            item.Add((new MasterMenuItem("InfoScreen1", "LoginIcon.png",Color.White,typeof(InfoScreen1))));
            item.Add((new MasterMenuItem("InfoScreen2", "LoginIcon.png", Color.White, typeof(InfoScreen2))));
            ListView.ItemsSource = item;
        }
    }
}