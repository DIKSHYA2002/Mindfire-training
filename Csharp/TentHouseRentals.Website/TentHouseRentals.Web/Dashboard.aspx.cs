using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TentHouseRentals.Utilities;

namespace TentHouseRentals.Web
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["id"] == null)
                    {
                        Response.Redirect("Login.aspx");
                    }
                }

            }
            catch(Exception ex) 
            {
                Response.Redirect("Login.aspx");
                CommonFunctions.WriteLogFile(ex);
            }
          
        }
    }
}