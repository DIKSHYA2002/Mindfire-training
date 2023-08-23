using EmployeeManagement;
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
     protected void   BindGrid3()
        {
            try
            {
                int id = Int32.Parse(Session["id"].ToString());
                int userid = Int32.Parse(Request.QueryString["ID"].ToString());
                using (var entities = new Test1Entities1())
                {
                    var data1 = entities.Note_Text.Where(notes => notes.Note_ID == id && notes.To_ID == userid).ToList();
                    var data = from s in data1
                               orderby s.ID descending
                               select s;
                    GridView3.DataSource = data;
                    GridView3.DataBind();
                }
            }
            catch (Exception)
            {

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Int32.Parse(Session["id"].ToString());
            using (var dtContext = new Test1Entities1())
            {
                var user = dtContext.Users.Single(x => x.userID == id);
                var userroles = dtContext.UserRoles.Where(x => x.userID == user.userID).ToList();
                var isadmin = false;
                foreach (var x in userroles)
                {
                    if (x.RoleID == 7)
                    {
                     isadmin = true;
                    }
                }
                if (isadmin)
                {
                    lbtoEveryone.Visible = true;
                    IsEveryone.Visible = true;
                    IsPrivate.Visible = true;
                    lblPrivate.Visible = true;
                    this.BindGrid3();
                }
                else
                {
                    lbtoEveryone.Visible = false;
                    IsEveryone.Visible = false;
                    IsPrivate.Visible = false;
                    lblPrivate.Visible = false;

                }

                if (!this.IsPostBack)
                {
                    this.BindGrid();
                    this.BindGrid2();
                }
            }
        }
        private void BindGrid()
        {
            try
            {
                int id = Int32.Parse(Request.QueryString["ID"].ToString());

                using (var entities = new Test1Entities1())
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

        private void BindGrid2()
        {
            try
            {
                int id = Int32.Parse(Request.QueryString["ID"].ToString());

                using (var entities = new Test1Entities1())
                {
                    var data1 = entities.Note_Text.Where(notes =>  notes.Type == "Company").ToList();
                    var data = from s in data1
                               orderby s.ID descending
                               select s;
                    GridView2.DataSource = data;
                    GridView2.DataBind();
                }
            }
            catch (Exception)
            {

            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

                int id = Int32.Parse(Request.QueryString["ID"].ToString());
               int adminid = Int32.Parse(Session["id"].ToString());
                       if(IsPrivate.Checked && id!=adminid)
                       {

                                    using (var dataContext = new Test1Entities1())
                                    {
                                        Note_Text c = new Note_Text
                                        {
                                            Note_ID = adminid,
                                            Type = "User",
                                            Note = TextArea1.Text,
                                            To_ID = id
                                        };
                                        dataContext.Note_Text.Add(c);
                                        dataContext.SaveChanges();
                                        this.BindGrid3();
                                    }
                       }

                    if(IsEveryone.Checked)
                    {
                        using (var dataContext = new Test1Entities1())
                        {
                            Note_Text c = new Note_Text
                            {
                                Note_ID = id,
                                Type = "Company",
                                Note = TextArea1.Text
                            };
                            dataContext.Note_Text.Add(c);
                            dataContext.SaveChanges();
                            this.BindGrid2();
                        }
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Sent Note to All Succesfully');", true);

            }
            else if(!IsEveryone.Checked && id == adminid)
            {
                using (var dataContext = new Test1Entities1())
                {
                    Note_Text c = new Note_Text
                    {
                        Note_ID = id,
                        Type = "User",
                        Note = TextArea1.Text
                    };
                    dataContext.Note_Text.Add(c);
                    dataContext.SaveChanges();
                    this.BindGrid();
                }
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Added Note Succesfully');", true);

            }


        }
    }
}