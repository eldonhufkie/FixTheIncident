using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL;

namespace LocationService.Controllers
{
    public class LocationController : ApiController
    {
        FaultTypeDBAccess fault = new FaultTypeDBAccess();
        public IEnumerable<FaultLog> GET()
        {
            return fault.GetLocationList();
        }

    }
}
