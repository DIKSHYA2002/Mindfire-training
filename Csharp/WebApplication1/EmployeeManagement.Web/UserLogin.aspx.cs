using EmployeeManagement.Utils;
using EmpployeeManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeManagement.Web
{
    public partial class UserLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void Login(object sender, EventArgs e)
        {
            try
            {
                string email = txtEmail.Value;
                string password = txtPassword.Value;
                int isuser = AccessUserBusiness.IsUser(email, password);
              
                if (isuser != -1)
                {
                    bool isadmin = AccessUserBusiness.IsAdmin(isuser);
                    Session["id"] = isuser;
                    if (isadmin == true)
                    {
                        Response.Redirect("About.aspx?ID=" + isuser, false);
                    }
                    else
                    {
                        Response.Redirect("Dashboard.aspx?ID=" + isuser, false);
                    }

                }
                else 
                {
                   ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Wrong Credentials');", true);
                }
            }
            catch(Exception ex)
            {
                CommonFunctions.WriteLogFile(ex);
            }
            

        }
    }
}