using BlackBox;
using RequestControl;
using SatelliteControl;
using SatelliteControl.Satellites;
using System;
using System.Drawing;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creates satellites.
            var cyberSatellite = new CyberSatellite(SatelliteUnit.Instance);
            var meteorologicSatellite = new MeteorologicSatellite(SatelliteUnit.Instance);
            var photoSatellite = new PhotoSatellite(2.0, SatelliteUnit.Instance);
            photoSatellite.ExecuteAbillities();
            §
            var adapteeRussionSatellite = new RussionSatellite();
            var russionSatelliteAdapter = new RussionSatelliteAdapter(adapteeRussionSatellite, SatelliteUnit.Instance);

            // Adds satellites to the satellite unit.
            SatelliteUnit.Instance.AddSatellite(cyberSatellite);
            SatelliteUnit.Instance.AddSatellite(meteorologicSatellite);
            SatelliteUnit.Instance.AddSatellite(photoSatellite);

            // Registers some satellites to receving weather forecast updates.
            SatelliteUnit.Instance.Register(cyberSatellite);
            SatelliteUnit.Instance.Register(meteorologicSatellite);

            // Uses functions of the request unit.
            var mohammadCount = RequestUnit.Instance.GetCyber("o");
            var weatherForecast = RequestUnit.Instance.GetWeatherForecast(DateTime.Now, Point.Empty);
            var photo = RequestUnit.Instance.GetPhoto(Point.Empty, 2.0);
        }
    }
}