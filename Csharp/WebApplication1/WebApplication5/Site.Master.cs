using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication5
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int id = Int32.Parse(Session["id"].ToString());
                using (var dtContext = new Test2Entities1())
                {
                    var user = dtContext.userDetails.Single(x => x.userID == id);
                    Label1.Text = "welcome" + user.userName;
                }
            }
            catch(Exception)
            {

                Response.Redirect("Login.aspx");
            }
           
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("Login.aspx");
        }
    }
}