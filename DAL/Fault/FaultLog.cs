using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FaultLog
    {
        public int FaultID { get; set; }
        public string FaultLongitude { get; set; }
        public string FaultLatitude { get; set; }
        public string LocationDescription { get; set; }
        public DateTime LoggedFaultDateAndTime { get; set; }
        public string FaultDescription { get; set; }
        public int SelectedFaultCategory { get; set; }
        public int SelectedFault { get; set; }
        public string ReferenceNumber { get; set; }
        public int Selectedpriority { get; set; }
        public int SelectedTechnician { get; set; }
        public int StatusID { get; set; }
        public string StatusDescription { get; set; }
        public int OtherID { get; set; }
        public string OtherDescription { get; set; }
    }
}
