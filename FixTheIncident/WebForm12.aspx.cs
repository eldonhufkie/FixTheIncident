using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FixTheIncident
{
    public partial class WebForm12 : System.Web.UI.Page
    {
        FaultTypeHandler handler = new FaultTypeHandler();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dgUnassignedFaults.DataSource = handler.dtGetAllUnassignedFaults();
                dgUnassignedFaults.DataBind();
                gvAssignedFaults.DataSource = handler.dtGetAllAssignedFaults();
                gvAssignedFaults.DataBind();
                gvAssignedFaults.Visible = true;
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

        }

        protected void dgUnassignedFaults_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            dgUnassignedFaults.PageIndex = e.NewPageIndex;
            dgUnassignedFaults.DataSource = handler.dtGetAllUnassignedFaults();
            dgUnassignedFaults.DataBind();
        }
    }
}