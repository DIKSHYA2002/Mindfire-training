using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeManagement.Models;
using EmpployeeManagement.Business;
using EmployeeManagement.Utils;

namespace EmployeeManagement.Web
{
    public partial class About : Page
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
                            Response.Redirect("Dashboard.aspx?ID=" + id, true);
                        }

                    }
                    else
                    {
                        Response.Redirect("UserLogin.aspx", true);
                    }
                }
                catch (Exception ex)
                {
                    CommonFunctions.WriteLogFile(ex);

                }


            }






          
        }
        [WebMethod]
        public static List<Employee> GetUserList()
        {
            try
            {
                List<Employee> userslist = AccessUserBusiness.GetUsers();
                return userslist;


            }
            catch (Exception ex)
            {
                CommonFunctions.WriteLogFile(ex);
            }
            return null;


        }
    }
}