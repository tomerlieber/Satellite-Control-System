using SatelliteControl.Satellites;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatelliteControl
{
    // Concrete Iterator
    public class SatelliteUnitEnumerator : IEnumerator<Satellite>
    {
        #region Data Members

        private List<Satellite> Satellites;
        private int position;

        #endregion

        #region Ctor

        public SatelliteUnitEnumerator(List<Satellite> satellites)
        {
            Satellites = satellites;
            position = -1;
        }

        #endregion

        #region Methods

        Satellite IEnumerator<Satellite>.Current
        {
            get { return Satellites[position]; }
        }

        public void Dispose()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get { return Satellites[position]; }
        }

        public void Reset()
        {
            position = -1;
        }

        public bool MoveNext()
        {
            position++;
            return position < Satellites.Count;
        }

        #endregion
    }
}
