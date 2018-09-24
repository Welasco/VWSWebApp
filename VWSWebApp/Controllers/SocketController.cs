using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VWSWebApp.Tools;
using VWSWebApp.Models;


namespace VWSWebApp.Controllers
{
    //[RoutePrefix("api/Socket")]
    public class SocketController : ApiController
    {
        // GET: api/Socket
        // GET: api/SocketStart
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //[Route("api/Socket/GetStatus")]

        // GET: api/Socket
        // GET: api/Socket/GetSocket
        [Route("api/Socket")]
        
        public HttpResponseMessage GetSocket()
        {
            HttpResponseMessage response;
            try
            {
                
                if (GlobalVariables.GlobalSocketList.Count == 0)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, @"{""Status"": ""No connections opened!}");
                }
                else //if (GlobalVariables.GlobalSocketList.Count != 0)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, @"{""Status"": ""There are " + GlobalVariables.GlobalSocketList.Count + @" connections opened."", ""ConnectionsReport"": """ + AsynchronousClient.StatusClient(GlobalVariables.GlobalSocketList) +  @"""}"); // + AsynchronousClient.StatusClient + 
                }
                //response = Request.CreateResponse(HttpStatusCode.OK, @"{""Status"": ""There are " + GlobalVariables.GlobalSocketList.Count + @" connections opened.""}");
            }
            catch (Exception)
            {

                response = Request.CreateResponse(HttpStatusCode.OK, @"{""Status"": ""There are no connections opened!""}");
                return response;
            }
            return response;

        }
        [HttpGet]
        public HttpResponseMessage ReconnectSocket()
        {
            HttpResponseMessage response;

            if (GlobalVariables.GlobalSocketList.Count > 0)
            {
                try
                {
                    string sBefore = AsynchronousClient.StatusClient(GlobalVariables.GlobalSocketList);
                    AsynchronousClient.ReconnectClient(GlobalVariables.GlobalSocketList);
                    string sAfter = AsynchronousClient.StatusClient(GlobalVariables.GlobalSocketList);
                    response = Request.CreateResponse(HttpStatusCode.OK, @"{""Status"": ""Reconnecting Sockets!"", ""ConnectionStatusBeforeReconnect:"" """ + sBefore + @", ""ConnectionStatusAfterReconnect: "" """ + sAfter + @"""}");

                }
                catch (Exception e)
                {

                    response = Request.CreateResponse(HttpStatusCode.OK, @"{""Status"": ""Failed to Reconnect Sockets!"", ""ExceptionMessage"": """ + e.Message + @"""}");
                    return response;
                }
            }
            else //if (GlobalVariables.GlobalSocketList.Count != 0)
            {
                response = Request.CreateResponse(HttpStatusCode.OK, @"{""Status"": ""Sockets not found. Please create a socket first!""}");
            }

            //try
            //{
            //    string sBefore = AsynchronousClient.StatusClient(GlobalVariables.GlobalSocketList);
            //    AsynchronousClient.ReconnectClient(GlobalVariables.GlobalSocketList);
            //    string sAfter = AsynchronousClient.StatusClient(GlobalVariables.GlobalSocketList);
            //    response = Request.CreateResponse(HttpStatusCode.OK, @"{""Status"": ""Reconnecting Sockets!"", ""ConnectionStatusBeforeReconnect:"" """ + sBefore + @", ""ConnectionStatusAfterReconnect: "" """ + sAfter + @"""}");

            //}
            //catch (Exception e)
            //{

            //    response = Request.CreateResponse(HttpStatusCode.OK, @"{""Status"": ""Failed to Reconnect Sockets!"", ""ExceptionMessage"": """ + e.Message + @"""}");
            //    return response;
            //}
            return response;

        }

        //[Route("api/Socket/StopAll")]
        //[Route("api/Socket/Stop")]
        [HttpGet]
        public HttpResponseMessage Stop()
        {
            HttpResponseMessage response;
            try
            {
                AsynchronousClient.StopClient(GlobalVariables.GlobalSocketList);
                response = Request.CreateResponse(HttpStatusCode.OK, @"{""Status"": ""All connections was stoped:" + GlobalVariables.GlobalSocketList.Count + @"""}");
                GlobalVariables.GlobalSocketList.Clear();
                GlobalVariables.cmd = null;
            }
            catch (Exception)
            {
                response = Request.CreateResponse(HttpStatusCode.OK, @"{""Status"": ""No existing connection. Please create a connection first.""}");
                return response;
            }
            return response;
        }

        [HttpPost]
        [Route("api/Socket/Start")]
        public HttpResponseMessage Post(dynamic value)
        {
            HttpResponseMessage response;
            string data = JsonConvert.SerializeObject(value);

            try
            {
                //Socketcmd socketcmd = JsonConvert.DeserializeObject<Socketcmd>(data);
                //GlobalVariables.cmd = socketcmd;
                GlobalVariables.cmd = JsonConvert.DeserializeObject<Socketcmd>(data);
                if (GlobalVariables.GlobalSocketList != null)
                {
                    if (GlobalVariables.GlobalSocketList.Count > 0)
                    {
                        response = Request.CreateResponse(HttpStatusCode.OK, @"{""Status"": ""There are " + GlobalVariables.GlobalSocketList.Count + @" connections running. Please stop the current connections to create more connections.""}");
                        //@"{""Status"": ""There are " + GlobalVariables.GlobalSocketList.Count + @" connections opened.""}"

                    }
                    else
                    {
                        GlobalVariables.GlobalSocketList = AsynchronousClient.StartClient(GlobalVariables.cmd.Host, GlobalVariables.cmd.Port, GlobalVariables.cmd.Connections);
                        response = Request.CreateResponse(HttpStatusCode.OK, @"{""Status"": ""Requests created " + GlobalVariables.GlobalSocketList.Count + @" number of connections.""}");
                    }
                }
                else
                {
                    GlobalVariables.GlobalSocketList = AsynchronousClient.StartClient(GlobalVariables.cmd.Host, GlobalVariables.cmd.Port, GlobalVariables.cmd.Connections);
                    response = Request.CreateResponse(HttpStatusCode.OK, @"{""Status"": ""Requests created " + GlobalVariables.GlobalSocketList.Count + @" number of connections.""}");
                }

            }
            catch (Exception)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Unable to DeserializeObject" + data);
                return response;
            }
            return response;
        }

        //[Route("api/Socket/names")]
        public IEnumerable<string> GetNames()
        {
            return new string[] { "student1", "student2" };
        }

        // GET: api/Socket/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //[Route("api/Socket/Stop")]
        //[HttpGet]
        //public string Get(string value)
        //{
        //    if (value == "Stop")
        //    {
        //        //AsynchronousClient.StopClient(GlobalVariables.GlobalSocketList);
        //        value = "OK";
        //    }
        //    return "value";
        //}



        //// GET: api/Sock
        //public HttpResponseMessage Get()
        //{
        //    // Get a list of products from a database.
        //    //IEnumerable<Product> products = GetProductsFromDB();

        //    // Write the list to the response body.
        //    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "Test");
        //    return response;
        //}

        // POST: api/Socket
        //public void Post([FromBody]string value)
        //{

        //}

        //public HttpResponseMessage Post(dynamic value)
        //{
        //    HttpResponseMessage response;
        //    string data = JsonConvert.SerializeObject(value);

        //    try
        //    {
        //        Socketcmd socketcmd = JsonConvert.DeserializeObject<Socketcmd>(data);
        //        //GlobalVariables.GlobalSocketList = AsynchronousClient.StartClient(socketcmd.Host, socketcmd.Port, socketcmd.Connections);
        //        //AsynchronousClient.StopClient(GlobalVariables.GlobalSocketList);
        //    }
        //    catch (Exception)
        //    {
        //        response = Request.CreateResponse(HttpStatusCode.BadRequest, "Unable to DeserializeObject" + data);
        //        return response;
        //    }
        //    //Socketcmd socketcmd = JsonConvert.DeserializeObject<Socketcmd>(data);



        //    response = Request.CreateResponse(HttpStatusCode.OK, "Sockets created based in: \r\n" + data);
        //    return response;

        //}

        //// PUT: api/Socket/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Socket/5
        //public void Delete(int id)
        //{
        //}
    }
}
