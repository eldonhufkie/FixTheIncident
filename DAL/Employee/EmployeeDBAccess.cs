using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class EmployeeDBAccess
    {
        public bool AddNewEmployee(Employee emp, EmployeeType emptype)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@employeeID", emp.EmployeeID),
                new SqlParameter("@employeeName",emp.EmpFullName),
                new SqlParameter("@employeeSurname", emp.EmpSurname),
                new SqlParameter("@emailAddress",emp.EmpEmailAddress),
                 new SqlParameter("@contactNumber",emp.EmpPhoneNumber),
                new SqlParameter("@addressLineOne", emp.AddressLine1),
                new SqlParameter("@addressLineTwo",emp.AddressLine2),
                new SqlParameter("@suburb",emp.Suburb),
                new SqlParameter("@areaCode", emp.PostalCode),
                new SqlParameter("@employeeType",emptype.EmployeeTypeID),
                 new SqlParameter("@employeeIDNo",emp.EmpIDNumber),
                new SqlParameter("@gender", emp.Gender),
                new SqlParameter("@dob",emp.DateOfBirth)
            };
            return SqlDBHelper.ExecuteNonQuery("usp_AddEmployee", CommandType.StoredProcedure,
                parameters);
        }//End AddNewEmployee

        public bool AddNewEmployeeExpertise(Employee emp, EmployeeType emptype)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@employeeID", emp.EmployeeID),
                new SqlParameter("@employeeName",emp.EmpFullName),
                new SqlParameter("@employeeSurname", emp.EmpSurname),
                new SqlParameter("@emailAddress",emp.EmpEmailAddress),
                 new SqlParameter("@contactNumber",emp.EmpPhoneNumber),
                new SqlParameter("@addressLineOne", emp.AddressLine1),
                new SqlParameter("@addressLineTwo",emp.AddressLine2),
                new SqlParameter("@suburb",emp.Suburb),
                new SqlParameter("@areaCode", emp.PostalCode),
                new SqlParameter("@employeeType",emptype.EmployeeTypeID),
                 new SqlParameter("@employeeIDNo",emp.EmpIDNumber),
                new SqlParameter("@gender", emp.Gender),
                new SqlParameter("@dob",emp.DateOfBirth),
                new SqlParameter("@expertiseID",emp.ExpertiseID)
            };
            return SqlDBHelper.ExecuteNonQuery("usp_AddEmployeeExpertise", CommandType.StoredProcedure,
                parameters);
        }//End AddNewEmployee

        public bool UpdateEmployee(Employee emp)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {

                new SqlParameter("@employeeName",emp.EmpFullName),
                new SqlParameter("@employeeSurname", emp.EmpSurname),
                new SqlParameter("@emailAddress",emp.EmpEmailAddress),
                 new SqlParameter("@contactNumber",emp.EmpPhoneNumber),
                new SqlParameter("@addressLineOne", emp.AddressLine1),
                new SqlParameter("@addressLineTwo",emp.AddressLine2),
                new SqlParameter("@suburb",emp.Suburb),
                new SqlParameter("@areaCode", emp.PostalCode),
                new SqlParameter("@employeeType",emp.EmployeeType),
                 new SqlParameter("@employeeIDNo",emp.EmpIDNumber),
                new SqlParameter("@gender", emp.Gender),
                new SqlParameter("@dob",emp.DateOfBirth)
            };
            return SqlDBHelper.ExecuteNonQuery("usp_UpdateEmployee", CommandType.StoredProcedure,
                parameters);
        }//End UpdateEmployee

        public bool DeleteEmployee(int EmployeeID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@EmployeeID", EmployeeID)
            };
            return SqlDBHelper.ExecuteNonQuery("uspDeleteEmployee", CommandType.StoredProcedure,
                parameters);
        }//End DeleteEmployee

        //Datatables
        public DataTable dtGetAllEmployees()
        {
            DataTable dt = SqlDBHelper.ExecuteSelectCommand("usp_GetAllEmployees", CommandType.StoredProcedure);
            return dt;
        }
        public DataTable dtGetAllEmployeeType()
        {
            DataTable dt = SqlDBHelper.ExecuteSelectCommand("usp_GetEmployeeType", CommandType.StoredProcedure);
            return dt;
        }
        public DataTable dtGetEmployee(int EmployeeID)
        {
            DataTable dt = new DataTable();
            SqlParameter[] par = new SqlParameter[]
                {
                new SqlParameter("@EmployeeID",EmployeeID)
            };
            dt = SqlDBHelper.ExecuteParamerizedSelectCommand("usp_GetEmployee", CommandType.StoredProcedure, par);
            return dt;
        }
        public DataTable dtGetAllEmployeesLogin()
        {
            DataTable dt = new DataTable();
            dt = SqlDBHelper.ExecuteSelectCommand("usp_GetEmployeeLoginDetails", CommandType.StoredProcedure);
            return dt;
        }
        public DataTable dtGetEmployeeLogin(Employee emp)
        {
            DataTable dt = new DataTable();
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@empID",emp.EmployeeID)
            };
            dt = SqlDBHelper.ExecuteParamerizedSelectCommand("usp_GetLoginUser", CommandType.StoredProcedure, par);
            return dt;
        }
        //public DataTable dtGet
    }//End class EmployeeDBAccess
}//End namespace DAL
