using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace VWSWebApp.Controllers
{
    public class ForcedumpController : ApiController
    {
        // GET: api/Forcedump

        [HttpPost]
        [Route("api/Forcedump")]
        public HttpResponseMessage Post(dynamic value)
        {

            HttpResponseMessage response;
            try
            {
                //throw new InvalidOperationException("Test Exception!");
                string data = JsonConvert.SerializeObject(value);

                string str = "Hello1,Hello,Hello2";
                string another = "Hello5";
                string retVal = str.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                                   .First(p => p.Equals(another));


                int HTTPResponse = 510;
                response = Request.CreateResponse((HttpStatusCode)HTTPResponse, "Exception: ");
                return response;

            }
            catch (InvalidOperationException e)
            {
                int HTTPResponse = 510;
                response = Request.CreateResponse((HttpStatusCode)HTTPResponse, "Exception: " + e.Message);
                return response;
                //throw new InvalidOperationException(e.Message);
            }
        }
    }
}
