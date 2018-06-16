using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class FaultTypeHandler
    {
        FaultTypeDBAccess faultHandler = null;

        public FaultTypeHandler()
        {
            faultHandler = new FaultTypeDBAccess();
        }
        public bool AddOtherTypeFault(FaultLog fault, Resident res)
        {
            return faultHandler.AddOtherTypeFault(fault, res);
        }
        public bool AddOtherFaultExistingResident(FaultLog fault, Resident res)
        {
            return faultHandler.AddOtherFaultExistingResident(fault, res);
        }
        public bool AddNewFault(Resident res, FaultLog fault)
        {
            return faultHandler.AddFault(fault, res);
        }
        public bool AddTechnicianToFault(FaultLog fault, Resident res)
        {
            return faultHandler.AddTechnicianToFault(fault, res);
        }
        public bool AddOtherFaultType(FaultLog fault)
        {
            return faultHandler.AddOtherFaultType(fault);
        }
        public DataTable dtGetFaultCategory()
        {
            return faultHandler.dtGetFaultCategory();
        }
        public DataTable dtGetFaultByCategory(FaultLog fl)
        {
            return faultHandler.dtGetFaultTypeByCategory(fl);
        }
        public DataTable dtGetFaultByCategory(int faultCategoryID)
        {
            return faultHandler.dtGetFaultTypeByCategory(faultCategoryID);
        }
        public DataTable dtGetSelectedFaultCategory(int faultCategoryID)
        {
            return faultHandler.dtGetFaultCategory(faultCategoryID);
        }
        public DataTable dtGetSearchedFault(FaultLog f)
        {
            return faultHandler.dtGetSearchedFault(f);
        }
        public DataTable dtGetAllUnassignedFaults()
        {
            return faultHandler.dtGetAllUnassignedFaults();
        }
        public DataTable GetUnassignedFault(int fault)
        {
            return faultHandler.GetUnassignedFault(fault);
        }
        public DataTable dtGetAllPriorities()
        {
            return faultHandler.dtGetAllPriorities();
        }
        public DataTable dtGetAllAssignedFaults()
        {
            return faultHandler.dtGetAllAssignedFaults();
        }
        public DataTable dtGetTechUnallocatedFaultsByID(int empid)
        {
            return faultHandler.dtGetTechUnallocatedFaultsByID(empid);
        }
        public DataTable dtGetTechFaultAttendedToByID(int empid)
        {
            return faultHandler.dtGetTechFaultAttendedToByID(empid);
        }
        public DataTable dtGetTechUnallocatedFault(int empid)
        {
            return faultHandler.dtGetTechUnallocatedFault(empid);
        }
        public DataTable dtGetAllStatuses()
        {
            return faultHandler.dtGetAllStatuses();
        }
        public List<FaultLog> GetStatusList()
        {
            return faultHandler.GetStatusList();
        }
        public bool AddAFaultExistingResident(FaultLog fault, Resident res)
        {
            return faultHandler.AddAFaultExistingResident(fault, res);
        }
        public DataTable dtGetAllExpertise()
        {
            return faultHandler.dtGetAllExpertise();
        }
        public DataTable dtGetAllOtherFaults()
        {
            return faultHandler.dtGetAllOtherFaults();
        }
        public DataTable dtGetOtherFaults(FaultLog fault)
        {
            return faultHandler.dtGetOtherFaults(fault);
        }
        public DataTable dtGetCommentsByFaultID(FaultLog fault)
        {
            return faultHandler.dtGetCommentsByFaultID(fault);
        }
    }
}
