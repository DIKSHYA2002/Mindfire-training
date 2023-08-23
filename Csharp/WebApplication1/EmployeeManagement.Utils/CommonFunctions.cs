using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Web;


namespace EmployeeManagement.Utils
{

    public class CommonFunctions
    {
        public static string GetFilePath()
        {
         
            string filepath = System.Web.Configuration.WebConfigurationManager.AppSettings.Get("LogFilePath") +DateTime.Now.ToShortDateString() + ".Log"; 
            return filepath;
        }
        public static void WriteLogFile(Exception ex)
        {

            DateTime currentDateTime = DateTime.Now;
            using (StreamWriter sw = File.AppendText(GetFilePath()))
            {
                int Sessionid = -1;
                if ( HttpContext.Current.Session != null)
                {
                    Sessionid = GetSession();
                }
                if (Sessionid > -1)
                {
                    sw.WriteLine("User Active with Id: " + Sessionid);
                }
                sw.WriteLine(currentDateTime.ToShortDateString());
                sw.WriteLine(currentDateTime.ToString("HH:mm"));
                sw.WriteLine($"Message: {ex.Message}");
                sw.WriteLine("Stacktrace:" + ex.ToString());
                sw.WriteLine();
                if( ex.InnerException != null )
                {

                    sw.WriteLine(ex.InnerException.ToString());
                }
            }
        }
        public static int GetSession()
        {
            if(HttpContext.Current.Session!=null)
            {
                int id = Int32.Parse(HttpContext.Current.Session["id"].ToString());
                return id;
            }
            return -1;
        }

       
          


    }
}