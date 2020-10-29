using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SatelliteControl.Satellites
{
    // Target
    // Observer
    public abstract class Satellite : IObserver<WeatherForecast>
    {
        #region Data Members

        private SatelliteUnit mSatelliteUnit;
        private Timer mReportTimer;
        protected Timer mLockedTimer;
        protected bool mIsLocked;
        protected Dictionary<string, int> mCommands;
        List<WeatherForecast> mWeatherForecastLog;
        public IAbitility Ability { get; protected set; }

        #endregion

        #region Ctor

        protected Satellite()
        {
            this.Guid = Guid.NewGuid();

            mIsLocked = false;
            mLockedTimer = new Timer(3000);
            mLockedTimer.Elapsed += LockedTimeElapsed;

            mCommands = new Dictionary<string, int>();
            mWeatherForecastLog = new List<WeatherForecast>();
        }

        public Satellite(SatelliteUnit satelliteUnit)
            : this()
        {
            mSatelliteUnit = satelliteUnit;

            mReportTimer = new Timer(5000);
            mReportTimer.Elapsed += SendStatus;
            mReportTimer.Start();
        }

        #endregion

        #region Properties

        public virtual Guid Guid { get; private set; }
        public virtual bool IsFly { get; internal set; }
        public virtual int Fuel { get; internal set; }
        public virtual int Height { get; internal set; }
        public virtual Point Location { get; internal set; }
        public virtual SatelliteUnit SatelliteUnit { get; protected set; }

        #endregion

        #region Methods

        internal void SendStatus(object sender, ElapsedEventArgs e)
        {
            SatelliteUnit.AddStatus(new Status(Guid, IsFly, Fuel, Height, Location));
        }

        #endregion

        #region Decorator

        public void ExecuteAbillities()
        {
            Ability.Execute();
        }

        #endregion

        #region Strategy

        private void LockedTimeElapsed(object sender, ElapsedEventArgs e)
        {
            mIsLocked = false;
            mLockedTimer.Stop();
        }

        internal abstract object ExecuteCommand(string commandName, object[] args);

        #endregion

        #region Observer

        public void Update(WeatherForecast weatherForecast)
        {
            mWeatherForecastLog.Add(weatherForecast);
        }

        #endregion
    }
}

//#region Override Methods

//public override int GetHashCode()
//{
//    return Guid.GetHashCode();
//}

//public override bool Equals(object obj)
//{
//    var otherObj = obj as Satellite;

//    if (otherObj == null)
//    {
//        return false;
//    }

//    return this.Guid == otherObj.Guid;
//}

//public override string ToString()
//{
//    return string.Format("Guid: {0}, Type: {1}, IsFly: {2}, Fuel: {3}, Height: {5}",
//        Guid, this.GetType().Name, this.IsFly, this.Fuel, this.Height);
//}

//#endregion