using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;

namespace FixTheIncident
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        FaultTypeHandler faultHandler = new FaultTypeHandler();
        FaultType faultType = new FaultType();
        protected void Page_Load(object sender, EventArgs e)
        {
            //ddlFaultType.Enabled = false;
            if (!IsPostBack)
            {
                try
                {
                    //txtSearchFaultLocation.Text = "13 Ivana Street, Summerstrand Port Elizabeth";
                    ddlSelectFaultCategory.DataSource = faultHandler.dtGetFaultCategory();
                    ddlSelectFaultCategory.DataTextField = "FaultCategoryName";
                    ddlSelectFaultCategory.DataValueField = "FaultCategoryID";
                    ddlSelectFaultCategory.DataBind();
                    ddlSelectFaultCategory.Items.Insert(0, new ListItem("Please select one of the following", "0"));
                    ddlFaultType.Items.Insert(0, new ListItem("Please select one of the following", "0"));

                }
                catch (Exception ex)
                {


                }
            }
        }

        protected void ddlSelectFaultCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlSelectFaultCategory.SelectedIndex == 0)
                {

                }
                else
                {
                    ddlFaultType.Enabled = true;
                    int faultCategoryID = Convert.ToInt32(ddlSelectFaultCategory.SelectedValue);
                    //populate fault type ddl
                    ddlFaultType.DataSource = faultHandler.dtGetFaultByCategory(faultCategoryID);
                    ddlFaultType.DataTextField = "TypeDescription";
                    ddlFaultType.DataValueField = "FaultTypeID";
                    ddlFaultType.Items.Insert(0, new ListItem("Please select one of the following", "0"));
                    //bind
                    ddlFaultType.DataBind();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        protected void ddlFaultType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}