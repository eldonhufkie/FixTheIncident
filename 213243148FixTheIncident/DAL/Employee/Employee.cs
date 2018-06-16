using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string EmpFullName { get; set; }
        public string EmpSurname { get; set; }
 
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string EmpEmailAddress { get; set; }
        public string EmpPhoneNumber { get; set; }
        public string EmpIDNumber { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public int EmployeeType { get; set; }
        public int ExpertiseID { get; set; }
    }
}
