using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RxJsNumbers.Services;

namespace RxJsNumbers.Controllers
{
    public class FiveNumbersController : ApiController
    {
        private readonly IFiveNumbers _fiveNumbers;

        public FiveNumbersController(IFiveNumbers fiveNumbers)
        {
            _fiveNumbers = fiveNumbers;
        }

        public int Get()
        {
            return _fiveNumbers.LastNumber;
        }

        public bool Post([FromBody]int result, [FromBody]string name)
        {
            return _fiveNumbers.ValidateLastFiveNumbersPlusOne(result);
        }

    }
}
