using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Xml;

namespace VWSWebApp.Controllers
{
    public class SessionController : ApiController
    {
        // GET: api/Session
        [Route("api/Session")]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var endpointUri = new Uri("https://api.github.com/users/welasco");

                using (HttpClient client = new HttpClient())
                {
                    //client.DefaultRequestHeaders.Accept.Clear();
                    //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    

                    System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                    client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT; Windows NT 10.0; en-US) WindowsPowerShell/5.1.17134.228");
                    //var response = await client.PostAsync(endpointUri, content);
                    //var response = await client.GetAsync(endpointUri);
                    var response = await client.GetAsync(endpointUri);


                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        return Ok(result);
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
