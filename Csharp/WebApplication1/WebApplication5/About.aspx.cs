using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;



namespace WebApplication5
{

 
    public partial class About : Page
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
            using (Test2Entities1 entities = new Test2Entities1())
            {
                GridView1.DataSource = entities.countries.ToList();
                GridView1.DataBind();
            }
        }
        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            this.BindGrid();
          
        }
        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            int countryId = Int32.Parse((row.FindControl("txtCountryID") as TextBox).Text);
            string countryname = (row.FindControl("txtCountryName") as TextBox).Text;
            string countryabr = (row.FindControl("txtCountryAbr") as TextBox).Text;
            using (Test2Entities1 entities = new Test2Entities1())
            {
                country country = (from c in entities.countries
                                     where c.CountryID == countryId
                                     select c ).FirstOrDefault();
                country.CountryName = countryname;
                country.CountryAbr = countryabr;
                entities.SaveChanges();
            }
            GridView1.EditIndex = -1;
            this.BindGrid();
        }
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            string countryname = (row.FindControl("lblCountryName") as Label).Text;
            using (Test2Entities1 entities = new Test2Entities1())
            {
                country country = (from c in entities.countries
                                   where c.CountryName == countryname
                                   select c).FirstOrDefault();
                entities.countries.Remove(country);
                entities.SaveChanges();
            }
            this.BindGrid();
        }
        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            GridView1.EditIndex = -1;
            this.BindGrid();
        }
        protected void AddCountryToDatabase(object sender, EventArgs e)
        {
            using (Test2Entities1 entities = new Test2Entities1())
            {
                country c = new country
                {
                    CountryName = txtCountryName.Text,
                    CountryAbr = txtCountryAbr.Text
                };
                entities.countries.Add(c);
                entities.SaveChanges();
            }
            this.BindGrid();
        }
    }
}