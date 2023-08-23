using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace EmployeeManagement
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void Login(object sender, EventArgs e)
        {
           
                string email = txtEmail.Value;
                string password = txtPassword.Value;
            using (var entities = new Test1Entities1())
            {
                var user = entities.Users.Where(s=>s.userEmail== email).FirstOrDefault();
                var isadmin = false;
                var isuser = false;
                if (user != null)
                {
                    if(user.userpassword==password)
                    {
                        isuser = true;
                    }
                }

               
                if (isuser == true)
                {
                    var roles = entities.UserRoles.Where(u => u.userID == user.userID).ToList();
                    roles.ForEach(r =>
                    {
                        if (r.RoleID == 7)
                        {
                            isadmin = true;
                        }
                    });
                    Session["id"] = user.userID;
                    if (isadmin == true)
                    {
                        Response.Redirect("AdminDashboard.aspx?Type=Admin&ID=" + user.userID);
                    }
                    else
                    {
                        Response.Redirect("UserDashBoard.aspx?Type=Employee&ID=" + user.userID);
                    }


                }
                else
                {
                    txtEmail.Value = "incorrect email";
                }

            }
          
              
            

        }
    }
}