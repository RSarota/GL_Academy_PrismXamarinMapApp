using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Xamarin.Essentials;
using Xamarin.Forms.Maps;

namespace PrismXamarinMapApp.ViewModels
{
    public class PinViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private string _label;
        private double _longitude;
        private double _latitude;
        public double Longitude { get => _longitude; set { _longitude = value; OnPropertyChanged(); } }
        public double Latitude { get => _latitude; set { _latitude = value; OnPropertyChanged(); } }
        public string Label { get => _label; set { _label = value; OnPropertyChanged(); } }

        private INavigationService _navigationService;
        public event PropertyChangedEventHandler PropertyChanged;

        private IPinService _pinService;

        public DelegateCommand NavigateToMainPage { get; set; }
        public DelegateCommand Localize { get; set; }

        public PinViewModel(INavigationService navigationService, IPinService pinService) : base(navigationService)
        {
            Title = "Add pin";
            _navigationService = navigationService;
            NavigateToMainPage = new DelegateCommand(NavigateToMainPageCall);
            Localize = new DelegateCommand(LocalizeCall);
            _pinService = pinService;
        }
        public void NavigateToMainPageCall()
        {
            if(_label!=default&&_latitude!=default&&_longitude!=default)
                _pinService.AddPin(new Pin(_latitude, _longitude, _label));
            _navigationService.GoBackAsync();
        }

        public async void LocalizeCall()
        {
            var lastKnownLocation = await Geolocation.GetLastKnownLocationAsync();
            Longitude = lastKnownLocation.Longitude;
            Latitude = lastKnownLocation.Latitude;
        }

        private void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
