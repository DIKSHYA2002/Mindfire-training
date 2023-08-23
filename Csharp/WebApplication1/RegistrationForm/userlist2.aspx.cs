using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistrationForm
{
    public partial class userlist2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [System.Web.Services.WebMethod(EnableSession =true)]
        public static List<UserObject> GetUserList()
        {
            using(Test1Entities5 entities5 = new Test1Entities5())
            {
                List<UserObject> userslist = entities5.Users.Select(st => new UserObject
                {
                    UserID = st.userID,
                    FirstName = st.userFirstName,
                    LastName = st.userLastName,
                    Email = st.userEmail,
                    PhoneNumber = st.userPhone,
                }).ToList();
                foreach(UserObject u in userslist)
                {
                    u.Roles = String.Join(",", entities5.userrolesdetails.Where(s=>s.userID == u.UserID).Select(s=>s.roleName).ToList());
                }
                return userslist;
            }
        }

    }

   public class UserObject
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string Roles { get; set; }

    }
 
  


}