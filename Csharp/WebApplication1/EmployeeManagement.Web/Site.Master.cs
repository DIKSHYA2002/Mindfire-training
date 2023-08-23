using EmployeeManagement.Utils;
using EmpployeeManagement.Business;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeManagement.Web
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                try
                {

                    if (Session["id"] != null)
                    {
                        int id = CommonFunctions.GetSession();
                        if (!AccessUserBusiness.IsAdmin(id))
                        {
                            btnUserList.Visible = false;
                        }
                    }
                    else
                    {
                        Response.Redirect("UserLogin.aspx", false);
                    }
                }
                catch (Exception ex)
                {
                    CommonFunctions.WriteLogFile(ex);
                }

            }

        }
        protected void Logout_Click(object sender , EventArgs e)
        {
          
            Session.Clear();
                Session.Abandon();
                Response.Redirect("UserLogin.aspx");

        }
    }
}