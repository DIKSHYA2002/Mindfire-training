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
        [WebMethod(EnableSession=true)]
        public static List<Products> GetProducts()
        {
            try
            {
                if (CommonFunctions.GetSession() != -1)
                {
                    return UserBusiness.GetProducts();

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