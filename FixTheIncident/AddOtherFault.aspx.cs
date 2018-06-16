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
    public partial class WebForm18 : System.Web.UI.Page
    {
        FaultLog fault = new FaultLog();
        FaultTypeHandler faultHand = new FaultTypeHandler();
        protected void Page_Load(object sender, EventArgs e)
        {
            fault = Session["Other"] as FaultLog;
            if (Session["Other"] != null)
            {

                ddlCategories.DataSource = faultHand.dtGetFaultCategory();
                ddlCategories.DataTextField = "FaultCategoryName";
                ddlCategories.DataValueField = "FaultCategoryID";
                ddlCategories.DataBind();
                ddlCategories.Items.Insert(0, new ListItem("Please select a fault category", "0"));

                txtOther.Text = fault.OtherDescription.ToString().Trim();
            }
            else
            {
                Session["loggedInfo"] = null;
                Session["loggedRes"] = null;
                Response.Redirect("Signin.aspx");
            }
        }

        protected void btnAddOtherFault_Click(object sender, EventArgs e)
        {
            fault.SelectedFaultCategory = Convert.ToInt32(ddlCategories.SelectedValue);

            if (ddlCategories.SelectedValue !="0"||txtOther.Text=="")
            {
                faultHand.AddOtherFaultType(fault);
            }
            else
            {
                lblError.Text = "All fields are required!";
            }
        }

        protected void ddlCategories_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}