using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class ResidentDBAccess
    {
        public bool AddNewResident(Resident res)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
               
                new SqlParameter("@residentname",res.FullName ),
                //new SqlParameter("@residentid", res.Surname),
                new SqlParameter("@residentname",res.EmailAddress )
                //new SqlParameter("@residentid", res.PhoneNumber)
            };
            return SqlDBHelper.ExecuteNonQuery("usp_InsertResident", CommandType.StoredProcedure,
                parameters);
        }//End AddNewResident

        public bool UpdateResident(Resident res)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
               new SqlParameter("@residentid", res.ResidentID),
                new SqlParameter("@residentname",res.FullName ),
                new SqlParameter("@residentid", res.Surname),
                new SqlParameter("@residentname",res.EmailAddress ),
                new SqlParameter("@residentid", res.PhoneNumber)
            };
            return SqlDBHelper.ExecuteNonQuery("usp_UpdateResident", CommandType.StoredProcedure,
                parameters);
        }//End UpdateResident

        public bool DeleteResident(int ResidentID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@residentID", ResidentID)
            };
            return SqlDBHelper.ExecuteNonQuery("uspDeleteResident", CommandType.StoredProcedure,
                parameters);
        }//End DeleteResident

        //Datatables
        public DataTable dtGetAllResidents()
        {
            DataTable dt = SqlDBHelper.ExecuteSelectCommand("usp_GetAllResidents", CommandType.StoredProcedure);
            return dt;
        }
        public DataTable dtGetResident(int residentID)
        {
            DataTable dt = new DataTable();
            SqlParameter[] par = new SqlParameter[]
                {
                new SqlParameter("@residentID",residentID)
            };
            dt = SqlDBHelper.ExecuteParamerizedSelectCommand("usp_GetResident", CommandType.StoredProcedure, par);
            return dt;
        }
        public DataTable dtGetResidentByContactInfo(Resident res)
        {
            DataTable dt = new DataTable();
            SqlParameter[] par = new SqlParameter[]{
                new SqlParameter("@name",res.FullName),
                new SqlParameter("@surname",res.Surname),
                new SqlParameter("@email",res.EmailAddress),
                new SqlParameter("@phoneNo",res.PhoneNumber)
            };
            dt = SqlDBHelper.ExecuteParamerizedSelectCommand("usp_GetResidentByContactInfo", CommandType.StoredProcedure, par);

            return dt;
        }
        //public DataTable dtGet
    }//End class ResidentDBAccess
}//End namespace DAL
