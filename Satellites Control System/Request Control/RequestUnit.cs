using SatelliteControl;
using SatelliteControl.Satellites;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestControl
{
    public class RequestUnit
    {
        #region Singleton

        private static volatile RequestUnit mRequestUnit;
        private static object locker = new Object();

        private RequestUnit() { }
        public static RequestUnit Instance
        {
            get
            {
                if (mRequestUnit == null)
                {
                    lock (locker)
                    {
                        if (mRequestUnit == null)
                        {
                            mRequestUnit = new RequestUnit();
                        }
                    }
                }

                return mRequestUnit;
            }
        }

        #endregion

        #region Method

        public int GetCyber(string word)
        {
            string filePath = string.Empty;
            CyberSatellite cyberSatellite = SatelliteUnit.Instance.GetSatellites<CyberSatellite>().First();
            return SatelliteUnit.Instance.SearchWord(cyberSatellite.Guid, filePath, word);
        }

        public Photo GetPhoto(Point location, double resolution)
        {
            PhotoSatellite photoSatellite = SatelliteUnit.Instance.GetSatellites<PhotoSatellite>().First();
            return SatelliteUnit.Instance.TakePhoto(photoSatellite.Guid, location, resolution);
        }

        public WeatherForecast GetWeatherForecast(DateTime time, Point location)
        {
            return MeteorologicUnit.Instance.GetWeatherForecast(time, location);
        }

        public bool DroppedABomb(Point location)
        {
            RussionSatelliteAdapter russionSatelliteAdapter = SatelliteUnit.Instance.GetSatellites<RussionSatelliteAdapter>().First();
            return SatelliteUnit.Instance.DroppedABomb(russionSatelliteAdapter.Guid);
        }

        #endregion
    }
}
