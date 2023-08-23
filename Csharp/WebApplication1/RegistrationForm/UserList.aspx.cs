using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistrationForm
{
    public partial class UserList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                
                this.BindDataUsers();
               
            }
        }
        protected void BindDataUsers()
        {
            using (Test1Entities5 entities = new Test1Entities5())
            {
                GridView1.DataSource = entities.Users.ToList();
                GridView1.DataBind();
            }
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String id = GridView1.SelectedRow.Cells[0].Text;
            Response.Redirect("Default.aspx?ID="+ id);
        }

        protected void RedirectAddUserPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}