using EmployeeManagement.Models;
using EmpployeeManagement.Business;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace EmployeeManagement.Web
{
    /// <summary>
    /// Summary description for SubmitUserHandler
    /// </summary>
    public class SubmitUserHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
             //Fetch the Uploaded File.
                HttpPostedFile postedFile = context.Request.Files[0];
                var formData = context.Request.Form;
                Employee u = new Employee();
                u.UserFirstName = formData["UserFirstName"];
                u.UserLastName = formData["UserLastName"];
                u.UserEmail = formData["UserEmail"];
                u.UserPhone = formData["UserPhone"];
                u.UserGender = formData["UserGender"];
                u.Userpassword = formData["Userpassword"];
                u.UserHobbies = formData["UserHobbies"];
                u.UserPresentLine1 = formData["UserPresentLine1"];
                u.UserPresentLine2 = formData["UserPresentLine2"];
                u.UserPresentPincode = Int32.Parse(formData["UserPresentPincode"]);
                u.UserDateOfBirth = Convert.ToDateTime(formData["UserDateOfBirth"]);
                u.UserPresentCountryID = Int32.Parse(formData["UserPresentCountryID"]);
                u.UserPresentStateID = Int32.Parse(formData["UserPresentCountryID"]);
                u.UserPermanentLine1 = formData["UserPermanentLine1"];
                u.UserPermanentLine2 = formData["UserPermanentLine2"];
                u.UserPermanentCountryID = Int32.Parse(formData["UserPermanentCountryID"]);
                u.UserPermanentStateID = Int32.Parse(formData["UserPermanentStateID"]);
                u.UserPermanentPincode = Int32.Parse(formData["UserPermanentPincode"]);
                u.UserSubscribed = formData["UserSubscribed"];
                u.UserPermanentCity = formData["UserPermanentCity"];
                u.UserPresentCity = formData["UserPresentCity"];
                string folderPath = context.Server.MapPath("~/ImageFolder/");
                string fileName = Path.GetFileName(postedFile.FileName);
                string storedFileNAME = DateTime.Now.ToString("yyyyMMddHHmmssfff") + fileName;
                //Save the File in Folder.
                u.Imagename = storedFileNAME;
                postedFile.SaveAs(folderPath + storedFileNAME);
            int userid = AccessUserBusiness.SubmitUser(u);
            String userroles = formData["userroles[]"];
            int[] userroless = userroles.Split(',').Select(Int32.Parse).ToArray();
            AccessUserBusiness.SubmitUserRoles(userroless, userid);
            string json = new JavaScriptSerializer().Serialize(
                    new
                    {
                        name = userroles
                    });
                context.Response.StatusCode = (int)HttpStatusCode.OK;
                context.Response.ContentType = "text/json";
                context.Response.Write(json);
                context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}