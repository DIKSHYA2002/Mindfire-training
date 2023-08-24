using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TentHouseRentals.BusinessAccess;
using TentHouseRentals.Utilities;

namespace TentHouseRentals.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["id"] != null)
            {
                Response.Redirect("ProductsPage.aspx");

            }

        }

        protected void LoginBtn(object sender, EventArgs e)
        {
            try
            {
                String email = txtEmail.Value;
                String password = txtPassword.Value;
                int id = UserBusiness.IsUser(email, password);
                if (id != -1)
                {
                    Session["id"] = id;
                    Response.Redirect("ProductsPage.aspx?ID=" + id, false);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Wrong Credentials');", true);
                }

            }
            catch (Exception ex)
            {
                CommonFunctions.WriteLogFile(ex);
            }

        }

        protected void Reinitialise(object sender, EventArgs e)
        {

            try
            {
                String email = txtEmail.Value;
                String password = txtPassword.Value;
                int id = UserBusiness.IsUser(email, password);
                if (id != -1)
                {
                    Session["id"] = id;
                    bool done = UserBusiness.Reinitialise();
                    if (done)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Truncated Table Transactions');", true);

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Failed to truncate');", true);
                    }
                  
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Wrong Credentials');", true);
                }

            }
            catch (Exception ex)
            {
                CommonFunctions.WriteLogFile(ex);
            }
           
        }
    }
}