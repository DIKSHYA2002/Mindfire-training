using EmployeeManagement;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeManagement
{
    public partial class FileUpload : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }

        }
        protected void BtnUpload_Click(object sender, EventArgs e)
        {
            int ids = Int32.Parse(Request.QueryString["ID"].ToString());
            string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
            string contentType = FileUpload1.PostedFile.ContentType;
            using (Stream fs = FileUpload1.PostedFile.InputStream)
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    byte[] bytes = br.ReadBytes((Int32)fs.Length);
                   using(var entities = new Test1Entities1())
                    {
                        Files_Storage fstorage = new Files_Storage
                        {
                            userid = ids,
                            ContentType = contentType,
                            fileName = filename,
                            Data = bytes,
                        };
                        entities.Files_Storage.Add(fstorage);
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('File Uploaded Succesfully');", true);
                        entities.SaveChanges();
                    }
                }
            }
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        protected void BindGrid()
        {
            try
            {
                int id = Int32.Parse(Request.QueryString["ID"].ToString());
                using (var entities = new Test1Entities1())
                {
                    var data1 = entities.Files_Storage.Where(files => files.userid == id).ToList();
                    var data = from s in data1
                               orderby s.fileid descending
                               select s;
                    GridView1.DataSource = data;
                    GridView1.DataBind();
                }
             
            }
            catch (Exception)
            {

            }
        }
        protected void DownloadFile(object sender, EventArgs e)
        {
            int id = int.Parse((sender as LinkButton).CommandArgument);
            byte[] bytes;
            string fileName, contentType;
            using( var entities = new Test1Entities1())
            {
                var data1 = entities.Files_Storage.Where(file => file.fileid == id).Single(); ;
                bytes = (byte[])data1.Data;
                contentType = data1.ContentType.ToString();
                fileName = data1.fileName.ToString();
            }
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = contentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }

    }
}