using SatelliteControl.Satellites;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatelliteControl
{
    public class MeteorologicUnit
    {
        #region Singleton

        private static volatile MeteorologicUnit mMeteorologicUnit;
        private static object locker = new Object();

        private MeteorologicUnit()
        {
        }

        public static MeteorologicUnit Instance
        {
            get
            {
                if (mMeteorologicUnit == null)
                {
                    lock (locker)
                    {
                        if (mMeteorologicUnit == null)
                        {
                            mMeteorologicUnit = new MeteorologicUnit();
                        }
                    }
                }

                return mMeteorologicUnit;
            }
        }

        #endregion

        #region Methods

        public WeatherForecast GetWeatherForecast(DateTime dateTime, Point location)
        {
            MeteorologicSatellite meteorologicSatellite = SatelliteUnit.Instance.GetSatellites<MeteorologicSatellite>().First();
            MeteorologicData meteorologicData = SatelliteUnit.Instance.GetMeteorologicData(meteorologicSatellite.Guid, dateTime, location);

            return new WeatherForecast(dateTime, location, meteorologicData, GetWindForce());
        }

        private int GetWindForce()
        {
            return 100;
        }

        #endregion
    }
}
