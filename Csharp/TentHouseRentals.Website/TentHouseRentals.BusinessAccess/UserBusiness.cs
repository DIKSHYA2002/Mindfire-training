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
        /// <summary>
        /// calls the reinitialise() from database
        /// </summary>
        /// <returns></returns>
        public static bool Reinitialise()
        {
            return UserDAL.Reinitialise();
        }
        /// <summary>
        /// call the individualtransactiondetails view row from database
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
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
       
        /// <summary>
        /// checks if it is a user or not
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static int IsUser(String email, String password)
        {
            return UserDAL.IsUser(email, password);
        }
        /// <summary>
        /// submit the product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static string SubmitProduct(Products product)
        {
            return UserDAL.SubmitProduct(product);
        }
        /// <summary>
        /// get transactions related to a productId
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>

        public static List<TransactionsModel2> GetProductTransactions(int productId)
        {
            return UserDAL.GetProductTransactions(productId);
        }

        /// <summary>
        /// get productname from id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public static String GetProductName(int productId)
        {
            return UserDAL.GetProductName(productId);
        }

     /// <summary>
     /// submit the customer
     /// </summary>
     /// <param name="customerName"></param>
     /// <returns></returns>
        public static bool SubmitCustomer(String customerName)
        {
            return UserDAL.SubmitCustomer(customerName);
        }

        /// <summary>
        /// get productlist from the database
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// get individual product 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public static Products GetProduct(int id)
        {
            Products products = UserDAL.GetProduct(id);
            return products;
        }
        /// <summary>
        /// get customer list
        /// </summary>
        /// <returns></returns>

        public static List<Customers> GetCustomers()
        {
            List<Customers> customers = UserDAL.GetCustomers().Select(cu => new Customers
            {
                ID = cu.ID,
                Name = cu.Name,
            }).ToList();

            return customers.OrderBy(s => s.Name).ToList();
        }

        /// <summary>
        /// submit the and out transactions
        /// </summary>
        /// <param name="transactions"></param>
        /// <returns></returns>
        public static String SubmitTransactions(List<TransactionsModel2> transactions)
        {
            return UserDAL.SubmitTransactions(transactions);
        }
    }
}
