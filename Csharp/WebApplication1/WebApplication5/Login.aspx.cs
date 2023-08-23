using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication5
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            using (var dtContext = new Test2Entities1())
            {
                string email = TextBox1.Text;
                string password = TextBox2.Text;
                var user = dtContext.UserCredentials.Single(x => x.Email == email);
                if (user.Password == password)
                {
                    Session["id"] = user.UserID;
                    Response.Redirect("Default.aspx?Type=User&ID=" + user.UserID );
                }
                
            }
        }
            /*SqlConnection con = new SqlConnection(@  
        "Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True");
            SqlCommand cmd = new SqlCommand("select * from tbl_data where username=@username and word=@word", con);
            cmd.Parameters.AddWithValue("@username", TextBox1.Text);
            cmd.Parameters.AddWithValue("word", TextBox2.Text);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (dt.Rows.Count > 0)
            {
                Session["id"] = TextBox1.Text;
                Response.Redirect("Redirectform.aspx");
                Session.RemoveAll();
            }
            else
            {
                Label1.Text = "You're username and word is incorrect";
                Label1.ForeColor = System.Drawing.Color.Red;

            }*/
        }
    }
