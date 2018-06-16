using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;
using System.Net;
using System.Net.Mail;

namespace FixTheIncident
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        FaultTypeHandler faultHandler = new FaultTypeHandler();
        FaultLog fl = new FaultLog();
        Resident res = new Resident();
        TechnicianHandler techHand = new TechnicianHandler();
        MailAddress fromAddress = new MailAddress("eldonhufkie@gmail.com", "noreply@fixtheincident.co.za");
        MailAddress toAddress = new MailAddress("s213243148@nmmu.ac.za", "Eldon Hufkie");
        const string fromPassword = "pheent90";
        const string subject = "Fault Logged";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedRes"] != null && Session["loggedInfo"] != null)
            {
                fl = Session["loggedInfo"] as FaultLog;
                res = Session["loggedRes"] as Resident;
                HiddenLat.Value = fl.FaultLatitude;
                HiddenLng.Value = fl.FaultLongitude;
                //Resident Info
                lblResidentName.InnerText = res.FullName.ToString();
                lblResidentSurname.InnerText = res.Surname.ToString();
                lblEmail.InnerText = res.EmailAddress.ToString();
                lblPhoneNo.InnerText = res.PhoneNumber.ToString();
                //Fault Information
                int faultID = fl.FaultID;
                lblStatus.InnerText = "Unassigned";
                lblFaultCategory.InnerText = faultHandler.dtGetSelectedFaultCategory(Convert.ToInt32(fl.SelectedFaultCategory)).Rows[0][0].ToString();
                lblFaultType.InnerText = faultHandler.dtGetFaultByCategory(Convert.ToInt32(fl)).Rows[0][0].ToString();
                lblFaultDescription.InnerText = fl.FaultDescription.ToString();
                lblFaultLocation.InnerText = fl.LocationDescription.ToString();
                lblReferenceNumber.InnerText = fl.ReferenceNumber.ToString();
                lblDate.InnerText = fl.LoggedFaultDateAndTime.ToString();

                string referenceNo = fl.ReferenceNumber;

                List<FaultLog> Status = new List<FaultLog>();

                //             CommentList.InnerText = techHand.GetStatusesViaReferenceNumber(referenceNo);
            }
            else
            {
                Session["loggedInfo"] = null;
                Session["loggedRes"] = null;
                Response.Redirect("MainMenu.aspx");
            }

            //Email
            string body = "Hello " + lblResidentName.InnerText.ToString() + " " + lblResidentSurname.InnerText.ToString();

            body += "\n\nThank you for submitting the fault. \n\n Here is your reference number: " + lblReferenceNumber.InnerText.ToString() + ".";
            body += "\n\nPlease keep the reference number in a safe place.";
            body += "To view the fault, please click on the link below and enter your reference number.";
            body += "If clicking the link above does not work, you can type or copy and paste this URL into your browser.\n"
                + Request.Url.AbsoluteUri.Replace("LoggedFault.aspx", "SearchFault.aspx");

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 20000
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }

        private void WebForm7_PreInit(object sender, EventArgs e)
        {

            HiddenLat.Value = fl.FaultLatitude;
            HiddenLng.Value = fl.FaultLongitude;

        }

        protected void CommentList_Load(object sender, EventArgs e)
        {


        }

        protected void btnLogAnotherFault_Click(object sender, EventArgs e)
        {
            Session["loggedRes"] = res;
            Response.Redirect("LogAFault.aspx");
        }

    }
}