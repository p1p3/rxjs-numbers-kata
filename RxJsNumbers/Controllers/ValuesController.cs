using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RxJsNumbers.Services;

namespace RxJsNumbers.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly IFiveNumbers _fiveNumbers;

        public ValuesController(IFiveNumbers fiveNumbers)
        {
            _fiveNumbers = fiveNumbers;
        }

        // GET api/values
        public int Get()
        {
            return _fiveNumbers.LastNumber;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
