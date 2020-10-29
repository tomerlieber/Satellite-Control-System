using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatelliteControl
{
    abstract class AbillityDecorator : IAbitility
    {
        protected IAbitility mAbility;

        public AbillityDecorator(IAbitility ability)
        {
            mAbility = ability;
        }

        public abstract void Execute();
    }
}
