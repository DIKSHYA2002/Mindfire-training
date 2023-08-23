using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistrationForm
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int userid = Int32.Parse(Request.QueryString["ID"]);
                ShowButton(true);
                if(!this.IsPostBack)
                {
                    this.BindDataCountries();
                    FillDetails(userid);
                }

            }
            catch(Exception)
            {
                ShowButton(false);
                UserControl.Visible = false;

                if (!this.IsPostBack)
                {
                    this.BindDataRoles();
                }
            }

        }
        protected void ShowButton(bool show)
        {
            if(show==true)
            {
                btnSubmit.Visible = false;
                btnReset.Visible = false;
                btnDelete.Visible = true;
                btnEdit.Visible = true;
            }
            else
            {
                btnSubmit.Visible = true;
                btnReset.Visible = true;
                btnDelete.Visible = false;
                btnEdit.Visible = false;
            }
        }
        protected void FillDetails(int userid)
        {
            using (Test1Entities5 entities = new Test1Entities5())
            {
                var user = entities.Users.Where(x=>x.userID == userid).First();
                var userRoles = entities.UserRoles.Where(x => x.userID == userid).ToList();
                BindDataRoles();
                foreach (ListItem item in lbRoles.Items)
                {

                    foreach (var item1 in userRoles)
                    {
                        if(Int32.Parse(item.Value)== item1.RoleID)
                        {
                            item.Selected = true;
                        }
                    }
                }
                Console.Write(lbRoles.Items);

                var values = lbRoles.Items;
                inputFirstName.Value = user.userFirstName;
                inputLastName.Value = user.userLastName;
                inputEmail.Value = user.userEmail;
                inputDateOfBirth.Value = user.userDateOfBirth.ToString("yyyy-MM-dd").Substring(0, 10);
                inputPhone.Value = user.userPhone.ToString();
                inputHobbies.Value= user.userHobbies.ToString();
                if (user.userGender == "Male")
                {
                    Male.Checked = true;
                }
                else if(user.userGender =="Female")
                {
                    Female.Checked = true;
                }
                else
                {
                    others.Checked = true;
                }
                inputPresentLine1.Value = user.userPresentLine1;
                inputPresentLine2.Value = user.userPresentLine2;
                inputPresentPincode.Value = user.userPresentPincode.ToString();
                inputCityPresent.Value = user.userPresentCity;
                inputPermanentLine1.Value = user.userPermanentLine1;
                inputPermanentLine2.Value = user.userPermanentLine2;
                inputPermanentPincode.Value=user.userPermanentPincode.ToString();
                inputPermanentCity.Value= user.userPermanentCity;
                subscribe.Checked = (user.userSubscribed == "True")? true:false;
                Image1.ImageUrl = "Handler1.ashx?ImID=" + user.userID;

            }
        }
        protected void FetchState(object sender, EventArgs e)
        {

            using (Test1Entities5 entities = new Test1Entities5())
            {
                var CountryID = Int32.Parse(ddlCountryNamesPresent.SelectedValue);
                if(CountryID > 0)
                {
                    var result = entities.States.Where(x => x.CountryID == CountryID);
                    stateNamesPresent.DataSource = result.ToList();
                    stateNamesPresent.DataTextField = "StateName";
                    stateNamesPresent.DataValueField = "StateID";
                    stateNamesPresent.DataBind();
                }
               
            }
        }
        protected void UpdateUser(object sender, EventArgs e)
        {
            int userid = Int32.Parse(Request.QueryString["ID"]);
            String FirstName = inputFirstName.Value;
            String LastName = inputLastName.Value;
            String Date = inputDateOfBirth.Value;
            String Email = inputEmail.Value;
            String Gender = String.Empty;
            int PhoneNumber = Int32.Parse(inputPhone.Value);
            String PresentLine1 = inputPresentLine1.Value;
            String Presentline2 = inputPresentLine2.Value;
            int PresentCountryID = Int32.Parse(ddlCountryNamesPresent.SelectedValue);
            int PresentStateId = stateNamesPresent.SelectedIndex;
            String PresentCityName = inputCityPresent.Value;
            int PresentPincode = Int32.Parse(inputPresentPincode.Value);
            String PermanentLine1 = inputPermanentLine1.Value;
            String PermanentLine2 = inputPermanentLine2.Value;
            int PermanentCountryID = Int32.Parse(ddlcountryNamesPermanent.SelectedValue);
            int PermanentStateID = stateNamesPermanent.SelectedIndex;
            String permanentCity = inputPermanentCity.Value;
            int permanentPincode = Int32.Parse(inputPermanentPincode.Value);
            String Hobbies = inputHobbies.Value;
            List<String> Roles = new List<String>();
            if (Male.Checked == true)
            {
                Gender = "Male";
            }
            else if (Female.Checked == true)
            {
                Gender = "Female";
            }
            else if (others.Checked == true)
            {
                Gender = "Others";
            }
            
            foreach (ListItem item in lbRoles.Items)
            {
                if (item.Selected)
                {
                    Roles.Add(item.Text);
                }
            }

            using (Test1Entities5 entities = new Test1Entities5())
            {
                User c = entities.Users.Where(x => x.userID == userid).First();
                c.userFirstName = FirstName;
                c.userLastName = LastName;
                c.userDateOfBirth = Convert.ToDateTime(Date);
                c.userEmail = Email;
                c.userPhone = PhoneNumber;
                c.userGender = Gender;
                c.userPresentLine1 = PresentLine1;
                c.userPresentLine2 = Presentline2;
                c.userPresentCountryID = PresentCountryID;
                c.userPresentStateID = 1;
                c.userPresentCity = PresentCityName;
                c.userPresentPincode = PresentPincode;
                c.userPermanentLine1 = PermanentLine1;
                c.userPermanentLine2 = PermanentLine2;
                c.userPermanentCity = permanentCity;
                c.userPermanentCountryID = PermanentCountryID;
                c.userPermanentStateID = 2;
                c.userPermanentPincode = permanentPincode;
                c.userHobbies = Hobbies;
                c.userSubscribed = subscribe.Checked.ToString();
               


                if (fiImages.HasFile)
                {
                    int imageLength = fiImages.PostedFile.ContentLength;
                    byte[] imageArr = new byte[imageLength];
                    HttpPostedFile image = fiImages.PostedFile;
                    image.InputStream.Read(imageArr, 0, imageLength);
                    c.imagedata = imageArr;
                    c.imagename = fiImages.FileName;
                }
              
                entities.SaveChanges();
                var userRoles = entities.UserRoles.Where(x => x.userID == c.userID);
                entities.UserRoles.RemoveRange(userRoles);

                entities.SaveChanges();
                List<String> Roles2 = new List<String>();
                foreach (ListItem item in lbRoles.Items)
                {
                    if (item.Selected)
                    {
                        Roles2.Add(item.Value);
                    }
                }
                    Console.WriteLine(Roles2);
                foreach (var item in Roles2)
                {
                    UserRole r = new UserRole
                    {
                        userID = c.userID,
                        RoleID = Int32.Parse(item)
                    };
                    entities.UserRoles.Add(r);
                }
                Console.WriteLine(Roles);
                Console.WriteLine(entities.UserRoles);
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Updated  Data Succesfully');", true);
                entities.SaveChanges();
                Results.Text = "Updated succesfully";
               
            }
        }
        protected void SubmitUser(object sender, EventArgs e)
         {
                String FirstName = inputFirstName.Value;
                String LastName = inputLastName.Value;
                String Date = inputDateOfBirth.Value;
                String Email = inputEmail.Value;
                String Gender = String.Empty;
                int PhoneNumber = Int32.Parse(inputPhone.Value);
                String PresentLine1 = inputPresentLine1.Value;
                String Presentline2 = inputPresentLine2.Value;
                int PresentCountryID = Int32.Parse(ddlCountryNamesPresent.SelectedValue);
                int PresentStateId = stateNamesPresent.SelectedIndex;
                String PresentCityName = inputCityPresent.Value;
                int PresentPincode = Int32.Parse(inputPresentPincode.Value);
                String PermanentLine1 = inputPermanentLine1.Value;
                String PermanentLine2 = inputPermanentLine2.Value;
                int PermanentCountryID = Int32.Parse(ddlcountryNamesPermanent.SelectedValue);
                int PermanentStateID = stateNamesPermanent.SelectedIndex;
                String permanentCity = inputPermanentCity.Value;
                int permanentPincode = Int32.Parse(inputPermanentPincode.Value);
                String Hobbies = inputHobbies.Value;
                int imageLength = fiImages.PostedFile.ContentLength;
                byte[] imageArr = new byte[imageLength];
                HttpPostedFile image = fiImages.PostedFile;
                image.InputStream.Read(imageArr, 0, imageLength);
                 bool subscribes = subscribe.Checked;
            List<String> Roles = new List<String>();
                if (Male.Checked == true)
                {
                    Gender = "Male";
                }
                else if (Female.Checked == true)
                {
                    Gender = "Female";
                }
                else if (others.Checked == true)
                {
                    Gender = "Others";
                }

                foreach (ListItem item in lbRoles.Items)
                {
                    if (item.Selected)
                    {
                        Roles.Add(item.Value);
                    }
                }


           
            using (Test1Entities5 entities = new Test1Entities5())
                {
                    User c = new User
                    {
                        userFirstName = FirstName,
                        userLastName = LastName,
                        userDateOfBirth = Convert.ToDateTime(Date),
                        userEmail = Email,
                        userPhone = PhoneNumber,
                        userGender = Gender,
                        userPresentLine1 = PresentLine1,
                        userPresentLine2 = Presentline2,
                        userPresentCountryID = PresentCountryID,
                        userPresentStateID = 1,
                        userPresentCity = PresentCityName,
                        userPresentPincode = PresentPincode,
                        userPermanentLine1 = PermanentLine1,
                        userPermanentLine2 = PermanentLine2,
                        userPermanentCity = permanentCity,
                        userPermanentCountryID = PermanentCountryID,
                        userPermanentStateID = 2,
                        userPermanentPincode = permanentPincode,
                        userHobbies = Hobbies,
                        userSubscribed = subscribes.ToString(),
                        imagename = fiImages.FileName,
                        imagedata = imageArr,
                    };
                 entities.Users.Add(c);
                entities.SaveChanges();
                foreach (var item in Roles)
                {
                    UserRole r = new UserRole
                    {
                        userID = c.userID,
                        RoleID = Int32.Parse(item)
                    };
                    entities.UserRoles.Add(r);
                }

                entities.SaveChanges();

                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Saved Data Succesfully');", true);
                Results.Text = "saved succesfully";
                Response.Redirect("UserList.aspx");

                }
           
            }
        protected void DeleteUser(object sender , EventArgs e)
        {
            int userid = Int32.Parse(Request.QueryString["ID"]);
            using (Test1Entities5 entities = new Test1Entities5())
            {
                User u  = (from c in entities.Users
                                   where c.userID == userid
                                   select c).FirstOrDefault();
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Deleted User Succesfully');", true);
                entities.Users.Remove(u);
                entities.SaveChanges();
                Response.Redirect("UserList.aspx");
            }
        }
        protected void BindDataRoles()
        {
            using (Test1Entities5 entities = new Test1Entities5())
            {
                lbRoles.DataSource = entities.Roles.ToList();

                lbRoles.DataTextField = "RoleName";

               lbRoles.DataValueField = "RoleID";
                lbRoles.DataBind();
            }
        }
        protected void FetchState2(object sender, EventArgs e)
        {
            

            using (Test1Entities5 entities = new Test1Entities5())
            {
                var CountryID = Int32.Parse(ddlcountryNamesPermanent.SelectedValue);
                if (CountryID > 0)
                {
                    var result = entities.States.Where(x => x.CountryID == CountryID);
                    stateNamesPermanent.DataSource = result.ToList();
                    stateNamesPermanent.DataTextField = "StateName";
                    stateNamesPermanent.DataValueField = "StateID";
                    stateNamesPermanent.DataBind();
                }

            }

        }
        public void BindDataCountries()
        {
            using (Test1Entities5 entities = new Test1Entities5())
            {
                ddlCountryNamesPresent.DataSource = entities.countries.ToList();
                ddlcountryNamesPermanent.DataSource = entities.countries.ToList();
                ddlCountryNamesPresent.DataTextField = "CountryName";
                ddlcountryNamesPermanent.DataTextField = "CountryName";
                ddlCountryNamesPresent.DataValueField = "CountryID";
                ddlcountryNamesPermanent.DataValueField = "CountryID";
                ddlcountryNamesPermanent.DataBind();
                ddlCountryNamesPresent.DataBind();
            }
        }
    }
}