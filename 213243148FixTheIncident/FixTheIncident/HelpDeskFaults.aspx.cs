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
    public partial class WebForm9 : System.Web.UI.Page
    {
        FaultTypeHandler handler = new FaultTypeHandler();
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "All Logged Faults";
            if (Session["username"] == null)
            {
                Response.Redirect("Signin.aspx");
            }
            else
            {
                Technician tech = new Technician();
                if (!IsPostBack)
                {
                    
                    dgUnassignedFaults.DataSource = handler.dtGetAllUnassignedFaults();
                    dgUnassignedFaults.DataBind();
                    gvAssignedFaults.DataSource = handler.dtGetAllAssignedFaults();
                    gvAssignedFaults.DataBind();
                    gvAssignedFaults.Visible = true;
                }
            }
        }

        protected void dgUnassignedFaults_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FaultLog faultLog = new FaultLog();
                faultLog.FaultID = Convert.ToInt32(dgUnassignedFaults.SelectedRow.Cells[1].Text);
                Session["FaultID"] = faultLog;
                Response.Redirect("HelpdeskViewFault.aspx");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        protected void gvAssignedFaults_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FaultLog faultLog = new FaultLog();
                faultLog.FaultID = Convert.ToInt32(gvAssignedFaults.SelectedRow.Cells[1].Text);
                Session["FaultID"] = faultLog;
                Response.Redirect("HelpdeskViewFault.aspx");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        protected void dgUnassignedFaults_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgUnassignedFaults.PageIndex = e.NewPageIndex;
            dgUnassignedFaults.DataSource = handler.dtGetAllUnassignedFaults();
            dgUnassignedFaults.DataBind();
        }
        protected void gvAssignedFaults_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAssignedFaults.PageIndex = e.NewPageIndex;
            gvAssignedFaults.DataSource = handler.dtGetAllUnassignedFaults();
            gvAssignedFaults.DataBind();
        }
    }
}