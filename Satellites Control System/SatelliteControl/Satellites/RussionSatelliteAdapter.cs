using BlackBox;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatelliteControl.Satellites
{
    // Adapter
    public class RussionSatelliteAdapter : Satellite
    {
        #region Data Members

        private RussionSatellite mRussionSatellite;

        #endregion

        #region Ctor

        public RussionSatelliteAdapter(RussionSatellite adapteeRussionSatellite, SatelliteUnit satelliteUnit)
        {
            mRussionSatellite = adapteeRussionSatellite;
            SatelliteUnit = satelliteUnit;
        }

        #endregion

        #region Override Properties

        public override Guid Guid
        {
            get { return mRussionSatellite.Identifecachya; }
        }

        public override bool IsFly
        {
            get { return mRussionSatellite.YesleLetayoo; }
            internal set { mRussionSatellite.YesleLetayoo = value; }
        }

        public override int Fuel
        {
            get { return mRussionSatellite.Benzine; }
            internal set { mRussionSatellite.Benzine = value; }
        }

        public override int Height
        {
            get { return mRussionSatellite.Vesata; }
            internal set { mRussionSatellite.Vesata = value; }
        }

        public override Point Location
        {
            get { return mRussionSatellite.Nachzdenya; }
            internal set { mRussionSatellite.Nachzdenya = value; }
        }

        public override SatelliteUnit SatelliteUnit
        {
            get { return base.SatelliteUnit; }
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
                default:
                    {
                        return null;
                    }
            }
        }

        #endregion
    }
}
