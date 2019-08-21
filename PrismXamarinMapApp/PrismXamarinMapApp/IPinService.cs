using System.Collections.ObjectModel;

namespace PrismXamarinMapApp
{
    public interface IPinService
    {
        void AddPin(Pin pin);
        ObservableCollection<Pin> GetPins();
    }
}