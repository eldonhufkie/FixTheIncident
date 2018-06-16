using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BLL
{
    public class LoginHandler
    {
        Employee employee = new Employee();
        EmployeeLogin login = new EmployeeLogin();
        EmployeeDBAccess employeeHandler = new EmployeeDBAccess();

        public DataTable GetAllEmployeeLogin()
        {
            return employeeHandler.dtGetAllEmployeesLogin();
        }
        public DataTable dtGetEmployeeLogin(Employee emp)
       {
            return employeeHandler.dtGetEmployeeLogin(emp);
        }
    }
}
