using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PrismXamarinMapApp
{
    public class PinService : IPinService
    {
        private ObservableCollection<Pin> _pins;
        public PinService()
        {
            _pins = new ObservableCollection<Pin>();
        }

        public void AddPin(Pin pin)
        {
            _pins.Add(pin);
        }

        public ObservableCollection<Pin> GetPins()
        {
            return _pins;
        }
    }
}
