using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;
using System.Configuration;

namespace FixTheIncident
{
    public partial class TechFaults : System.Web.UI.Page
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
                            dgUnattendedFaults.DataSource = handler.dtGetTechUnallocatedFaultsByID(empid);
                            dgUnattendedFaults.DataBind();
                            gvFaultsAttendedTo.DataSource = handler.dtGetTechFaultAttendedToByID(empid);
                            gvFaultsAttendedTo.DataBind();
                            gvFaultsAttendedTo.Visible = true;
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

        protected void dgUnassignedFaults_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgUnattendedFaults.PageIndex = e.NewPageIndex;
            dgUnattendedFaults.DataSource = handler.dtGetAllUnassignedFaults();
            dgUnattendedFaults.DataBind();
        }

        protected void gvAssignedFaults_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvFaultsAttendedTo.PageIndex = e.NewPageIndex;
            gvFaultsAttendedTo.DataSource = handler.dtGetAllUnassignedFaults();
            gvFaultsAttendedTo.DataBind();
        }

        protected void gvAssignedFaults_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                FaultLog faultLog = new FaultLog();
                faultLog.FaultID = Convert.ToInt32(gvFaultsAttendedTo.SelectedRow.Cells[1].Text);
                Session["FaultID"] = faultLog;
                Response.Redirect("HelpdeskViewFault.aspx");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected void dgUnassignedFaults_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FaultLog faultLog = new FaultLog();
                faultLog.FaultID = Convert.ToInt32(dgUnattendedFaults.SelectedRow.Cells[1].Text);
                Session["TFaultID"] = faultLog;
                Response.Redirect("TechFault.aspx");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}