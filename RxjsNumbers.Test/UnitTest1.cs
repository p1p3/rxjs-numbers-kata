using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RxJsNumbers.Services;

namespace RxjsNumbers.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var fiveNumbers  = new FiveNumbers();
            var first = fiveNumbers.LastNumber;
            Thread.Sleep(3000);
            var second = fiveNumbers.LastNumber;
            Thread.Sleep(3000);
            var third = fiveNumbers.LastNumber;
        }
    }
}
