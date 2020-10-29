using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestControl
{
    internal static class GeneralUtils
    {
        #region Method

        internal static double Distance(this Point location, Point otherLocation)
        {
            double dstX = location.X - otherLocation.X;
            double dstY = location.Y - otherLocation.Y;

            return Math.Sqrt(dstX * dstX + dstY * dstY);
        }

        #endregion
    }
}
