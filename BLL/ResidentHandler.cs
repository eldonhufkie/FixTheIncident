using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public class ResidentHandler
    {
        ResidentDBAccess resHandler = null;
        public ResidentHandler()
        {
            resHandler = new ResidentDBAccess();
        }
        public bool AddNewResident(Resident res)
        {
            return resHandler.AddNewResident(res);
        }
        public DataTable dtGetAllResidents()
        {
            return resHandler.dtGetAllResidents();
        }
        public DataTable dtGetFaultByCategory(int residentID)
        {
            return resHandler.dtGetResident(residentID);
        }
        public DataTable dtGetResidentByContactInfo(Resident res)
        {
            return resHandler.dtGetResidentByContactInfo(res);
        }
    }
}
