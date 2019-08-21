using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrismXamarinMapApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PinViewTEST : ContentPage
    {
        public PinViewTEST()
        {
            InitializeComponent();
        }

        private DelegateCommand _localize;

        public DelegateCommand Localize
        {
            get { return _localize; }
        }

        //_localize= new DelegateCommand(GetLastKnownLocation);

        private async void GetLastKnownLocation(object sender, EventArgs e)
        {
            var lastKnownLocation = await Geolocation.GetLastKnownLocationAsync();
            longitude.Text = lastKnownLocation.Longitude.ToString();
            latitude.Text = lastKnownLocation.Latitude.ToString();
        }
    }
}