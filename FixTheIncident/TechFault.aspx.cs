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
    public partial class TechFault : System.Web.UI.Page
    {
        FaultTypeHandler handler = new FaultTypeHandler();
        TechnicianHandler techHand = new TechnicianHandler();
        FaultLog fault = new FaultLog();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("Signin.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    btnUpdateorClose.Enabled = false;
                    fault = Session["TFaultID"] as FaultLog;
                    int faultID = fault.FaultID;
                    //handler.dtGetTechUnallocatedFaultsByID(int.Parse(Request.Cookies["userid"].Value));
                    HiddenLat.Value = Convert.ToString(handler.dtGetTechUnallocatedFaultsByID(int.Parse(Request.Cookies["userid"].Value)).Rows[0][2]);
                    HiddenLng.Value = Convert.ToString(handler.dtGetTechUnallocatedFaultsByID(int.Parse(Request.Cookies["userid"].Value)).Rows[0][3]);



                    lblDate.InnerText = handler.dtGetTechUnallocatedFault(int.Parse(Request.Cookies["userid"].Value)).Rows[0][16].ToString();
                    lblEmail.InnerText = handler.dtGetTechUnallocatedFault(int.Parse(Request.Cookies["userid"].Value)).Rows[0][15].ToString();
                    lblFaultCategory.InnerText = handler.dtGetTechUnallocatedFault(int.Parse(Request.Cookies["userid"].Value)).Rows[0][5].ToString();
                    lblFaultDescription.InnerText = handler.dtGetTechUnallocatedFault(int.Parse(Request.Cookies["userid"].Value)).Rows[0][17].ToString();
                    lblFaultLocation.InnerText = handler.dtGetTechUnallocatedFault(int.Parse(Request.Cookies["userid"].Value)).Rows[0][1].ToString();
                    lblFaultType.InnerText = handler.dtGetTechUnallocatedFault(int.Parse(Request.Cookies["userid"].Value)).Rows[0][6].ToString();
                    lblPhoneNo.InnerText = handler.dtGetTechUnallocatedFault(int.Parse(Request.Cookies["userid"].Value)).Rows[0][14].ToString();
                    lblReferenceNumber.InnerText = handler.dtGetTechUnallocatedFault(int.Parse(Request.Cookies["userid"].Value)).Rows[0][4].ToString();
                    lblResidentName.InnerText = handler.dtGetTechUnallocatedFault(int.Parse(Request.Cookies["userid"].Value)).Rows[0][13].ToString();
                    lblResidentSurname.InnerText = handler.dtGetTechUnallocatedFault(int.Parse(Request.Cookies["userid"].Value)).Rows[0][12].ToString();
                    lblStatus.InnerText = handler.dtGetTechUnallocatedFault(int.Parse(Request.Cookies["userid"].Value)).Rows[0][11].ToString();

                   // ddlStatus.DataSource = techHand.dtGetAllTechniciansPerCategory(handler.dtGetTechUnallocatedFaultsByID(int.Parse(Request.Cookies["userid"].Value)).Rows[0][1].ToString());
                   
                    
                    //Status Dropdown List
                    ddlStatus.DataSource = handler.GetStatusList();
                    ddlStatus.DataTextField = "StatusDescription";
                    ddlStatus.DataValueField = "StatusID";
                    ddlStatus.DataBind();
                    ddlStatus.Items.Insert(0, "Select the current status");
                }
            }
        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlStatus.SelectedIndex == 0)
            {
                btnUpdateorClose.Enabled = false;
            }
            else
            {
                btnUpdateorClose.Enabled = true;
                if (ddlStatus.SelectedItem == ddlStatus.Items.FindByText("Complete"))
                {
                    btnUpdateorClose.Text = "Complete";
                }
                else if (ddlStatus.SelectedItem != ddlStatus.Items.FindByText("Complete"))
                {
                    btnUpdateorClose.Text = "Update";
                }
            }
        }

        protected void btnUpdateorClose_Click(object sender, EventArgs e)
        {
            Technician tech = new Technician();

            if (btnUpdateorClose.Text == "Complete")
            {

                fault = Session["TFaultID"] as FaultLog;
                int faultID = fault.FaultID;
                tech.TechnicianID = int.Parse(Request.Cookies["userid"].Value);
                fault.StatusID = Convert.ToInt32(ddlStatus.SelectedValue);
                fault.FaultID = faultID;
                tech.Comment = txtComment.Value;
                fault.FaultDescription = "Completed";
                // close fault
                techHand.CloseFault(fault,tech);
            }
            else if (btnUpdateorClose.Text == "Update")
            {
                fault = Session["TFaultID"] as FaultLog;
                int faultID = fault.FaultID;
                tech.TechnicianID = int.Parse(Request.Cookies["userid"].Value);
                fault.StatusID = Convert.ToInt32(ddlStatus.SelectedValue);
                fault.FaultID = faultID;
                tech.Comment = txtComment.Value;
                fault.FaultDescription = " ";
                //update fault
                techHand.UpdateFault(fault,tech);
            }

        }
    }
}