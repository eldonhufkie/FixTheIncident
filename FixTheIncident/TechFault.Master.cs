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
    public partial class TechFault1 : System.Web.UI.MasterPage
    {
        FaultTypeHandler handler = new FaultTypeHandler();
        EmployeeLogin sesh = new EmployeeLogin();
        LoginHandler loginHand = new LoginHandler();
        Employee emp = new Employee();
        protected void Page_Load(object sender, EventArgs e)
        {
            emp.EmployeeID = Convert.ToInt32(Request.Cookies["userid"].Value);
            if (loginHand.dtGetEmployeeLogin(emp).Rows.Count > 0)
            {
                emp.EmployeeID = Convert.ToInt32(loginHand.dtGetEmployeeLogin(emp).Rows[0][0]);
                if (loginHand.dtGetEmployeeLogin(emp).Rows[0]["description"].ToString().Trim() != "Technician")
                {
                    Response.Redirect("AccessDenied.aspx");// add unautorised page 
                }
                else
                {
                    if (Session["username"] == null)
                    {
                        Response.Redirect("Signin.aspx");
                    }
                    else
                    {
                        if (!IsPostBack)
                        {
                            lblUsername.InnerHtml = Session["username"].ToString();
                            sesh = Session["userID"] as EmployeeLogin;
                            int empid = int.Parse(Request.Cookies["userid"].Value);
                            //int empid = sesh.EmployeeID;

                        }
                    }
                }
            }

        }

        protected void btnLogOff_Click(object sender, EventArgs e)
        {
            Session["username"] = null;
            Response.Redirect("Signin.aspx");
        }
    }
}