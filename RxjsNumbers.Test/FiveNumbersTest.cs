using System;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Observable.Aliases;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RxJsNumbers.Services;

namespace RxjsNumbers.Test
{
    [TestClass]
    public class FiveNumbersTest
    {
        [TestMethod]
        public async Task Every2Seconds()
        {
            var frecuency = TimeSpan.FromSeconds(2);
            var fiveNumbers = new FiveNumbers(frecuency);

            var result = await SumOfLast5NumbersPlusOne(fiveNumbers);

            Assert.IsTrue(fiveNumbers.ValidateLastFiveNumbersPlusOne(result));
        }

        [TestMethod]
        public async Task Every1Second()
        {
            var frecuency = TimeSpan.FromSeconds(1);
            var fiveNumbers = new FiveNumbers(frecuency);

            var result = await SumOfLast5NumbersPlusOne(fiveNumbers);

            Assert.IsTrue(fiveNumbers.ValidateLastFiveNumbersPlusOne(result));
        }


        private IObservable<int> SumOfLast5NumbersPlusOne(IFiveNumbers fiveNumbers)
        {
         return Observable
             .Interval(TimeSpan.FromMilliseconds(500), new NewThreadScheduler())
             .Map(time => fiveNumbers.LastNumber)
             .DistinctUntilChanged()
             .Map(number => number + 1)
             .Buffer(5)
             .Map(numbers => numbers.Sum())
             .FirstAsync();
        }
    }
}
