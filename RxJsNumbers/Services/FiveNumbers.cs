using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Observable.Aliases;
using System.Web;
using WebGrease.Css.Extensions;

namespace RxJsNumbers.Services
{
    public class FiveNumbers : IFiveNumbers
    {

        private int _lastFiveNumberSumPlusOne;

        public int LastNumber { get; private set; }

        public IObservable<int> Numbers { get; }

        private readonly Random _random;

        public FiveNumbers(TimeSpan frecuency)
        {
            this._random = new Random();

            var observable = Observable
                .Interval(frecuency, new NewThreadScheduler())
                .StartWith(0)
                .Map(time => GetNextValue())
                .Publish();

            this.Numbers = observable;

            this.Numbers
               .Map(number => number + 1)
               .Buffer(5)
               .Map(numbers => numbers.Sum())
               .Subscribe(result => _lastFiveNumberSumPlusOne = result);

            this.Numbers.Subscribe(number => this.LastNumber = number);

            observable.Connect();
        }

        public bool ValidateLastFiveNumbersPlusOne(int expected)
        {
            return this._lastFiveNumberSumPlusOne == expected;
        }

        private int GetNextValue()
        {
            Func<int> randomNumber = () => _random.Next(0, 10000);
            var nextNumber = randomNumber();
            while (nextNumber == LastNumber)
            {
                nextNumber = randomNumber();
            }
            return nextNumber;
        }
    }
}