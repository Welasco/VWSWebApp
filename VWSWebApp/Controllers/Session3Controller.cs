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
    public class Session3Controller : ApiController
    {
        // GET: api/Session
        [Route("api/Session3")]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var endpointUri = new Uri("https://websnat2.azurewebsites.net/api/Socket");

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
                        var result = await response.Content.ReadAsStringAsync();
                        return BadRequest(result);
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
