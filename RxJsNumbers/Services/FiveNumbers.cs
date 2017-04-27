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
        private IObservable<int> _numbers;
        private IObservable<int> _lastFiveNumbersPlusOne;

        private int _lastNumber;
        private int _lastFiveNumberSumPlusOne;

        public int LastNumber => this._lastNumber;
        public IObservable<int> Numbers => this._numbers;


        public FiveNumbers()
        {
            var random = new Random();

            this._numbers = Observable.
                            Interval(TimeSpan.FromSeconds(3),new NewThreadScheduler())
                            .Map(time => random.Next(0, 10000));

            this._lastFiveNumbersPlusOne = this._numbers
                                           .Map(number => number += 1)
                                           .Buffer(5).Map(numbers => numbers.Sum());

            this._numbers.Subscribe(number => this._lastNumber = number);
            this._lastFiveNumbersPlusOne.Subscribe(result => _lastFiveNumberSumPlusOne = result);
        }

        public bool ValidateLastFiveNumbersPlusOne(int expected)
        {
            return this._lastFiveNumberSumPlusOne == expected;
        }
    }
}