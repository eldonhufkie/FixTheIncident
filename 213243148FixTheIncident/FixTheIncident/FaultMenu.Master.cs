using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;


namespace FixTheIncident
{
    public partial class FaultMenu : System.Web.UI.MasterPage
    {
        LoginHandler loginHand = new LoginHandler();
        Employee emp = new Employee();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (loginHand.dtGetEmployeeLogin(emp).Rows.Count > 0)
            {
                emp.EmployeeID = Convert.ToInt32(loginHand.dtGetEmployeeLogin(emp).Rows[0][0]);
                if (loginHand.dtGetEmployeeLogin(emp).Rows[0]["description"].ToString().Trim() != "Technician")
                {
                    Response.Redirect("");// add unautorised page 
                }
            }
        }
    }
}