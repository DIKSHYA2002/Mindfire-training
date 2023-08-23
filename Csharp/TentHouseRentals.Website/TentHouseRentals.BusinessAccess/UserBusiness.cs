using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TentHouseRentals.Model;
using TentHouseRentals.Utilities;
using TentHouseRentals.DALDB;

namespace TentHouseRentals.BusinessAccess
{
    public class UserBusiness
    {
        public static bool Reinitialise()
        {
            return UserDAL.Reinitialise();
        }
        public static List<IndividualTransactionDetails> GetIndividualTransactionDetails(int customerId)
        {
            List<IndividualTransactionDetails> transact = UserDAL.GetTransactionInOutDetails(customerId).Select(
                x=> new IndividualTransactionDetails
                {
                    TransactionID = x.TransactionID,
                    TransactionInDate = x.TransactionInDate,
                    TransactionOutDate = x.TransactionOutDate,
                    Quantity = x.Quantity,
                    Type = x.Type,
                    CustomerID = x.CustomerID,
                    ParentID = x.ParentID,
                    ProductID = x.ProductID,
                }).ToList();
            return transact;
        }
       
        public static int IsUser(String email, String password)
        {
            return UserDAL.IsUser(email, password);
        }
        public static bool SubmitProduct(Products product)
        {
            return UserDAL.SubmitProduct(product);
        }

        public static List<TransactionsModel2> GetCustomerTransactions(String CustomerName)
        {
            return UserDAL.GetCustomerTransactions(CustomerName).OrderByDescending(s=>s.TransactionDateTime).ToList();
        }
        public static List<TransactionsModel2> GetProductTransactions(int productId)
        {
            return UserDAL.GetProductTransactions(productId);
        }
        public static String GetProductName(int productId)
        {
            return UserDAL.GetProductName(productId);
        }
      /*  public static int FindCustomerID(String customerName)
        {
            int value = UserDAL.FindCustomerID(customerName);
            return value;
        }*/
        public static bool SubmitCustomer(String customerName)
        {
            return UserDAL.SubmitCustomer(customerName);
        }
        public static List<Products> GetProducts()
        {
            List<Products> products = UserDAL.GetProducts().Select(st => new Products
            {
                ID = st.ID,
                Title = st.Title,
                QuantityBooked = st.QuantityBooked,
                QuantityPresent = st.QuantityPresent,
                Image = st.Image,
                PricePerDay = st.PricePerDay,
            }).ToList();
            return products.OrderBy(s => s.Title).ToList();
        }


        public static Products GetProduct(int id)
        {
            Products products = UserDAL.GetProduct(id);
            return products;
        }

        public static List<Customers> GetCustomers()
        {
            List<Customers> customers = UserDAL.GetCustomers().Select(cu => new Customers
            {
                ID = cu.ID,
                Name = cu.Name,
            }).ToList();

            return customers.OrderBy(s => s.Name).ToList();
        }


        public static String SubmitTransactions(List<TransactionsModel2> transactions)
        {
            return UserDAL.SubmitTransactions(transactions);
        }
    }
}
