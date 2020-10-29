using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatelliteControl
{
    public class Status
    {
        #region Properties

        public Guid Guid { get; private set; }
        public bool IsFly { get; private set; }
        public int Fuel { get; private set; }
        public int Height { get; private set; }
        public Point Location { get; private set; }

        #endregion

        #region Ctor

        public Status(Guid guid, bool isFly, int fuel, int height, Point location)
        {
            Guid = guid;
            IsFly = isFly;
            Height = height;
        }

        #endregion
    }
}
