using DoFactory.HeadFirst.Observer.WeatherStationObservable;

namespace Events
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var weatherData = new DoFactory.HeadFirst.Observer.WeatherStationObservable.WeatherData();

            //var currentConditions = new CurrentConditionsDisplay(weatherData);
            //var statisticsDisplay = new StatisticsDisplay(weatherData);
            //var forecastDisplay = new ForecastDisplay(weatherData);
            //var heatIndexDisplay = new HeatIndexDisplay(weatherData);

            //weatherData.SetMeasurements(80, 65, 30.4f);
            //weatherData.SetMeasurements(82, 70, 29.2f);
            //weatherData.SetMeasurements(78, 90, 29.2f);



            WeatherData wd = new(1, 2, 3);
            wd.WeatherDataEvent += DisplayWeather.Display;

            wd.Pressure = 2;
            wd.Temperature = 4;
            wd.Humidity = 5;


            // Wait for user
            Console.ReadKey();
        }
    }
}