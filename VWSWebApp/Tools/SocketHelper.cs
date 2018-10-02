using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VWSWebApp.Models;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;

namespace VWSWebApp.Tools
{
    public class SocketHelper
    {
        public static HttpResponseMessage SocketHelperConnectionNotFoundOrDisconnected()
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            Socketstatus sStatus = new Socketstatus();
            sStatus.ClosedSockets = 0;
            sStatus.OpenSockets = 0;
            sStatus.ConnectionStatus = SocketConnectionStatus.Disconnected;
            sStatus.ServerDateTime = DateTime.Now;

            var socketstatus = JsonConvert.SerializeObject(sStatus, Formatting.Indented);
            response.Content = new StringContent(socketstatus, System.Text.Encoding.UTF8, "application/json");
            response.StatusCode = HttpStatusCode.OK;
            return response;
        }

        public static HttpResponseMessage SocketHelperConnectionStatus()
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            var socketstatus = JsonConvert.SerializeObject(GlobalVariables.socketstatus, Formatting.Indented);
            response.Content = new StringContent(socketstatus, System.Text.Encoding.UTF8, "application/json");
            response.StatusCode = HttpStatusCode.OK;
            return response;
        }
    }
}