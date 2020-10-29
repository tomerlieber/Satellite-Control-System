using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatelliteControl
{
    public class WeatherForecast
    {
        #region Ctor

        public WeatherForecast(DateTime forecastTime, Point location, MeteorologicData meteorologicData, int windForce)
        {
            ForecastTime = forecastTime;
            Location = location;

            CalculateWeather(meteorologicData, windForce);
        }

        #endregion

        #region Properties

        public DateTime ForecastTime { get; private set; }

        public Point Location { get; private set; }

        public double Temperature { get; private set; }

        public int CloudPrecentage { get; private set; }

        #endregion

        #region Methods

        private void CalculateWeather(MeteorologicData meteorologicData, int windForce)
        {
            Temperature = 35.6;
            CloudPrecentage = 30;
        }

        #endregion
    }
}