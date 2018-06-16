using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class FaultTypeDBAccess
    {
        public bool AddOtherTypeFault(FaultLog fault, Resident res)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
            //    new SqlParameter("@residentID",res.ResidentID),
                 new SqlParameter("@fullname",res.FullName),
                new SqlParameter("@surname",res.Surname),
                new SqlParameter("@phoneno",res.PhoneNumber),
                new SqlParameter("@email",res.EmailAddress),
                new SqlParameter("@faultlongitude",fault.FaultLongitude),
                new SqlParameter("@faultlatitude",fault.FaultLatitude),
                new SqlParameter("@faultdescription",fault.FaultDescription),
                    new SqlParameter("@locationdescription",fault.LocationDescription),
                 new SqlParameter("@test",res.ResidentID),
                new SqlParameter("@faultCategory",fault.SelectedFaultCategory),
                new SqlParameter("@referenceNumber",fault.ReferenceNumber),

                new SqlParameter("@time",fault.LoggedFaultDateAndTime),
               new SqlParameter("@faultLogID",fault.FaultID),
                new SqlParameter("@otherDescription",fault.OtherDescription)

                };
            return SqlDBHelper.ExecuteNonQuery("usp_AddOtherTypeFault", CommandType.StoredProcedure,
                parameters);
        }//End AddNewFault
        public bool AddFault(FaultLog fault, Resident res)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@fullname",res.FullName),
                new SqlParameter("@surname",res.Surname),
                new SqlParameter("@phoneno",res.PhoneNumber),
                new SqlParameter("@email",res.EmailAddress),
                new SqlParameter("@faultlongitude",fault.FaultLongitude),
                new SqlParameter("@faultlatitude",fault.FaultLatitude),
                new SqlParameter("@faultdescription",fault.FaultDescription),
                new SqlParameter("@locationdescription",fault.LocationDescription),
                new SqlParameter("@faulttype", fault.SelectedFault),
                new SqlParameter("@faultCategory",fault.SelectedFaultCategory),
                new SqlParameter("@referenceNumber",fault.ReferenceNumber),
                new SqlParameter("@test",res.ResidentID),
                new SqlParameter("@time",fault.LoggedFaultDateAndTime),
               new SqlParameter("@faultLogID",fault.FaultID)
                };
            return SqlDBHelper.ExecuteNonQuery("sp_AddAFault", CommandType.StoredProcedure,
                parameters);
        }//End AddNewFault
        public bool AddAFaultExistingResident(FaultLog fault, Resident res)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {

                new SqlParameter("@faultlongitude",fault.FaultLongitude),
                new SqlParameter("@faultlatitude",fault.FaultLatitude),
                new SqlParameter("@faultdescription",fault.FaultDescription),
                new SqlParameter("@locationdescription",fault.LocationDescription),
                new SqlParameter("@faulttype", fault.SelectedFault),
                new SqlParameter("@faultCategory",fault.SelectedFaultCategory),
                new SqlParameter("@referenceNumber",fault.ReferenceNumber),
                new SqlParameter("@resID",res.ResidentID),
                new SqlParameter("@time",fault.LoggedFaultDateAndTime),
                new SqlParameter("@faultLogID",fault.FaultID)
                };
            return SqlDBHelper.ExecuteNonQuery("usp_AddAFaultExistingResident", CommandType.StoredProcedure,
                parameters);
        }//End AddNewFault
        public bool AddOtherFaultExistingResident(FaultLog fault, Resident res)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {

                new SqlParameter("@faultlongitude",fault.FaultLongitude),
                new SqlParameter("@faultlatitude",fault.FaultLatitude),
                new SqlParameter("@faultdescription",fault.FaultDescription),
                new SqlParameter("@locationdescription",fault.LocationDescription),
                //new SqlParameter("@faulttype", fault.SelectedFault),
                new SqlParameter("",fault.OtherDescription),
                new SqlParameter("@faultCategory",fault.SelectedFaultCategory),
                new SqlParameter("@referenceNumber",fault.ReferenceNumber),
                new SqlParameter("@resID",res.ResidentID),
                new SqlParameter("@time",fault.LoggedFaultDateAndTime),
                new SqlParameter("@faultLogID",fault.FaultID)
                };
            return SqlDBHelper.ExecuteNonQuery("usp_AddOtherFaultExistingResident", CommandType.StoredProcedure,
                parameters);
        }//End AddNewFault
        public bool AddOtherFaultType(FaultLog fault)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@categoryID",fault.SelectedFaultCategory),
                new SqlParameter("@typeDescription", fault.OtherDescription),
                new SqlParameter("@otherTypeID",fault.OtherID)

            };
            return SqlDBHelper.ExecuteNonQuery("usp_AddOtherFaultType", CommandType.StoredProcedure,
                parameters);
        }//End UpdateFault
        Resident res = new Resident();
        public bool AddTechnicianToFault(FaultLog fault, Resident res)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@priorityID",fault.Selectedpriority),
                new SqlParameter("@technicianID", fault.SelectedTechnician),
                new SqlParameter("@residentID",res.ResidentID),
                new SqlParameter("@statusID",fault.StatusID),
                new SqlParameter("@faulLogID",fault.FaultID)
            };
            return SqlDBHelper.ExecuteNonQuery("usp_AddTechnicianToFault", CommandType.StoredProcedure,
                parameters);
        }//End UpdateFault

        public bool DeleteFault(int faultID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@faultID", faultID)
            };
            return SqlDBHelper.ExecuteNonQuery("uspDeleteFault", CommandType.StoredProcedure,
                parameters);
        }//End DeleteFault

        public FaultLog GetFaultDetails(int faultID)
        {
            FaultLog fault = null;
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@faultID", faultID)
            };
            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("uspReturnFault",
                CommandType.StoredProcedure, parameters))
            {
                if (table.Rows.Count == 1)
                {
                    DataRow row = table.Rows[0];
                    fault = new FaultLog();
                    Resident res = new Resident();
                    fault.SelectedFaultCategory = Convert.ToInt32(row["FaultCategoryID"]);
                    fault.SelectedFault = Convert.ToInt32(row["FaultTypeID"]);
                    res.ResidentID = Convert.ToInt32(row["ResidentID"]);
                    fault.FaultDescription = row["FaultLogDescription"].ToString();
                    fault.LocationDescription = row["LocationInformation"].ToString();
                    fault.FaultLatitude = row["FaultLatitude"].ToString();
                    fault.FaultLongitude = row["FaultLongitude"].ToString();
                    fault.ReferenceNumber = row["ReferenceNumber"].ToString();

                }//end if
            }//end using
            return fault;
        }//End GetFaultDetails

        public List<FaultLog> GetFaultList()
        {
            List<FaultLog> faultList = null;

            using (DataTable table = SqlDBHelper.ExecuteSelectCommand("usp_GetAllFaults",
                CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    faultList = new List<FaultLog>();
                    foreach (DataRow row in table.Rows)
                    {
                        FaultLog fault = new FaultLog();
                        Resident res = new Resident();
                        fault.SelectedFaultCategory = Convert.ToInt32(row["FaultCategoryID"]);
                        fault.SelectedFault = Convert.ToInt32(row["FaultTypeID"]);
                        res.ResidentID = Convert.ToInt32(row["ResidentID"]);
                        fault.FaultDescription = row["FaultLogDescription"].ToString();
                        fault.LocationDescription = row["LocationInformation"].ToString();
                        fault.FaultLatitude = row["FaultLatitude"].ToString();
                        fault.FaultLongitude = row["FaultLongitude"].ToString();
                        fault.ReferenceNumber = row["ReferenceNumber"].ToString();
                        faultList.Add(fault);
                    }
                }//end if
            }//end using
            return faultList;
        }
        public List<FaultLog> GetStatusList()
        {
            List<FaultLog> statusList = null;

            using (DataTable table = SqlDBHelper.ExecuteSelectCommand("usp_GetAllStatuses",
                CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    statusList = new List<FaultLog>();
                    foreach (DataRow row in table.Rows)
                    {
                        FaultLog fault = new FaultLog();
                        fault.StatusID = Convert.ToInt32(row["FaultSttatusID"]);
                        fault.StatusDescription = row["FaultStatusDescription"].ToString();

                        statusList.Add(fault);
                    }
                }//end if
            }//end using
            return statusList;
        }
        public List<FaultLog> GetLocationList()
        {
            List<FaultLog> LocationList = null;

            using (DataTable table = SqlDBHelper.ExecuteSelectCommand("usp_GetAllLocations", CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    LocationList = new List<FaultLog>();
                    foreach (DataRow row in table.Rows)
                    {
                        FaultLog fault = new FaultLog();
                        fault.FaultID = Convert.ToInt32(row["FaultLogID"].ToString());
                        fault.LocationDescription = row["LocationInformation"].ToString();
                        fault.FaultLatitude = row["FaultLatitude"].ToString();
                        fault.FaultLongitude = row["FaultLongitude"].ToString();
                        LocationList.Add(fault);
                    }
                }//end if
            }//end using
            return LocationList;
        }
        //Datatables
        public DataTable dtGetFaultCategory()
        {
            DataTable dt = SqlDBHelper.ExecuteSelectCommand("usp_GetFaultCategory", CommandType.StoredProcedure);
            return dt;
        }
        public DataTable dtGetFaultTypeByCategory(int faultCategory)
        {
            DataTable dt = new DataTable();
            SqlParameter[] par = new SqlParameter[]
                {
                new SqlParameter("@categoryID",faultCategory)
            };
            dt = SqlDBHelper.ExecuteParamerizedSelectCommand("usp_GetFaultByCategoryID", CommandType.StoredProcedure, par);
            return dt;
        }
        //public DataTable dtGetFaultTypeByCategory(int faultCategory)
        //{
        //    DataTable dt = new DataTable();
        //    SqlParameter[] par = new SqlParameter[]
        //        {
        //        new SqlParameter("@categoryID",faultCategory)t)
        //    };
        //    dt = SqlDBHelper.ExecuteParamerizedSelectCommand("usp_GetFaultByCategoryID", CommandType.StoredProcedure, par);
        //    return dt;
        //}
        public DataTable dtGetFaultTypeByCategory(FaultLog fl)
        {
            DataTable dt = new DataTable();
            SqlParameter[] par = new SqlParameter[]
                {
                new SqlParameter("@categoryID",fl.SelectedFaultCategory),
                new SqlParameter("@faulttypeID",fl.SelectedFault)
            };
            dt = SqlDBHelper.ExecuteParamerizedSelectCommand("usp_GetSpesificFaultType", CommandType.StoredProcedure, par);
            return dt;
        }
        public DataTable dtGetFaultCategory(int faultCategoryID)
        {
            DataTable dt = new DataTable();
            SqlParameter[] par = new SqlParameter[]
                {
                new SqlParameter("@categoryID",faultCategoryID)
            };
            dt = SqlDBHelper.ExecuteParamerizedSelectCommand("usp_SelectCategory", CommandType.StoredProcedure, par);
            return dt;
        }
        public DataTable dtGetSearchedFault(FaultLog f)
        {
            DataTable dt = new DataTable();
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@referenceNumber",f.ReferenceNumber)
            };
            dt = SqlDBHelper.ExecuteParamerizedSelectCommand("usp_GetSearchedFault", CommandType.StoredProcedure, par);
            return dt;
        }
        public DataTable dtGetAllUnassignedFaults()
        {
            DataTable dt = new DataTable();
            dt = SqlDBHelper.ExecuteSelectCommand("usp_GetAllUnassignedFaults", CommandType.StoredProcedure);
            return dt;
        }
        public DataTable GetUnassignedFault(int fault)
        {
            DataTable dt = new DataTable();
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@faultLogID",fault)
            };
            dt = SqlDBHelper.ExecuteParamerizedSelectCommand("usp_GetUnassignedFault", CommandType.StoredProcedure, par);
            return dt;
        }
        public DataTable dtGetAllPriorities()
        {
            DataTable dt = new DataTable();
            dt = SqlDBHelper.ExecuteSelectCommand("usp_GetAllPriorities", CommandType.StoredProcedure);
            return dt;
        }
        public DataTable dtGetAllAssignedFaults()
        {
            DataTable dt = new DataTable();
            dt = SqlDBHelper.ExecuteSelectCommand("usp_GetAssignedFaults", CommandType.StoredProcedure);
            return dt;
        }
        public DataTable dtGetAllLocations()
        {
            DataTable dt = new DataTable();
            dt = SqlDBHelper.ExecuteSelectCommand("usp_GetAllLocations", CommandType.StoredProcedure);
            return dt;
        }
        public DataTable dtGetTechUnallocatedFaultsByID(int empid)
        {

            DataTable dt = new DataTable();
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@emp",empid)
            };
            dt = SqlDBHelper.ExecuteParamerizedSelectCommand("usp_GetTechUnallocatedFaultsByID", CommandType.StoredProcedure, par);
            return dt;
        }
        public DataTable dtGetTechFaultAttendedToByID(int empid)
        {

            DataTable dt = new DataTable();
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@emp",empid)
            };
            dt = SqlDBHelper.ExecuteParamerizedSelectCommand("usp_GetTechFaultAttendedToByID", CommandType.StoredProcedure, par);
            return dt;
        }
        public DataTable dtGetTechUnallocatedFault(int empid)
        {

            DataTable dt = new DataTable();
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@emp",empid)
            };
            dt = SqlDBHelper.ExecuteParamerizedSelectCommand("usp_GetTechUnallocatedFault", CommandType.StoredProcedure, par);
            return dt;
        }
        public DataTable dtGetAllStatuses()
        {
            DataTable dt = new DataTable();
            dt = SqlDBHelper.ExecuteSelectCommand("usp_GetAllStatuses", CommandType.StoredProcedure);
            return dt;
        }
        public DataTable dtGetAllExpertise()
        {
            DataTable dt = new DataTable();
            dt = SqlDBHelper.ExecuteSelectCommand("usp_GetAllExpertise", CommandType.StoredProcedure);
            return dt;
        }
        public DataTable dtGetAllOtherFaults()
        {
            DataTable dt = new DataTable();
            dt = SqlDBHelper.ExecuteSelectCommand("usp_GetAllOtherFaults", CommandType.StoredProcedure);
            return dt;
        }
        public DataTable dtGetOtherFaults(FaultLog fault)
        {
            DataTable dt = new DataTable();
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@otherID",fault.OtherID)
            };
            dt = SqlDBHelper.ExecuteParamerizedSelectCommand("usp_GetOtherFault", CommandType.StoredProcedure, par);
            return dt;
        }
        public DataTable dtGetCommentsByFaultID(FaultLog fault)
        {
            DataTable dt = new DataTable();
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@faultID",fault.FaultID)
            };
            dt = SqlDBHelper.ExecuteParamerizedSelectCommand("usp_GetCommentsByFaultID", CommandType.StoredProcedure, par);
            return dt;
        }
    }//End class FaultDBAccess
}//End namespace DAL
