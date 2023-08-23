using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeManagement.Models;
using EmployeeManagement.Utils;
using EmpployeeManagement.Business;

namespace EmployeeManagement.Web
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if(!IsPostBack)
            {
                try
                {
                    if (Session["id"] == null)
                    {
                        Response.Redirect("UserLogin.aspx" , false);
                    }
                    else
                    {
                       
                        if (Request.QueryString["ID"] == null)
                        {
                            SubmitDiv.Visible = true;
                        }
                        int id = CommonFunctions.GetSession();
                        if (!AccessUserBusiness.IsAdmin(id))
                        {
                            PrivateNotes.Visible = false;
                            PrivateNotesw.Visible = false;
                            DeleteDiv.Visible = false;
                            if (Request.QueryString["ID"] == null)
                            { 

                                Response.Redirect("UserLogin.aspx", false);
                            }
                            if (id != Int32.Parse(Request.QueryString["ID"]))
                            {

                                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Requires Authorisation')", true);
                                string url = Request.Url.AbsolutePath;
                                Response.Redirect(url + "?ID=" + id , false);
                            }
                           
                        }
                        

                        if (id == Int32.Parse(Request.QueryString["ID"]))
                        {
                            DeleteDiv.Visible = false;
                        }
                    }
                }

                catch (Exception ex)
                {
                    CommonFunctions.WriteLogFile(ex);
                }
            }

        }

        [System.Web.Services.WebMethod]
        public static List<Roles> GetAllRoles()
        {
            List<Roles> userslist = AccessUserBusiness.GetAllRoles();
            return userslist;
        }
        [System.Web.Services.WebMethod]
        public static List<Country> GetAllCountry()
        {
            List<Country> countrylist = CountryStateBusiness.GetCountryList();
            return countrylist;
        }

        [System.Web.Services.WebMethod]
        public static List<state> GetStates( int countryid)
        {
            List<state> statelist = CountryStateBusiness.GetStateList(countryid);
            return statelist;
        }

      /*  [System.Web.Services.WebMethod]
        public static bool Submit( Employee u )
        {
            try
            {
                u.UserDateOfBirth = Convert.ToDateTime(u.UserDateOfBirth);
                int submitted = AccessUserBusiness.SubmitUser(u);
                return submitted;

            }
            catch(Exception ex)
            {
                CommonFunctions.WriteLogFile(ex);
                
            }
            return false;
           
        }*/


        [System.Web.Services.WebMethod]
        public static List<Files_Employee> GetFiles_Employee(int id)
        {
           
            List<Files_Employee> personal_files = AccessUserBusiness.GetFiles_Employees(id);
            return personal_files;

        }

        [System.Web.Services.WebMethod]
        public static List<Notes_Employee> GetNotes_Employees(int id)
        {
 
            List<Notes_Employee> personal_notes = AccessUserBusiness.GetNotes_Employees(id);
            return personal_notes;
        }
        [WebMethod]
        public static List<Notes_Employee> GetNotes_Private(int id)
        {
            List<Notes_Employee> private_notes = AccessUserBusiness.GetNotes_Private(id);
            return private_notes;
        }
        [WebMethod]
        public static Employee GetUser(int id)
        {
            try
            {
               
                Employee User = AccessUserBusiness.GetUser(id);
                return User;
            }
            catch(Exception ex)
            {
                CommonFunctions.WriteLogFile(ex);
            }
            return null;
           
        }
        [WebMethod]
        public static void SetNotes(int toid , string note ,string type)
        {
            try
            {
                Notes_Employee newNote = new Notes_Employee();
                newNote.Note = note;
                newNote.Type = type;
                newNote.Note_ID = CommonFunctions.GetSession();
                newNote.To_ID = toid;
                AccessUserBusiness.SetNotes(newNote);
            }
            catch (Exception ex)
            {
                CommonFunctions.WriteLogFile(ex);
            }
     

        }
        
        [WebMethod]
           public static bool DeleteUser(int id)
                {
            try
            {
               bool deleted= AccessUserBusiness.DeleteUser(id);
                return deleted;
            }
            catch(Exception ex)
            {
                CommonFunctions.WriteLogFile(ex);
            }
            return false;
            }

        [WebMethod]
        public static bool UpdateUser(Employee u )
        {
            try
            {
                u.UserDateOfBirth = Convert.ToDateTime(u.UserDateOfBirth);
                bool submitted = AccessUserBusiness.EditUser(u);
                return submitted;
            }
            catch (Exception ex)
            {
                CommonFunctions.WriteLogFile(ex);

            }
            return false;
        }
        [WebMethod]
        public static bool DeleteNote(int id)
        {
            try
            {
                bool deleted = AccessUserBusiness.DeleteNote(id);
                return deleted;
            }
            catch (Exception ex)
            {
                CommonFunctions.WriteLogFile(ex);
            }
            return false;
        }
        [WebMethod]
        public static List<Roles_Employee> GetUserRoles(int id)
        {
            try
            {

                List<Roles_Employee> Roles = AccessUserBusiness.GetUserRoles(id);
                return Roles;
            }
            catch (Exception ex)
            {
                CommonFunctions.WriteLogFile(ex);
            }
            return null;
        }
    }
}