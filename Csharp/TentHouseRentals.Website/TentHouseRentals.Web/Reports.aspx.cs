using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using System.IO;
using TentHouseRentals.BusinessAccess;
using TentHouseRentals.Model;
using iTextSharp.tool.xml;
using TentHouseRentals.Utilities;
using System.Web.Services;
using System.Globalization;

namespace TentHouseRentals.Web
{
    public partial class Reports : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["id"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
            }

        }
       
        [WebMethod(EnableSession=true)]
        public static List<TransactionsModel2> GetProductTransactions(int productId)
        {
            try
            {
                if (CommonFunctions.GetSession() != -1)
                {
                    return UserBusiness.GetProductTransactions(productId);
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                CommonFunctions.WriteLogFile(ex);
            }
            return null;

        }


        [WebMethod(EnableSession=true)]
        public static Products GetProduct(int id)
        {
            try
            {
                if (CommonFunctions.GetSession() != -1)
                {
                    Products products = UserBusiness.GetProduct(id);
                    return products;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                CommonFunctions.WriteLogFile(ex);
                return null;
            }
           
           
        }

    }

}