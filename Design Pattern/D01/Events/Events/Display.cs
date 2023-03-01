using DoFactory.HeadFirst.Observer.WeatherStationObservable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Events
{
   
    public class DisplayWeather
    {
            public static void Display(object sender  , WeatherDataEventArgs e)
            {
                if(sender is WeatherData && sender != null)
                {
                    Console.WriteLine($"\tHumidity: {e.Humidity}");
                    Console.WriteLine($"\tPressure: {e.Pressure}");
                    Console.WriteLine($"\tTemperature: {e.Temperature}");
                    Console.WriteLine("********************************");
                }
                
            }

    }




    
}
