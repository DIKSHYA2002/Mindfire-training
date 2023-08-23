using EmployeeManagement;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RegistrationForm
{
    /// <summary>
    /// Summary description for Handler1
    /// </summary>
    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                string Id = context.Request.QueryString["ImID"].ToString();
                int id = Int32.Parse(Id);
                using(var entities =  new Test1Entities1())
                {
                    var user = entities.Users.Where(s => s.userID == id ).First();
                    var imagedata = (Byte[])user.imagedata;
                    context.Response.BinaryWrite(imagedata);
                    context.Response.ContentType = "image/jpg";
                    context.Response.End();
                }
              
            }
            catch (Exception ex)
            {
                throw ex;
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