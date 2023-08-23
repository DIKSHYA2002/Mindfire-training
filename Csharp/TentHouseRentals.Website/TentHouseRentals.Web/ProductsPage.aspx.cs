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
    public partial class ProductsPage : System.Web.UI.Page
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
        public static List<Products> GetProducts()
        {
            return UserBusiness.GetProducts();
        }
    }
}