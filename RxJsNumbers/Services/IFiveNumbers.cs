using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxJsNumbers.Services
{
    public interface IFiveNumbers
    {
        int LastNumber { get; }
        IObservable<int> Numbers { get; }
        bool ValidateLastFiveNumbersPlusOne(int[] numbers);


    }
}
