using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using TentHouseRentals.BusinessAccess;
using TentHouseRentals.Model;
using TentHouseRentals.Utilities;

namespace TentHouseRentals.Web
{
    public partial class TransactionsPage : System.Web.UI.Page
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
        public static List<IndividualTransactionDetails> GetIndividualTransactionDetails(int customerId)
        {
            try
            {
                if (CommonFunctions.GetSession() != -1)
                {
                    List<IndividualTransactionDetails> transact = UserBusiness.GetIndividualTransactionDetails(customerId);
                    return transact;
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
        public static String SubmitTransactions(List<TransactionsModel2> transactions)
        {
            try
            {
                if (CommonFunctions.GetSession() != -1)
                {
                    if (transactions[0].Type == "OUT")
                    {
                        List<TransactionsModel2> transactionDb = transactions.Select(x => new TransactionsModel2()
                        {

                            TransactionDateTime = x.TransactionDateTime,
                            CustomerName = x.CustomerName,
                            ProductName = x.ProductName,
                            Type = x.Type,
                            Quantity = x.Quantity,
                            ParentID = x.ParentID
                        }).ToList();
                        return UserBusiness.SubmitTransactions(transactionDb);

                    }
                    else
                    {
                        List<TransactionsModel2> transactionDb = transactions.Select(x => new TransactionsModel2()
                        {
                            TransactionDateTime = x.TransactionDateTime,
                            CustomerName = x.CustomerName,
                            ProductName = UserBusiness.GetProductName(Int32.Parse(x.ProductName)),
                            Type = x.Type,
                            Quantity = x.Quantity,
                            ParentID = x.ParentID
                        }).ToList();
                        return UserBusiness.SubmitTransactions(transactionDb);
                    }
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
    }
}
