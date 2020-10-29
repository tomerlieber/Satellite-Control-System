using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatelliteControl.Satellites
{
    public class MeteorologicSatellite : Satellite
    {
        #region Ctor

        public MeteorologicSatellite(SatelliteUnit SatelliteUnit)
            : base(SatelliteUnit) { }

        #endregion

        #region Method

        internal MeteorologicData GetMeteorologicData()
        {
            return new MeteorologicData();
        }

        #endregion

        internal override object ExecuteCommand(string commandName, object[] args)
        {
            throw new NotImplementedException();
        }
    }
}
