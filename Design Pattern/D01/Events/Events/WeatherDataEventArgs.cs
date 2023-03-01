using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public class WeatherDataEventArgs : EventArgs
    {
        public float Temperature { set; get; }
        public float Humidity { set; get; }
        public float Pressure { set; get; }

        
    }
}
