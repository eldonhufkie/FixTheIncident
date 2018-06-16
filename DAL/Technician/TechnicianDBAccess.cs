using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class TechnicianDBAccess
    {
        //public bool AddNewTechnician(Technician t, Employee emp)
        //{
        //    SqlParameter[] parameters = new SqlParameter[]
        //    {

        //        new SqlParameter("@technicianName",emp.EmpFullName ),
        //        //new SqlParameter("technicianID", emp.EmpSurname),
        //        new SqlParameter("@Employeename",emp.EmpEmailAddress)
        //        //new SqlParameter("@Employeeid", emp.PhoneNumber)
        //    };
        //    return SqlDBHelper.ExecuteNonQuery("usp_InsertEmployee", CommandType.StoredProcedure,
        //        parameters);
        //}//End AddNewEmployee

        //public bool UpdateEmployee(Employee emp)
        //{
        //    SqlParameter[] parameters = new SqlParameter[]
        //    {
        //       new SqlParameter("@Employeeid", emp.EmployeeID),
        //        new SqlParameter("@Employeename",emp.EmpFullName ),
        //        new SqlParameter("@Employeeid", emp.EmpSurname),
        //        new SqlParameter("@Employeename",emp.EmpEmailAddress ),
        //        new SqlParameter("@Employeeid", emp.EmpPhoneNumber)
        //    };
        //    return SqlDBHelper.ExecuteNonQuery("usp_UpdateEmployee", CommandType.StoredProcedure,
        //        parameters);
        //}//End UpdateEmployee

        //public bool DeleteEmployee(int EmployeeID)
        //{
        //    SqlParameter[] parameters = new SqlParameter[]
        //    {
        //        new SqlParameter("@EmployeeID", EmployeeID)
        //    };
        //    return SqlDBHelper.ExecuteNonQuery("uspDeleteEmployee", CommandType.StoredProcedure,
        //        parameters);
        //}//End DeleteEmployee
        public FaultLog GetStatusesViaReferenceNumber(string referenceNo)
        {
            FaultLog fault = null;
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@reference", referenceNo)
            };
            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("usp_GetStatusesPerReferenceNumber",
                CommandType.StoredProcedure, parameters))
            {
                if (table.Rows.Count >= 1)
                {
                    DataRow row = table.Rows[0];
                    fault = new FaultLog();
                   
                    fault.StatusDescription = row["CommentText"].ToString();

                }//end if
            }//end using
            return fault;
        }//End GetFaultDetails
        //Datatables
        public DataTable dtGetStatusesViaReferenceNumber(string referenceNo)
        {
            DataTable dt = new DataTable();
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@reference",referenceNo)
            };
            dt = SqlDBHelper.ExecuteParamerizedSelectCommand("usp_GetStatusesPerReferenceNumber",
                CommandType.StoredProcedure, para);
            return dt;
        }
        public DataTable dtGetAllTechnicians()
        {
            DataTable dt = SqlDBHelper.ExecuteSelectCommand("usp_GetAllTechnicians", CommandType.StoredProcedure);
            return dt;
        }
        public DataTable dtGetTechniciansPerCategory(int categoryID)
        {
            DataTable dt = new DataTable();
            SqlParameter[] par = new SqlParameter[]
                {
                new SqlParameter("@categoryID",categoryID)
            };
            dt = SqlDBHelper.ExecuteParamerizedSelectCommand("usp_GetTechniciansPerCategory", CommandType.StoredProcedure, par);
            return dt;
        }

        public DataTable dtGetAllTechniciansPerCategory(int categoryID)
        {
            DataTable dt = new DataTable();
            SqlParameter[] par = new SqlParameter[]
                {
                new SqlParameter("@categoryID",categoryID)
            };
            dt = SqlDBHelper.ExecuteParamerizedSelectCommand("usp_GetAllTechniciansPerCategory", CommandType.StoredProcedure, par);
            return dt;
        }
        public bool UpdateFault(FaultLog fault, Technician tech)
        {
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@statusID", fault.StatusID),
                new SqlParameter("@faultID", fault.FaultID),
                new SqlParameter("@comment", tech.Comment),
                new SqlParameter("@techID",tech.TechnicianID),
                new SqlParameter("@test",fault.FaultDescription)
                
            };
            return SqlDBHelper.ExecuteNonQuery("usp_UpdateFaultStatus", CommandType.StoredProcedure, par);
        }
        public bool CloseFault(FaultLog fault,Technician tech)
        {
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@statusID", fault.StatusID),
                new SqlParameter("@faultID", fault.FaultID),
                new SqlParameter("@comment",tech.Comment)
            };
            return SqlDBHelper.ExecuteNonQuery("usp_CloseFault", CommandType.StoredProcedure, par);
        }
        //public DataTable dtGet
    }//End class EmployeeDBAccess
}//End namespace DAL
