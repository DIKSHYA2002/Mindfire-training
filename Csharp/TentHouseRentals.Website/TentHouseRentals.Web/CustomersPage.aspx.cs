using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using TentHouseRentals.BusinessAccess;
using TentHouseRentals.Model;
using TentHouseRentals.Utilities;

namespace TentHouseRentals.Web
{
    public partial class CustomersPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["id"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
            }

        }
        [WebMethod(EnableSession = true)]
        public static bool SubmitCustomer(String customerName)
        {


            try
            {
                if (CommonFunctions.GetSession()!=-1)
                     {
                    return UserBusiness.SubmitCustomer(customerName);
                    }
                else
                {
                    return false;
                }

            }
            catch(Exception ex)
            {
                CommonFunctions.WriteLogFile(ex);
            }
            return false;

        }
        [WebMethod(EnableSession=true)]
        public static List<Customers> GetCustomers()
        {
            try
            {
                if (CommonFunctions.GetSession() != -1)
                {

                    return UserBusiness.GetCustomers();
                }
                else
                {
                    return null;
                }

            }
            catch(Exception ex)
            {
                CommonFunctions.WriteLogFile(ex);
            }
            return null;
        }
    }
}