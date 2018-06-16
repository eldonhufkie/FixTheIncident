using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public class TechnicianHandler
    {
        TechnicianDBAccess TechnicianHandller = null;
        public TechnicianHandler()
        {
            TechnicianHandller = new TechnicianDBAccess();
        }

        public DataTable dtGetTechnicianByCategory(int categoryID)
        {
            return TechnicianHandller.dtGetTechniciansPerCategory(categoryID);
        }
        public DataTable dtGetAllTechniciansPerCategory(int categoryID)
        {
            return TechnicianHandller.dtGetAllTechniciansPerCategory(categoryID);
        }
        public bool UpdateFault(FaultLog fault, Technician tech)
        {
            return TechnicianHandller.UpdateFault(fault, tech);
        }
        public bool CloseFault(FaultLog fault, Technician tech)
        {
            return TechnicianHandller.CloseFault(fault, tech);
        }
        public FaultLog GetStatusesViaReferenceNumber(string referenceNo)
        {
            return TechnicianHandller.GetStatusesViaReferenceNumber(referenceNo);
        }
        public DataTable dtGetStatusesViaReferenceNumber(string referenceNo)
        {
            return TechnicianHandller.dtGetStatusesViaReferenceNumber(referenceNo);
        }
    }
}
