using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TentHouseRentals.Utilities
{
    public class CommonFunctions
    {
             public static String GetUpdatedFilePath2(string path)
        {
            string filePath = HttpContext.Current.Server.MapPath(path);
            FileInfo oFileInfo = new FileInfo(filePath);
            DateTime lastModifiedTime = oFileInfo.LastWriteTime;
            String newFileName = oFileInfo.Name.Split('.')[0] + "-" + lastModifiedTime.ToString().Replace(" ", "-").Replace(":", "").Replace("-", "") + "-" + "RefreshedFile.css";
            return newFileName;
          }
            public static String GetUpdatedFilePath(string path)
            {
            string filePath = HttpContext.Current.Server.MapPath(path);
            FileInfo oFileInfo = new FileInfo(filePath);
            DateTime lastModifiedTime = oFileInfo.LastWriteTime;
            String newFileName = oFileInfo.Name.Split('.')[0] + "-" + lastModifiedTime.ToString().Replace(" ", "-").Replace(":","").Replace("-","") + "-" + "RefreshedFile.js";
             return newFileName;
            }
            public static string GetFilePath()
        {

            string filepath = ConfigurationManager.AppSettings.Get("LogFilePath") + DateTime.Now.ToShortDateString() + ".Log";
            return filepath;
        }
        public static void WriteLogFile(Exception ex)
        {
            try
            {
                DateTime currentDateTime = DateTime.Now;
                using (StreamWriter sw = File.AppendText(GetFilePath()))
                {

                    while (ex.InnerException != null)
                    {
                        ex = ex.InnerException;
                    }
                    sw.WriteLine(currentDateTime.ToShortDateString());
                    sw.WriteLine(currentDateTime.ToString("HH:mm"));
                    sw.WriteLine($"Message: {ex.Message}");
                    sw.WriteLine("Stacktrace:" + ex.ToString());
                    sw.WriteLine();

                }
            }
            catch(Exception )
            {

            }
           
        }

        public static int GetSession()
        {
            if (HttpContext.Current.Session["id"] != null )
            {
                int id = Int32.Parse(HttpContext.Current.Session["id"].ToString());
                return id;
            }
            return -1;
        }





    }
}
