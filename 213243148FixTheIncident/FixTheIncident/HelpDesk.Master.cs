﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;

namespace FixTheIncident
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        LoginHandler loginHandler = new LoginHandler();
        EmployeeLogin signin = new EmployeeLogin();
        Employee emp = new Employee();
        FaultTypeHandler handler = new FaultTypeHandler();
        TechnicianHandler techHand = new TechnicianHandler();
        FaultLog fault = new FaultLog();
        LoginHandler loginHand = new LoginHandler();
        protected void Page_Load(object sender, EventArgs e)
        {
            emp.EmployeeID = Convert.ToInt32(Request.Cookies["userid"].Value);
            if (loginHand.dtGetEmployeeLogin(emp).Rows.Count > 0)
            {
                emp.EmployeeID = Convert.ToInt32(loginHand.dtGetEmployeeLogin(emp).Rows[0][0]);
                lblUsername.InnerText = loginHand.dtGetEmployeeLogin(emp).Rows[0]["empFullName"].ToString();
                if (loginHand.dtGetEmployeeLogin(emp).Rows[0]["description"].ToString().Trim() != "Help-Desk Analyst")
                {
                    Session["username"] = null;
                    HttpCookie cookie = new HttpCookie("userid");
                    cookie.Expires = DateTime.Now.AddMinutes(-1);   
                    Response.Redirect("AccessDenied.aspx");// add unautorised page 
                }
            }
        }

        protected void btnLogOff_Click(object sender, EventArgs e)
        {
            Session["username"] = null;
            Response.Redirect("Signin.aspx");
        }
    }
}