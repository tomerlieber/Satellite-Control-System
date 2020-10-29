using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatelliteControl
{
    public class Photo
    {
        #region Ctor

        public Photo(Point location, double resolution, Bitmap bitmap)
        {
            Location = location;
            Resolution = resolution;
            Bitmap = bitmap;
        }

        #endregion

        #region Properties

        public Point Location { get; private set; }
        public double Resolution { get; private set; }
        public Bitmap Bitmap { get; private set; }

        #endregion
    }
}
