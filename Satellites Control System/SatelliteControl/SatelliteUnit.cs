using SatelliteControl.Satellites;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SatelliteControl
{
    // Concrete Aggregate
    // Subject/ Observable
    public class SatelliteUnit : IEnumerable<Satellite>, ISubject<WeatherForecast>
    {
        #region Data Members

        private List<Satellite> mSatellites;
        private List<Status> mStatusLog;
        private List<IObserver<WeatherForecast>> mObservers;
        private Timer mNotifyWeatherTimer;

        #endregion

        #region Singleton

        private static volatile SatelliteUnit mControlUnit;
        private static object locker = new Object();

        private SatelliteUnit()
        {
            mSatellites = new List<Satellite>();
            mStatusLog = new List<Status>();
            mObservers = new List<IObserver<WeatherForecast>>();

            mNotifyWeatherTimer = new Timer(10000);
            mNotifyWeatherTimer.Elapsed += NotifyWeatherTimer;
            //mNotifyWeatherTimer.Start();
        }

        private void NotifyWeatherTimer(object sender, ElapsedEventArgs e)
        {
            Notify();
        }

        public static SatelliteUnit Instance
        {
            get
            {
                if (mControlUnit == null)
                {
                    lock (locker)
                    {
                        if (mControlUnit == null)
                        {
                            mControlUnit = new SatelliteUnit();
                        }
                    }
                }

                return mControlUnit;
            }
        }

        #endregion

        #region Iterator

        public IEnumerator<Satellite> GetEnumerator()
        {
            return new SatelliteUnitEnumerator(mSatellites);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion

        #region Methods

        public void AddSatellite(Satellite satellite)
        {
            mSatellites.Add(satellite);
        }

        public void RemoveSatellite(Guid guide)
        {
            Satellite satelliteToRemove = mSatellites.Single(x => x.Guid == guide);
            mSatellites.Remove(satelliteToRemove);
        }

        public void AddStatus(Status satelliteStatus)
        {
            mStatusLog.Add(satelliteStatus);
        }

        public void ChangeHeight(Guid satelliteGuid, int newHeight)
        {
            mSatellites.Single(x => x.Guid == satelliteGuid).Height = newHeight;
        }

        public void Launch(Guid satelliteGuid)
        {
            mSatellites.Single(x => x.Guid == satelliteGuid).IsFly = true;
        }

        public IReadOnlyList<T> GetSatellites<T>() where T : Satellite
        {
            return mSatellites.OfType<T>().ToList().AsReadOnly();
        }

        public Photo TakePhoto(Guid satelliteGuid, Point location, double resolution)
        {
            PhotoSatellite photoSatellite = (PhotoSatellite)mSatellites.Single(x => x.Guid == satelliteGuid);
            return (Photo)photoSatellite.ExecuteCommand("TakePhoto", new object[] { location, resolution });
        }

        public MeteorologicData GetMeteorologicData(Guid satelliteGuid, DateTime dateTime, Point location)
        {
            return mSatellites.OfType<MeteorologicSatellite>().Single(x => x.Guid == satelliteGuid).GetMeteorologicData();
        }

        public int SearchWord(Guid satelliteGuid, string filePath, string word)
        {
            return (int)mSatellites.OfType<CyberSatellite>().Single(x => x.Guid == satelliteGuid).ExecuteCommand("Search", new object[] { filePath, word });
        }

        public bool DroppedABomb(Guid satelliteGuid)
        {
            return (bool)mSatellites.OfType<RussionSatelliteAdapter>().Single(x => x.Guid == satelliteGuid).ExecuteCommand("DroppedABomb", new object[] { });
        }

        #endregion

        #region Observer

        public void Register(IObserver<WeatherForecast> iObserver)
        {
            mObservers.Add(iObserver);
        }

        public void UnRegister(IObserver<WeatherForecast> iObserver)
        {
            mObservers.Remove(iObserver);
        }

        public void Notify()
        {
            foreach (Satellite iObserver in mObservers)
            {
                WeatherForecast WeatherForecast = MeteorologicUnit.Instance.GetWeatherForecast(DateTime.Now, iObserver.Location);

                iObserver.Update(WeatherForecast);
            }
        }

        #endregion
    }
}
