using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ProjectDefinition.Models
{
    public class Service
    {

        [DisplayName("Projenin Kodu")]
        public string ProjectCode { get; set; }

        [DisplayName("Servis Adı")]
        public string ServiceName { get; set; }

        public string RemoteEndPointInt { get; set; }

        public string RemoteEndPointUat { get; set; }

        public string RemoteEndPointProd { get; set; }

        public string GatewayEndPointInt { get; set; }

        public string GatewayEndPointUat { get; set; }

        public string GatewayEndPointProd { get; set; }



    }
}