using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TentHouseRentals.Web
{
   
    public class UpdateFileHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            String path = String.Empty;

            context.Response.ContentType = "text/plain";
            context.Response.Write(path);
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