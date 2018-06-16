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
    public partial class WebForm6 : System.Web.UI.Page
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
                    fault = Session["FaultID"] as FaultLog;
                    int faultID = fault.FaultID;
                    handler.GetUnassignedFault(faultID);
                    HiddenLat.Value = Convert.ToString(handler.GetUnassignedFault(faultID).Rows[0][12]);
                    HiddenLng.Value = Convert.ToString(handler.GetUnassignedFault(faultID).Rows[0][13]);



                    lblDate.InnerText = handler.GetUnassignedFault(faultID).Rows[0][5].ToString();
                    lblEmail.InnerText = handler.GetUnassignedFault(faultID).Rows[0][6].ToString();
                    lblFaultCategory.InnerText = handler.GetUnassignedFault(faultID).Rows[0][1].ToString();
                    lblFaultDescription.InnerText = handler.GetUnassignedFault(faultID).Rows[0][3].ToString();
                    lblFaultLocation.InnerText = handler.GetUnassignedFault(faultID).Rows[0][4].ToString();
                    lblFaultType.InnerText = handler.GetUnassignedFault(faultID).Rows[0][2].ToString();
                    lblPhoneNo.InnerText = handler.GetUnassignedFault(faultID).Rows[0][7].ToString();
                    lblReferenceNumber.InnerText = handler.GetUnassignedFault(faultID).Rows[0][8].ToString();
                    lblResidentName.InnerText = handler.GetUnassignedFault(faultID).Rows[0][9].ToString();
                    lblResidentSurname.InnerText = handler.GetUnassignedFault(faultID).Rows[0][10].ToString();
                    lblStatus.InnerText = handler.GetUnassignedFault(faultID).Rows[0][11].ToString();
                    //ddlTechnicians

                    if (techHand.dtGetAllTechniciansPerCategory(Convert.ToInt32(handler.GetUnassignedFault(faultID).Rows[0]["FaultCategoryID"])).Rows.Count > 0)
                    {
                        ddlTechnicians.DataSource = techHand.dtGetAllTechniciansPerCategory(Convert.ToInt32(handler.GetUnassignedFault(faultID).Rows[0]["FaultCategoryID"]));
                    }
                    else
                    {
                        //Hide Dropdown List and Show a Error message in a label
                    }

                    ddlTechnicians.DataTextField = "empFullName";
                    ddlTechnicians.DataValueField = "TechnicianID";

                    ddlTechnicians.DataBind();
                    ddlTechnicians.Items.Insert(0, "Please select a technician");

                    //ddlPriority
                    ddlPriority.DataSource = handler.dtGetAllPriorities();
                    ddlPriority.DataValueField = "PriorityID";
                    ddlPriority.DataTextField = "PriorityDecription";
                    ddlPriority.DataBind();
                    ddlPriority.Items.Insert(0, "Please select a type of urgency");
                }
            }
        }

        protected void ddlTechnicians_SelectedIndexChanged(object sender, EventArgs e)
        {
            fault.Selectedpriority = Convert.ToInt32(ddlPriority.SelectedValue);
        }

        protected void btnSubmitTechnician_Click(object sender, EventArgs e)
        {
            fault = Session["FaultID"] as FaultLog;
            int faultID = fault.FaultID;
            if (ddlPriority.Items.Count > 0)
            {
                fault.Selectedpriority = Convert.ToInt32(ddlPriority.SelectedValue);

            }
            else
            {
                lblErrorMessage.Text = "Please select a type of urgency!";
            }
            if (ddlTechnicians.Items.Count > 0)
            {
                fault.SelectedTechnician = Convert.ToInt32(ddlTechnicians.SelectedValue);
            }
            else
            {
                lblErrorMessage.Text = "Please select a technician!";
            }


            Resident res = new Resident();

            res.ResidentID = int.Parse(handler.GetUnassignedFault(faultID).Rows[0][16].ToString());
            fault.StatusID = 2;
            handler.AddTechnicianToFault(fault, res);



            Response.Redirect("HelpDeskFaults.aspx");

        }

        protected void ddlPriority_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}