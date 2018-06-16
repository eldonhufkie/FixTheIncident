using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;
using System.Drawing;
using System.Globalization;
using System.Net.Mail;

namespace FixTheIncident
{
    public partial class WebForm14 : System.Web.UI.Page
    {
        EmployeeHandler empHandler = new EmployeeHandler();
        private static Employee employeeClass = new Employee();
        EmployeeType emptype = new EmployeeType();
        //TechnicianHandler techHand = new TechnicianHandler();
        FaultTypeHandler faultHand = new FaultTypeHandler();
        protected static DateTime dateofBirth = new DateTime();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    employeeClass.AddressLine2 = "";

                    ddlEmployeeType.DataSource = empHandler.dtGetAllEmployeeType();
                    ddlEmployeeType.DataTextField = "description";
                    ddlEmployeeType.DataValueField = "employeeTypeID";
                    ddlEmployeeType.DataBind();
                    ddlEmployeeType.Items.Insert(0, new ListItem("Please select employee type", "0"));

                    ddlExpertiseList.Enabled = false;
                    ddlExpertiseList.Visible = false;
                    lblExpertise.Enabled = false;
                    lblExpertise.Visible = false;

                }
                catch (Exception)
                {
                    lblError.Text = "List could not be populated!";
                }
            }
        }

        protected void btnAddEmployee_Click(object sender, EventArgs e)
        {
            if (txtAddressLineOne.Text == "" && txtCity.Text == "" && txtEmail.Text == ""
               && txtFirstName.Text == "" &&
               txtIDNumber.Text == "" && txtPhone.Text == "" && txtPostalCode.Text == "" && txtSuburb.Text == ""
               && txtSurname.Text == "" && ddlEmployeeType.SelectedIndex == 0)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "All fields are required";

            }
            else if (txtAddressLineOne.Text == "" || txtCity.Text == "" || txtEmail.Text == ""
                || txtFirstName.Text == "" ||
                txtIDNumber.Text == "" || txtPhone.Text == "" || txtPostalCode.Text == "" || txtSuburb.Text == ""
                || txtSurname.Text == "" || ddlEmployeeType.SelectedValue == "0")
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "All fields required";

            }
            else
            {
                try
                {

                    employeeClass.EmployeeID = 0; //ID WILL BE OVERIDDEN WITH NEWLY ADDED EMPLOYEE ID
                    employeeClass.AddressLine1 = txtAddressLineOne.Text;
                    employeeClass.AddressLine2 = txtAddressLineTwo.Text;
                    employeeClass.City = txtCity.Text;
                    //employeeClass.DateOfBirth = dateofBirth;
                    employeeClass.EmpEmailAddress = txtEmail.Text;
                    employeeClass.EmpFullName = txtFirstName.Text;
                    employeeClass.EmpIDNumber = txtIDNumber.Text;
                    emptype.EmployeeTypeID = Convert.ToInt32(ddlEmployeeType.SelectedValue);
                    //emptype.EmployeeTypeID = 3;
                    employeeClass.EmpPhoneNumber = txtPhone.Text;
                    employeeClass.EmpSurname = txtSurname.Text;
                    //employeeClass.Gender 
                    employeeClass.PostalCode = txtPostalCode.Text;
                    employeeClass.Suburb = txtSuburb.Text;

                    if (ddlEmployeeType.SelectedValue != "2")
                    {
                        empHandler.AddEmployee(employeeClass, emptype);
                        Response.Redirect("EmployeeAdded.aspx");
                    }
                    else
                    {
                        employeeClass.ExpertiseID = Convert.ToInt32(ddlExpertiseList.SelectedValue);
                        empHandler.AddNewEmployeeExpertise(employeeClass, emptype);
                        Response.Redirect("EmployeeAdded.aspx");
                    }

                }
                catch (Exception ex)
                {
                    lblError.Text = ex.Message;
                }
            }
        }

        public string IDValidator()
        {
            bool validId = false;
            string id = null;
            do
            {
                validId = true;

                id = txtIDNumber.Text;
                if ((id.Length != 13))
                {
                    //Error
                    validId = false;
                    lblError.ForeColor = Color.Red;
                    lblError.Text = string.Format("The length of the ID Number doesn't meet the requirements.\nEnter a valid ID Number.");
                    txtIDNumber.Focus();
                    break;
                }
                //Length is valid, continue with validation
                if ((validId == true))
                {
                    //Check if all characters are numbers
                    for (int i = 0; i <= 12; i++)
                    {
                        try
                        {
                            Convert.ToInt32(id.Substring(i, 1));
                        }
                        catch (InvalidCastException ex)
                        {
                            validId = false;
                            lblError.ForeColor = Color.Red;
                            lblError.Text = string.Format("The length of the ID Number doesn't meet the requirements.\nEnter a valid ID Number.");
                            txtIDNumber.Focus();
                            break;
                        }
                    }
                }
                //All characters are numbers, continue with validation
                if ((validId == true))
                {
                    //Check if first 6 characters represent a valid date
                    int year = 0;
                    int month = 0;
                    int day = 0;
                    year = Convert.ToInt32(id.Substring(0, 2));
                    month = Convert.ToInt32(id.Substring(2, 2));
                    day = Convert.ToInt32(id.Substring(4, 2));
                    //Month is valid, continue with validation
                    if ((month >= 1 & month <= 12))
                    {
                        //Day should not be less than 1
                        if ((day < 1))
                        {
                            validId = false;
                            lblError.ForeColor = Color.Red;
                            lblError.Text = string.Format("The length of the ID Number doesn't meet the requirements.\nEnter a valid ID Number.");
                            txtIDNumber.Focus();
                            break;
                        }
                        else
                        {
                            //Day should not be greater than 31
                            if ((month == 1 | month == 3 | month == 5 | month == 7 | month == 8 | month == 10 | month == 12))
                            {
                                if ((day > 31))
                                {
                                    validId = false;
                                    validId = false;
                                    lblError.ForeColor = Color.Red;
                                    lblError.Text = string.Format("The length of the ID Number doesn't meet the requirements.\nEnter a valid ID Number.");
                                    txtIDNumber.Focus();
                                    break;
                                }
                                //Day should not be greater than 28/29 (depending on whether leap year or not)
                            }
                            else if ((month == 2))
                            {
                                if ((year % 4 == 0))
                                {
                                    if ((day > 29))
                                    {
                                        validId = false;
                                        lblError.ForeColor = Color.Red;
                                        lblError.Text = string.Format("The length of the ID Number doesn't meet the requirements.\nEnter a valid ID Number.");
                                        txtIDNumber.Focus();
                                        break;
                                    }
                                }
                                else
                                {
                                    if ((day > 28))
                                    {
                                        validId = false; lblError.ForeColor = Color.Red;
                                        lblError.Text = string.Format("The length of the ID Number doesn't meet the requirements.\nEnter a valid ID Number.");
                                        txtIDNumber.Focus();
                                        break;
                                    }
                                }
                                //Day should not be greater than 30
                            }
                            else if ((month == 4 | month == 6 | month == 9 | month == 11))
                            {
                                if ((day > 30))
                                {
                                    validId = false;
                                    lblError.ForeColor = Color.Red;
                                    lblError.Text = string.Format("The length of the ID Number doesn't meet the requirements.\nEnter a valid ID Number.");
                                    txtIDNumber.Focus();
                                    break;
                                }
                            }
                        }
                    }
                }

                //
                employeeClass.DateOfBirth = GetDateFromIDNumber(id);
                employeeClass.Gender = GetGenderFromID(id);

                //First 6 digits represent a date, continue with validation
                if ((validId == true))
                {
                    if ((id.Substring(10, 1) != "1" & id.Substring(10, 1) != "0"))
                    {
                        validId = false;
                        lblError.ForeColor = Color.Red;
                        lblError.Text = string.Format("The length of the ID Number doesn't meet the requirements.\nEnter a valid ID Number.");
                        txtIDNumber.Focus();
                        break;
                    }
                }
                //Third last digit is 0 or 1, continue with validation
                if ((validId == true))
                {
                    int checkA = 0;
                    int checkB = 0;
                    int checkFinal = 0;
                    int temp = 0;
                    //A) Add all digits in odd positions (excluding last digit):
                    checkA = 0;
                    for (int i = 0; i <= 11; i += 2)
                    {
                        checkA += Convert.ToInt32(id.Substring(i, 1));
                    }
                    //B1) Move digits in even positions into a field and multiply number by 2:
                    string field = null;
                    field = "";
                    for (int i = 1; i <= 12; i += 2)
                    {
                        field += id.Substring(i, 1);
                    }
                    temp = Convert.ToInt32(field) * 2;
                    //B2) Add the digits of the result in B1
                    checkB = 0;
                    for (int i = 0; i <= temp.ToString().Length - 1; i++)
                    {
                        checkB += Convert.ToInt32(temp.ToString().Substring(i, 1));
                    }
                    //Add the answer of A to B:
                    checkFinal = checkA + checkB;
                    //Subtract the second digit from 10:
                    checkFinal = 10 - Convert.ToInt32(checkFinal.ToString().Substring(1, 1));
                    //checkFinal must be equal to the last digit in the ID number.
                    //If checkFinal = 10 then last digit of ID should be 0.
                    lblError.Text = " ";
                    if ((checkFinal == 10))
                    {
                        if ((id.Substring(12, 1) != "0"))
                        {
                            validId = false;
                            break;
                        }
                    }
                    else if ((id.Substring(12, 1) != checkFinal.ToString()))
                    {
                        validId = false;
                        break;
                    }
                }

            } while ((validId == false));
            return id;
        }

        protected void txtIDNumber_TextChanged(object sender, EventArgs e)
        {
            IDValidator();
            txtEmail.Focus();
        }
        public DateTime GetDateFromIDNumber(string id)
        {
            //DateTime dateofBirth = new DateTime();
            DateTime dateForYear = DateTime.Now;
            int yearNew = int.Parse(id.Substring(0, 2));
            int currentYear = Convert.ToInt32(dateForYear.Year) % 100;

            int prefix = 1900;
            if (yearNew < currentYear)
            {
                prefix = 2000;
            }
            yearNew += prefix;

            int monthNew = int.Parse(id.Substring(2, 2));
            int dayNew = int.Parse(id.Substring(4, 2));
            string dob = Convert.ToString(yearNew) + "/" + Convert.ToString(monthNew) + "/" + Convert.ToString(dayNew);
            try
            {
                employeeClass.DateOfBirth = Convert.ToDateTime(dob, CultureInfo.CurrentCulture.DateTimeFormat);
                //int gender = Convert.ToInt32(id.Substring(6, 1));
                dateofBirth = Convert.ToDateTime(dob);
            }
            catch (Exception ex)
            {
                lblError.Text = string.Format("The length of the ID Number doesn't meet the requirements.\nEnter a valid ID Number.");
                txtIDNumber.Text = "";
                txtIDNumber.Focus();
            }
            return employeeClass.DateOfBirth;
        }
        public string GetGenderFromID(string id)
        {
            if (Convert.ToInt32(id.Substring(6, 1)) <= 4 && Convert.ToInt32(id.Substring(6, 1)) >= 0)
            {
                employeeClass.Gender = "Female";
            }
            else if (Convert.ToInt32(id.Substring(6, 1)) >= 5 && Convert.ToInt32(id.Substring(6, 1)) <= 9)
            {
                employeeClass.Gender = "Male";
            }
            return employeeClass.Gender;
        }

        protected void ddlEmployeeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEmployeeType.SelectedValue == "2")
            {
                lblExpertise.Visible = true;
                lblExpertise.Enabled = true;
                ddlExpertiseList.Enabled = true;
                ddlExpertiseList.Visible = true;
                ddlExpertiseList.DataSource = faultHand.dtGetAllExpertise();
                ddlExpertiseList.DataTextField = "ExpertiseDescription";
                ddlExpertiseList.DataValueField = "ExpertiseID";
                ddlExpertiseList.DataBind();
                ddlExpertiseList.Items.Insert(0, new ListItem("Please select level of expertise"));
            }
            else
            {
                lblExpertise.Enabled = false;
                lblExpertise.Visible = false;
                ddlExpertiseList.Enabled = false;
                ddlExpertiseList.Visible = false;
            }
        }

        protected void txtPhone_TextChanged(object sender, EventArgs e)
        {
            bool validId = false;
            string phone = null;
            do
            {
                validId = true;

                phone = txtPhone.Text.Trim();
                if ((phone.Length != 10))
                {
                    validId = false;
                    lblError.ForeColor = Color.Red;
                    lblError.Text = string.Format("The length of the phone number doesn't meet the requirements. Enter a valid phone number.");
                    break;
                }
                //Length is valid, continue with validation
                if ((validId == true))
                {
                    //Check if all characters are numbers
                    for (int i = 0; i <= 9; i++)
                    {
                        try
                        {
                            Convert.ToInt32(phone.Substring(i, 1));
                        }
                        catch (InvalidCastException ex)
                        {
                            validId = false;
                            lblError.ForeColor = Color.Red;
                            lblError.Text = string.Format("The length of the phone number doesn't meet the requirements. Enter a valid phone number.");
                            break;
                        }
                    }
                    if (phone.Substring(0, 1) != "0")
                    {
                        validId = false;
                        lblError.ForeColor = Color.Red;
                        lblError.Text = string.Format("The length of the phone number doesn't meet the requirements. Enter a valid phone number.");
                        break;
                    }
                    //if (phone.Substring(1, 1) != "7" || phone.Substring(1, 1) != "8" || phone.Substring(1, 1) != "6")////what if landline
                    //{
                    //    validId = false;
                    //    lblError.ForeColor = Color.Red;
                    //    lblError.Text = string.Format("The length of the phone number doesn't meet the requirements. Enter a valid phone number.");
                    //    break;
                    //}
                }
                lblError.Text = "";

            } while ((validId == false));
        }

        protected void txtEmail_TextChanged(object sender, EventArgs e)
        {
            IsValid(txtEmail.Text.Trim());
            txtPhone.Focus();
        }
        public bool IsValid(string emailaddress)
        {
            try
            {
                if (txtEmail.Text == "" || txtEmail.Text == null)
                {
                    lblError.ForeColor = Color.Red;
                    lblError.Text = string.Format("The e-mail address doesn't meet the requirements. Enter a valid e-mail address.");
                    return false;
                }
                else
                {
                    MailAddress m = new MailAddress(emailaddress);

                    return true;
                }
            }
            catch (FormatException)
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = string.Format("The e-mail address doesn't meet the requirements. Enter a valid e-mail address.");
                return false;
            }
        }

        protected void txtPostalCode_TextChanged(object sender, EventArgs e)
        {
            bool validId = false;
            string Postal = null;
            do
            {
                validId = true;

                Postal = txtPostalCode.Text.Trim();
                if ((Postal.Length != 4))
                {
                    validId = false;
                    lblError.ForeColor = Color.Red;
                    lblError.Text = string.Format("The length of the postal code doesn't meet the requirements. Enter a valid postal code.");
                    break;
                }
                //Length is valid, continue with validation
                if ((validId == true))
                {
                    //Check if all characters are numbers
                    for (int i = 0; i <= 3; i++)
                    {
                        try
                        {
                            Convert.ToInt32(Postal.Substring(i, 1));
                        }
                        catch (InvalidCastException ex)
                        {
                            validId = false;
                            lblError.ForeColor = Color.Red;
                            lblError.Text = string.Format("The length of the postal code doesn't meet the requirements. Enter a valid postal code.");
                            break;
                        }
                    }

                    //if (phone.Substring(1, 1) != "7" || phone.Substring(1, 1) != "8" || Postal.Substring(1, 1) != "6")////what if landline
                    //{
                    //    validId = false;
                    //    lblError.ForeColor = Color.Red;
                    //    lblError.Text = string.Format("The length of the Postal number doesn't meet the requirements. Enter a valid Postal number.");
                    //    break;
                    //}
                }
                lblError.Text = "";

            } while ((validId == false));
        }
    }
}