using EmpployeeManagement.Business;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace EmployeeManagement.Web
{
    /// <summary>
    /// Summary description for FileDownload
    /// </summary>
    public class FileDownload : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string filename = context.Request.Params["filename"];
            string filePath = HttpContext.Current.Server.MapPath("~/FileUploads") + "\\" + filename;
            FileInfo file = new FileInfo(filePath);

            if (file.Exists)
            {
                // Clear Rsponse reference  
                context.Response.Clear();
                // Add header by specifying file name  
                context.Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                context.Response.ContentType = "application/octet-stream";
                context.Response.TransmitFile(file.FullName);
                context.Response.Flush();
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