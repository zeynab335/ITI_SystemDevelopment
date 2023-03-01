using DoFactory.HeadFirst.Observer.WeatherStationObservable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{


    public class WeatherData
    {

        // fields
        private float _humidity;
        private float _pressure;
        private float _temperature;

        // event Decleration
        internal event EventHandler<WeatherDataEventArgs> WeatherDataEvent;

        // notify subscribers
        protected virtual void onUpdateWeatherData(WeatherDataEventArgs e) => WeatherDataEvent?.Invoke(this, e);

        // properties
        public float Temperature
        {
            get { return _temperature; }
            set
            {
                if (value != _temperature)
                {
                    _temperature = value;
                    // fire event
                    onUpdateWeatherData(new() { Humidity = this.Humidity, Pressure = this.Pressure, Temperature = value });
                }
            }
        }

        public float Humidity
        {
            get { return _humidity; }
            set
            {
                if (value != _humidity)
                {
                    _humidity = value;
                    // fire event
                    onUpdateWeatherData(new() { Humidity =value, Pressure = this.Pressure, Temperature = this.Temperature });
                }
            }
        }

        public float Pressure
        {
            get { return _pressure; }
            set
            {
                if (value != _pressure)
                {

                    _pressure = value;
                    // fire event
                    onUpdateWeatherData(new() { Humidity = this.Humidity, Pressure = value, Temperature = this.Temperature });
                }
            }
        }

        public WeatherData(float _humidity, float _pressure, float _temperature)
        {
            Humidity    = _humidity;
            Pressure    = _pressure;
            Temperature = _temperature;
        }


    }
}
