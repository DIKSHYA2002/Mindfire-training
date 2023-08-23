using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TentHouseRentals.Web
{
  
public partial class Navbar : System.Web.UI.UserControl
    {
        public String ActiveTab { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }
        protected void btnClickLogOut(object sender, EventArgs e)
        {
                Session.Clear();
                Session.Abandon();
                Response.Redirect("Login.aspx");
        }
    }
}