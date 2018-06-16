using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EmployeeHandler
    {
        EmployeeDBAccess employeeHandler = null;

        public EmployeeHandler()
        {
            employeeHandler = new EmployeeDBAccess();
        }
        public bool AddNewEmployeeExpertise(Employee emp, EmployeeType emptype)
        {
            return employeeHandler.AddNewEmployeeExpertise(emp, emptype);
        }
        public bool AddEmployee(Employee emp, EmployeeType emptype)
        {
            return employeeHandler.AddNewEmployee(emp, emptype);
        }
        public DataTable dtGetAllEmployeeType()
        {
            return employeeHandler.dtGetAllEmployeeType();
        }
        
    }
}
