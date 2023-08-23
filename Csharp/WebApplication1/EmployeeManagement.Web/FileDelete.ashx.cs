using EmployeeManagement.Models;
using EmpployeeManagement.Business;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;


namespace EmployeeManagement.Web
{
    /// <summary>
    /// Summary description for FileDelete
    /// </summary>
    public class FileDelete : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var formData = context.Request.Form;
            int fileId = Int32.Parse(formData["ID"]);
            string filename = AccessUserBusiness.DeleteFile(fileId);
            string folderPath = context.Server.MapPath("~/FileUploads") + "\\" + filename;

            FileInfo file = new FileInfo(folderPath);

            if (file.Exists)//check file exsit or not  
            {
                file.Delete();
            }
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




/*ng System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;
using EmployeeManagement.Models;
using EmpployeeManagement.Business;

namespace EmployeeManagement.Web
{
    /// <summary>
    /// Summary description for FileHandler
    /// </summary>
    public class FileDelete : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            //Check if Request is to Upload the File.
          *//*  if (context.Request.Files.Count > 0)
            {
                //Fetch the Uploaded File.
                HttpPostedFile postedFile = context.Request.Files[0];

                var formData = context.Request.Form;
                int userId = Int32.Parse(formData["ID"]);


                string folderPath = context.Server.MapPath("~/FileUploads/");

                string fileName = Path.GetFileName(postedFile.FileName);
                string storedFileNAME = DateTime.Now.ToString("yyyyMMddHHmmssfff") + fileName;
                //Save the File in Folder.
                postedFile.SaveAs(folderPath + storedFileNAME);
                Files_Employee fs = new Files_Employee();
                fs.UserId = userId;
                fs.ActualFileName = fileName;
                fs.StoredFileName = storedFileNAME;
                fs.CreatedOn = DateTime.Now;
                AccessUserBusiness.SubmitFiles(fs);
                string json = new JavaScriptSerializer().Serialize(
                    new
                    {
                        name = fileName
                    });*//*
                context.Response.StatusCode = (int)HttpStatusCode.OK;
                context.Response.ContentType = "text/json";
            
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
}*/