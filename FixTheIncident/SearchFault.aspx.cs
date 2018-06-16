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
    public partial class WebForm10 : System.Web.UI.Page
    {
        FaultTypeHandler faultHandler = new FaultTypeHandler();
        FaultLog f = new FaultLog();
        TechnicianHandler techHand = new TechnicianHandler();
        protected void Page_Load(object sender, EventArgs e)
        {
          
            HiddenLat.Value = "-33.9914";
            HiddenLng.Value = "25.6569";
           
            //Time =Time.Substring(12)
            //label
           
        }
        protected void btnSearchFault_Click(object sender, EventArgs e)
        {
            f.ReferenceNumber = txtSearchFault.Text;

            gvSearchResults.DataSource = faultHandler.dtGetSearchedFault(f);
            DataBind();
            if (gvSearchResults.Rows.Count > 0)
            {
                HiddenLat.Value = faultHandler.dtGetSearchedFault(f).Rows[0][5].ToString();
                HiddenLng.Value = faultHandler.dtGetSearchedFault(f).Rows[0][6].ToString();
            }
            f.FaultID = Convert.ToInt32(techHand.dtGetStatusesViaReferenceNumber(f.ReferenceNumber).Rows[0][3]);
  int maxComment = faultHandler.dtGetCommentsByFaultID(f).Rows.Count;
            if (faultHandler.dtGetCommentsByFaultID(f).Rows.Count > 0)
            {
              
                lblCommentDate.Text = faultHandler.dtGetCommentsByFaultID(f).Rows[0][1].ToString();
                //lblCommentTime.Text = Time;
                lblCommentText.Text = faultHandler.dtGetCommentsByFaultID(f).Rows[maxComment - 1][0].ToString();
            }
            else
            {
                lblCommentDate.Text = "No Comments have been made currently.";
            }
        }
    }
}