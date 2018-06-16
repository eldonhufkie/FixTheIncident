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
    public partial class WebForm17 : System.Web.UI.Page
    {
        FaultTypeHandler faultHand = new FaultTypeHandler();
        FaultLog faultLog = new FaultLog();
        protected void Page_Load(object sender, EventArgs e)
        {
            gvOtherFaults.DataSource = faultHand.dtGetAllOtherFaults();
            gvOtherFaults.DataBind();
        }

        protected void gvOtherFaults_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvOtherFaults.PageIndex = e.NewPageIndex;
            gvOtherFaults.DataSource = faultHand.dtGetAllOtherFaults();
            gvOtherFaults.DataBind();
        }

        protected void gvOtherFaults_SelectedIndexChanged(object sender, EventArgs e)
        {
            faultLog.OtherID = Convert.ToInt32(gvOtherFaults.SelectedRow.Cells[1].Text);
            faultLog.OtherDescription = faultHand.dtGetOtherFaults(faultLog).Rows[0]["FaultOtherText"].ToString();

            Session["Other"] = faultLog;
            Response.Redirect("AddOtherFault.aspx");
        }
    }
}