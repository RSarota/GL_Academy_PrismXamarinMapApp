using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace PrismXamarinMapApp
{
    public class Pin
    {
        public Position Position { get; set; }

        public string Label { get; set; }

        public Pin() { }
        public Pin(double latitude, double longitude, string label)
        {
            Position = new Position(latitude, longitude);
            Label = label;
        }
    }
}
