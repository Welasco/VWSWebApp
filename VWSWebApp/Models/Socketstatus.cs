using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VWSWebApp.Tools;

namespace VWSWebApp.Models
{
    //public enum SocketStatus
    //{
    //    Connected,
    //    Disconnected
    //}
    public class SocketConnectionStatus
    {
        public const string Connected = "Connected";
        public const string Disconnected = "Disconnected";

    }
    public class Socketstatus
    {
        public int OpenSockets { get; set; }
        public int ClosedSockets { get; set; }

        public string ConnectionStatus {get; set;}
        public DateTime ServerDateTime { get; set; }

    }
}