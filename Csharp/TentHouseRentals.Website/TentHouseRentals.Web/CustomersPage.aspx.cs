using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using TentHouseRentals.BusinessAccess;
using TentHouseRentals.Model;

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
        [WebMethod]
        public static bool SubmitCustomer(String customerName)
        {
            return UserBusiness.SubmitCustomer(customerName);
        }
        [WebMethod]
        public static List<Customers> GetCustomers()
        {
            return UserBusiness.GetCustomers();
        }
    }
}