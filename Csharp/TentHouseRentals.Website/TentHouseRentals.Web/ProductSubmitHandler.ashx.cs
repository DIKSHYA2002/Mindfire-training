using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using TentHouseRentals.BusinessAccess;
using TentHouseRentals.Utilities;
using TentHouseRentals.Model;

namespace TentHouseRentals.Web
{
    /// <summary>
    /// Summary description for ProductSubmitHandler
    /// </summary>
    public class ProductSubmitHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //Fetch the Uploaded File.
            HttpPostedFile postedFile = context.Request.Files[0];
            var formData = context.Request.Form;
            Products p = new Products();
            p.Title = formData["Title"];
            p.QuantityPresent =Int32.Parse( formData["Quantity"]);
            p.PricePerDay = Int32.Parse(formData["price"]);

            string folderPath = context.Server.MapPath("~/ImageFolder/");
            string fileName = Path.GetFileName(postedFile.FileName);
            string storedFileNAME = DateTime.Now.ToString("yyyyMMddHHmmssfff") + fileName;
            //Save the File in Folder.
            p.Image = storedFileNAME;
            postedFile.SaveAs(folderPath + storedFileNAME);
            string submitProduct = UserBusiness.SubmitProduct(p);
            context.Response.StatusCode = (int)HttpStatusCode.OK;
            context.Response.ContentType = "text/plain";
            context.Response.Write(submitProduct);
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