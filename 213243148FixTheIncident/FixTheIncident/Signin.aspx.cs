using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;
using System.Drawing;
using BCrypt.Net;

namespace FixTheIncident
{
    public partial class Login : System.Web.UI.Page
    {
        LoginHandler loginHandler = new LoginHandler();
        EmployeeLogin signin = new EmployeeLogin();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            if (loginHandler.GetAllEmployeeLogin().Rows.Count > 0)
            {
                for (int i = 0; i < loginHandler.GetAllEmployeeLogin().Rows.Count; i++)
                {
                    if (txtPassword.Text != "" && txtUsername.Text != "")
                    {
                        if (txtUsername.Text == loginHandler.GetAllEmployeeLogin().Rows[i][2].ToString() && loginHandler.GetAllEmployeeLogin().Rows[i][6].ToString() == "Help-Desk Analyst")
                        {
                            if (txtPassword.Text == loginHandler.GetAllEmployeeLogin().Rows[i][4].ToString())
                            {
                                signin.EmployeeID = Convert.ToInt32(loginHandler.GetAllEmployeeLogin().Rows[i][7]);
                                Session["username"] = loginHandler.GetAllEmployeeLogin().Rows[i][5].ToString();
                                HttpCookie userid = new HttpCookie("userid");
                                userid.Value = signin.EmployeeID.ToString();
                                userid.Expires = DateTime.Now.AddHours(1);
                                Response.Cookies.Add(userid);
                                Response.Redirect("HelpDeskFaults.aspx");
                            }
                            else
                            {
                                lblErrorMessage.ForeColor = Color.Red;
                                lblErrorMessage.Text = "Invalid username or password!";
                            }
                        }
                        else if (txtUsername.Text == loginHandler.GetAllEmployeeLogin().Rows[i][2].ToString() && loginHandler.GetAllEmployeeLogin().Rows[i][6].ToString() == "Technician")
                        {
                            if (txtPassword.Text == loginHandler.GetAllEmployeeLogin().Rows[i][4].ToString())
                            {
                                signin.EmployeeID = Convert.ToInt32(loginHandler.GetAllEmployeeLogin().Rows[i][7]);
                                Session["username"] = loginHandler.GetAllEmployeeLogin().Rows[i][5].ToString();
                                HttpCookie userid = new HttpCookie("userid");
                                userid.Value = signin.EmployeeID.ToString();
                                userid.Expires = DateTime.Now.AddHours(1);
                                Response.Cookies.Add(userid);

                                Response.Redirect("TechFaults.aspx");//Add Tech Page
                            }
                            else
                            {
                                lblErrorMessage.ForeColor = Color.Red;
                                lblErrorMessage.Text = "Invalid username or password!";
                            }
                        }

                        else if (txtUsername.Text == loginHandler.GetAllEmployeeLogin().Rows[i][2].ToString() && loginHandler.GetAllEmployeeLogin().Rows[i][6].ToString() == "Administrator")
                        {
                            if (txtPassword.Text == loginHandler.GetAllEmployeeLogin().Rows[i][4].ToString())
                            {
                                signin.EmployeeID = Convert.ToInt32(loginHandler.GetAllEmployeeLogin().Rows[i][7]);
                                Session["username"] = loginHandler.GetAllEmployeeLogin().Rows[i][5].ToString();
                                //Session["userID"] = signin.EmployeeID;
                                HttpCookie userid = new HttpCookie("userid");
                                userid.Value = signin.EmployeeID.ToString();
                                userid.Expires = DateTime.Now.AddHours(1);
                                Response.Cookies.Add(userid);
                                Response.Redirect("AddEmployee.aspx");//Add Admin Page
                            }
                            else
                            {
                                lblErrorMessage.ForeColor = Color.Red;
                                lblErrorMessage.Text = "Invalid username or password!";
                            }
                        }
                        else
                        {
                            lblErrorMessage.ForeColor = Color.Red;
                            lblErrorMessage.Text = "Invalid username or password!";
                        }
                    }
                    else
                    {
                        lblErrorMessage.ForeColor = Color.Red;
                        lblErrorMessage.Text = "All fields are required!";
                    }
                }
            }
        }
    }
}