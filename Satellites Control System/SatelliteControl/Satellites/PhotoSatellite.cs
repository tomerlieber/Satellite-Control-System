using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SatelliteControl.Satellites
{
    public class PhotoSatellite : Satellite
    {
        #region Ctor

        public PhotoSatellite(double resolution, SatelliteUnit satelliteControl)
            : base(satelliteControl)
        {
            Resolution = resolution;
            mCommands.Add("TakePhoto", 2);
            Ability = new DrawWay(new FindLocation());
        }

        #endregion

        #region Properties

        public double Resolution { get; private set; }

        #endregion

        #region Methods

        internal Photo TakePhoto(Point location, double resolution)
        {
            return new Photo(location, resolution, null);
        }

        #endregion

        #region Strategy

        internal override object ExecuteCommand(string commandName, object[] args)
        {
            if (!mCommands.ContainsKey(commandName) || mCommands[commandName] != args.Length)
            {
                mIsLocked = true;
                mLockedTimer.Start();
            }

            switch (commandName)
            {
                case "TakePhoto":
                    {
                        return TakePhoto((Point)args[0], (double)args[1]);
                    }
                default:
                    {
                        return null;
                    }
            }
        }

        #endregion
    }
}