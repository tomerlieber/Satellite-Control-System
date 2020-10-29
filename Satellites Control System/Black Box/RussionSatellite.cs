using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBox
{
    // Adaptee
    public class RussionSatellite
    {
        #region Properties

        public Guid Identifecachya { get; private set; } // ID
        public bool YesleLetayoo { get; set; } // IsFly
        public int Benzine { get; set; } // Fuel
        public int Vesata { get; set; } // Height
        public Point Nachzdenya { get; set; } // Location

        #endregion
    }
}
