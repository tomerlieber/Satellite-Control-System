using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SatelliteControl
{
    public interface IObserver<T>
    {
        void Update(T param);
    }
}
