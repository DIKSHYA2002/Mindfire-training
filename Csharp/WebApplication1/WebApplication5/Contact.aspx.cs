using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication5
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindDataRoles();
            if (!this.IsPostBack)
            {
                this.BindGrid();
            }
        }
        public void BindDataRoles()
        {
            using(Test2Entities1 entities = new Test2Entities1())
            {
               userroles.DataSource = entities.UserRoles.ToList();
                userroles.DataTextField =  "RoleName";
                userroles.DataValueField = "RoleID";
                userroles.DataBind();
            }
        }
        private void BindGrid()
        {

            using (Test2Entities1 entities = new Test2Entities1())
            {
                GridView1.DataSource = entities.Users.ToList();
                GridView1.DataBind();
            }
        }

        protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}