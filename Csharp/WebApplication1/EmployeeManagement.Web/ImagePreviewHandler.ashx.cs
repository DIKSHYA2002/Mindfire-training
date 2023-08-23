using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagement.Web
{
    /// <summary>
    /// Summary description for ImagePreviewHandler
    /// </summary>
    public class ImagePreviewHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            var formData = context.Request.Form;
               String filename = formData["filename"];

               string folderPath = context.Server.MapPath("~/ImageFolder/") + filename;
                context.Response.Write(folderPath);
                context.Response.ContentType = "text/plain";
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