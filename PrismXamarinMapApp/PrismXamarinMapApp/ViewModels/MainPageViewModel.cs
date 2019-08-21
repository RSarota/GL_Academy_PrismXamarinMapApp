using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PrismXamarinMapApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
        private IPinService _pinService;

        public ObservableCollection<Pin> Pins { get; set; }

        public DelegateCommand NavigateToPinView { get; set; }

        public MainPageViewModel(INavigationService navigationService, IPinService pinService)
            : base(navigationService)
        {
            Title = "Main Page";
            _navigationService = navigationService;
            NavigateToPinView = new DelegateCommand(NavigateToPinViewCall);
            _pinService = pinService;
            Pins = _pinService.GetPins();
        }

        public void NavigateToPinViewCall()
        {
            _navigationService.NavigateAsync("PinView");
        }

    }
}
