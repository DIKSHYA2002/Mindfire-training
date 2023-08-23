using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace TentHouseRentals.Web
{
    public class UpdateFileHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string path = context.Request.Path;
            string[] filepaths = path.Split('/');
            string fileExtension = filepaths[filepaths.Length-1].Split('.')[filepaths[filepaths.Length - 1].Split('.').Length-1];
            string filename = filepaths[filepaths.Length - 1].Split('-')[0] + "." + fileExtension;
            String filePath = String.Empty;
            if(fileExtension=="js")
            {
                 filePath = HttpContext.Current.Server.MapPath("./SCRIPT") + "\\" + filename;
            }
            else
            {
               filePath = HttpContext.Current.Server.MapPath("./CSS") + "\\" + filename;
            }

            FileInfo file = new FileInfo(filePath);
                if (file.Exists)
                {
                    context.Response.Clear();
                    context.Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                    context.Response.ContentType = "text/" + fileExtension;
                    var refresh = new TimeSpan(365, 0, 0, 0);
                    context.Response.Cache.SetExpires(DateTime.Now.Add(refresh));
                    context.Response.Cache.SetMaxAge(refresh);
                    context.Response.Cache.SetCacheability(HttpCacheability.Public);
                    context.Response.Cache.SetValidUntilExpires(true);
                    context.Response.Cache.SetLastModified(DateTime.Now);
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