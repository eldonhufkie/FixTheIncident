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
    public partial class WebForm5 : System.Web.UI.Page
    {
        FaultTypeHandler handler = new FaultTypeHandler();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btn_Add_Click(object sender, EventArgs e)
        {

        }

        protected void lvFaultCategoris_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {

        }

        protected void dgUnassignedFaults_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}