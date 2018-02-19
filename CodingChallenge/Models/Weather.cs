using System;
namespace CodingChallenge.Models
{
    public class Weather
    {
        public string City
        {
            get;
            set;
        }

        public string Country
        {
            get;
            set;
        }

        public string WeatherMain
        {
            get;
            set;
        }

        public string WeatherDescription
        {
            get;
            set;
        }

        public double Temperature
        {
            get;
            set;
        }

        public double TemperatureMin
        {
            get;
            set;
        }

        public double TemperatureMax
        {
            get;
            set;
        }
    }
}
