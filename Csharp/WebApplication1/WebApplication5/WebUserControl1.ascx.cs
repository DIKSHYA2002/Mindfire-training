using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace WebApplication5
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        public String ObjType { get; set; }
       
        protected void Page_Load(object sender, EventArgs e)
        {
         
            if (!this.IsPostBack)
            {
                this.BindGrid();
            }
        }
        private void BindGrid()
        {
            String Type = ObjType;
            int id = Int32.Parse(Request.QueryString["ID"].ToString());
         
            using (Test2Entities1 entities = new Test2Entities1())
            {
                var data1 = entities.Note_Text.Where(notes => notes.Note_ID == id && notes.Type== Type).ToList();
                var data = from s in data1
                           orderby s.ID descending
                           select s;
                GridView1.DataSource = data;
                GridView1.DataBind();
            }
        }
        protected void Button1_Click(object sender ,EventArgs e)
        {

            String Type = ObjType;
            if (Type == "User")
            {
                int id = Int32.Parse(Request.QueryString["ID"].ToString());
                using (var dataContext = new Test2Entities1())
                {
                    Note_Text c = new Note_Text
                    {
                        Note_ID = id,
                        Type = "User",
                        Note = TextArea1.Text
                    };
                    dataContext.Note_Text.Add(c);
                    dataContext.SaveChanges();
                }
            }
            else if(Type=="Company")
            {
                int id = Int32.Parse(Request.QueryString["ID"].ToString());
                using (var dataContext = new Test2Entities1())
                {
                    Note_Text c = new Note_Text
                    {
                        Note_ID = id,
                        Type = "Company",
                        Note = TextArea1.Text
                    };
                    dataContext.Note_Text.Add(c);
                    dataContext.SaveChanges();
                }
            }


            this.BindGrid();
        }
    }
}