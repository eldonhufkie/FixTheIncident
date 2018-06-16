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
    public partial class WebForm2 : System.Web.UI.Page
    {
        FaultTypeHandler faultHandler = new FaultTypeHandler();
        ResidentHandler resHand = new ResidentHandler();
        FaultType faultType = new FaultType();
        FaultLog fl = new FaultLog();
        Resident res = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblOther.Visible = false;
            lblOther.Disabled = true;

            txtOther.Visible = false;
            txtOther.Enabled = false;
            ddlFaultType.Enabled = false;
            if (Session["loggedRes"] == null)
            {
                if (!IsPostBack)
                {
                    try
                    {
                        ddlFaultCategory.DataSource = faultHandler.dtGetFaultCategory();
                        ddlFaultCategory.DataTextField = "FaultCategoryName";
                        ddlFaultCategory.DataValueField = "FaultCategoryID";
                        ddlFaultCategory.DataBind();
                        ddlFaultCategory.Items.Insert(0, new ListItem("Please select one of the following", "0"));
                        ddlFaultType.Items.Insert(0, new ListItem("Please select one of the following", "0"));

                        //int count = faultHandler.dtGetFaultCategory().Rows.Count;
                        //count = count + 1;

                        //ddlFaultType.Items.Insert(count, new ListItem("Other", count.ToString()));
                    }
                    catch (Exception ex)
                    {
                        ex.GetType();
                    }
                }
            }
            else
            {
                if (!IsPostBack)
                {
                    try
                    {
                        ddlFaultCategory.DataSource = faultHandler.dtGetFaultCategory();
                        ddlFaultCategory.DataTextField = "FaultCategoryName";
                        ddlFaultCategory.DataValueField = "FaultCategoryID";
                        ddlFaultCategory.DataBind();
                        ddlFaultCategory.Items.Insert(0, new ListItem("Please select one of the following", "0"));
                        ddlFaultType.Items.Insert(0, new ListItem("Please select one of the following", "0"));

                        //Contact Information TextBoxes are populated and set to readonly
                        res = Session["loggedRes"] as Resident;
                        //populate textboxes
                        txtName.Text = res.FullName;
                        txtSurname.Text = res.Surname;
                        txtPhoneNo.Text = res.PhoneNumber;
                        txtemailAddress.Text = res.EmailAddress;
                        //ReadOnly
                        txtName.ReadOnly = true;
                        txtSurname.ReadOnly = true;
                        txtPhoneNo.ReadOnly = true;
                        txtemailAddress.ReadOnly = true;
                    }
                    catch (Exception ex)
                    {
                        ex.GetType();
                    }
                }
            }

        }
        static int count = 0;
        protected void ddlFaultCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlFaultCategory.SelectedIndex == 0)
            {
                ddlFaultType.Enabled = false;
            }
            else
            {
                ddlFaultType.Enabled = true;

                int faultCategoryID = Convert.ToInt32(ddlFaultCategory.SelectedValue);
                //populate fault type drop down list
                ddlFaultType.DataSource = faultHandler.dtGetFaultByCategory(faultCategoryID);
                ddlFaultType.DataTextField = "TypeDescription";
                ddlFaultType.DataValueField = "FaultTypeID";

                //bind
                ddlFaultType.DataBind();
                ddlFaultType.Items.Insert(0, new ListItem("Please select one of the following", "0"));

                count = faultHandler.dtGetFaultByCategory(faultCategoryID).Rows.Count;
                count = count + 1;

                ddlFaultType.Items.Insert(count, new ListItem("Other", count.ToString()));
            }
        }

        protected void ddlFaultType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlFaultType.SelectedValue == count.ToString())
                {
                    txtOther.Enabled = true;
                    txtOther.Visible = true;
                    lblOther.Visible = true;
                    lblOther.Disabled = false;
                    ddlFaultType.Enabled = true;

                    ddlFaultType.SelectedIndex = count;
                }
                ddlFaultType.Enabled = true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void btnAddFault_Click(object sender, EventArgs e)
        {

            SubmitFault();
        }
        public void SubmitFault()
        {
            res = new Resident();
            try
            {
                fl.FaultLatitude = HiddenLat.Value;
                fl.FaultLongitude = HiddenLng.Value;
                fl.LocationDescription = txtSearchInput.Text;
                fl.FaultDescription = txtDescription.Text;
                //Time and date
                string date = DateTime.Now.ToShortDateString();
                string[] datum = date.Split('/');
                string splitDate = "";
                foreach (string current in datum)
                {
                    splitDate += current;
                }
                fl.FaultID = -1;
                fl.LoggedFaultDateAndTime = DateTime.Now;
                fl.SelectedFault = Convert.ToInt32(ddlFaultType.SelectedValue);

                fl.SelectedFaultCategory = Convert.ToInt32(ddlFaultCategory.SelectedValue);

                res.ResidentID = -1;
                res.FullName = txtName.Text;
                res.Surname = txtSurname.Text;
                res.EmailAddress = txtemailAddress.Text;
                res.PhoneNumber = txtPhoneNo.Text;
                if (txtOther.Text != null || txtOther.Text != "")
                {
                    fl.OtherDescription = txtOther.Text;
                }
                Random r = new Random();
                int f = r.Next(9000, 900001);
                f.GetHashCode();
                //i = Convert.ToInt32(ddlFaultType.SelectedValue);
                string reference = "";
                if (ddlFaultType.SelectedValue != count.ToString())
                {
                    reference = faultHandler.dtGetFaultByCategory(fl).Rows[0][0].ToString();
                }
                else
                {
                    reference = txtOther.Text;
                }

                string[] re = reference.Split(' ');
                //re = reference.Split('\'');
                string refNo = "";

                foreach (string s in re)
                {
                    refNo += s;
                }
                string referenceDetails = refNo + "_" + splitDate + "_" + f.GetHashCode();
                f++;
                fl.ReferenceNumber = referenceDetails;

                if (resHand.dtGetResidentByContactInfo(res).Rows.Count > 0)
                {
                    if (txtName.Text.Trim() == resHand.dtGetResidentByContactInfo(res).Rows[0][0].ToString().Trim()
                   && txtSurname.Text.Trim() == resHand.dtGetResidentByContactInfo(res).Rows[0][1].ToString().Trim()
                   && txtPhoneNo.Text.Trim() == resHand.dtGetResidentByContactInfo(res).Rows[0][2].ToString().Trim() &&
                   txtemailAddress.Text.Trim() == resHand.dtGetResidentByContactInfo(res).Rows[0][3].ToString().Trim())
                    {
                        if (ddlFaultType.SelectedValue.Trim() != count.ToString())
                        {
                            res.ResidentID = Convert.ToInt32(resHand.dtGetResidentByContactInfo(res).Rows[0][4].ToString().Trim());
                            faultHandler.AddAFaultExistingResident(fl, res);
                        }
                        else
                        {
                            res.ResidentID = Convert.ToInt32(resHand.dtGetResidentByContactInfo(res).Rows[0][4].ToString().Trim());
                            faultHandler.AddOtherFaultExistingResident(fl, res);
                        }
                    }
                }
                else
                {
                    if (ddlFaultType.SelectedValue.Trim() != count.ToString())
                    {
                        faultHandler.AddNewFault(res, fl);
                    }
                    else
                    {
                        faultHandler.AddOtherTypeFault(fl, res);
                    }
                }
                ImplementSession();
                Response.Redirect("LoggedFault.aspx");
            }
            catch (Exception ex)
            {
                //lblError.Text = "Error occured when trying to log a fault. All changes are retracted.
                throw;
            }
        }
        public void ImplementSession()
        {
            Session["loggedInfo"] = fl;
            Session["loggedRes"] = res;
        }
    }


}
