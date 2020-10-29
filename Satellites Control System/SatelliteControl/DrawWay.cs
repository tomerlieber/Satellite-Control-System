using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatelliteControl
{
    class DrawWay : AbillityDecorator
    {
        public DrawWay(IAbitility ability)
            : base(ability) { }

        public override void Execute()
        {
            // The logic of the execute

            mAbility.Execute();
        }
    }
}
