using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistrationForm
{
    public partial class WebUserControl2 : System.Web.UI.UserControl
    {
     

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {
                this.BindGrid();
            }
        }
        private void BindGrid()
        {
            try
            {
                int id = Int32.Parse(Request.QueryString["ID"].ToString());

                using (Test1Entities5 entities = new Test1Entities5())
                {
                    var data1 = entities.Note_Text.Where(notes => notes.Note_ID == id && notes.Type == "User").ToList();
                    var data = from s in data1
                               orderby s.ID descending
                               select s;
                    GridView1.DataSource = data;
                    GridView1.DataBind();
                }
            }
            catch(Exception)
            {
               
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

                int id = Int32.Parse(Request.QueryString["ID"].ToString());
                using (var dataContext = new Test1Entities5())
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

            this.BindGrid();
        }
    }
}