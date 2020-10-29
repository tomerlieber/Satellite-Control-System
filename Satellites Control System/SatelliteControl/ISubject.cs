using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatelliteControl
{
    public interface ISubject<T>
    {
        void Register(IObserver<T> iObserver);

        void UnRegister(IObserver<T> iObserver);

        void Notify();
    }
}
