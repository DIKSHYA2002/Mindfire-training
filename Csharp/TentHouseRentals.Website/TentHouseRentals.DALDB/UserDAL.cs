using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TentHouseRentals.Utilities;
using TentHouseRentals.Model;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;

namespace TentHouseRentals.DALDB
{
    public class UserDAL
    {
        /// <summary>
        /// Initialises the database
        /// 1-Truncates(products,customers,transactions)
        /// 2-ReAdds 4 products and 5 customers 
        /// </summary>
        /// <returns></returns>
        public static bool Reinitialise()
        {
            try
            {
                using(var entities = new TentHouseRentalEntities())
                {

               
                    string commands = "TRUNCATE TABLE Transactions;DELETE FROM Customers DBCC CHECKIDENT ('Customers', RESEED, 0);DELETE FROM Products;\r\nDBCC CHECKIDENT ('Products', RESEED, 0);" +
                        "INSERT INTO Products\r\n           (Title\r\n           ,QuantityPresent\r\n           ,QuantityBooked\r\n           ,PricePerDay\r\n           ,Image)\r\n     VALUES\r\n           ('chairs'\r\n           ,23\r\n           ,0\r\n           ,2500\r\n           ,'20230822114040744plastichcaits.jpg'),\r\n\t\t    ('TentHouse'\r\n           ,22\r\n           ,0\r\n           ,1000\r\n           ,'20230821160921242tentHousetents.jpeg'),\r\n\t\t    ('Sound System'\r\n           ,20\r\n           ,0\r\n           ,25000\r\n           ,'20230822114132482soundsystems.jpg'),\r\n\t\t   ('Decorated Table'\r\n           ,200\r\n           ,0\r\n           ,2800\r\n           ,'20230822114203797tables.jpeg');\r\n" + "INSERT INTO Customers\r\n           (Name)\r\n     VALUES\r\n           ('user1'),\r\n\t\t   ('user2'),\r\n\t\t   ('user3'),\r\n\t\t   ('user4'),\r\n\t\t   ('user5');\r\n";
                    entities.Database.ExecuteSqlCommand(commands);

                }
                return true;
            }
            catch(Exception ex)
            {
            CommonFunctions.WriteLogFile(ex);
                return false;
            }
        }

        /// <summary>
        /// Input: CustomerId
        /// Uses the view IndividualTransactionDetail
        /// Output:Transactions (indate,outdate,transactionId,customername,productid,quantity) related to a customerid
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public static List<IndividualTransactionDetail> GetTransactionInOutDetails(int customerId)
        {
            try
            {
                using (var entities = new TentHouseRentalEntities())
                {
                    List<IndividualTransactionDetail> individual = entities.IndividualTransactionDetails.Where(s => s.CustomerID == customerId).OrderByDescending(s => s.TransactionOutDate).ToList();
                    return individual;
                }
            }
            catch(Exception e)
            {
                CommonFunctions.WriteLogFile(e);
                return null;
            }
           
        }
     
        /// <summary>
        /// Checks whether it is a user or not 
        /// </summary>
        /// <param name="email">string,case-sensitive</param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static int IsUser(String email, String password)
        {
            try
            {
                using (var dtContext = new TentHouseRentalEntities())
                {
                    if ((email != "") && password != "")
                    {
                        var user = dtContext.Users.FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper());

                        if (user.Password == password)
                        {
                            return user.ID;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            catch (Exception ex)
            {
                CommonFunctions.WriteLogFile(ex);
            }
            return -1;
        }


        /// <summary>
        /// Finds the customerId associated with a customerName
        /// </summary>
        /// <param name="customerName"></param>
        /// <returns></returns>
        public static int FindCustomerID(String customerName)
        {
            try
            {
                using (var entities = new TentHouseRentalEntities())
                {
                    var Customer = entities.Customers.FirstOrDefault(c => c.Name == customerName);
                    return Customer.ID;
                }

            }
            catch (Exception ex)
            {
                CommonFunctions.WriteLogFile(ex);
                return -1;
            }

        }

        /// <summary>
        /// finds the productid using a productname
        /// </summary>
        /// <param name="productName"></param>
        /// <returns></returns>
        public static int FindProductID(String productName)
        {
            try
            {
                using (var entities = new TentHouseRentalEntities())
                {
                    var product = entities.Products.FirstOrDefault(c => c.Title == productName);
                    return product.ID;
                }

            }
            catch (Exception ex)
            {
                CommonFunctions.WriteLogFile(ex);
                return -1;
            }

        }

        /// <summary>
        /// finds the customername using customer-id
        /// </summary>
        /// <param name="CustomerID"></param>
        /// <returns></returns>
        public static String FindCustomerName(int CustomerID)
        {
            try
            {
                using (var entities = new TentHouseRentalEntities())
                {
                    var Customer = entities.Customers.FirstOrDefault(c => c.ID == CustomerID);
                    return Customer.Name;
                }

            }
            catch (Exception ex)
            {
                CommonFunctions.WriteLogFile(ex);
                return null;
            }

        }
        /// <summary>
        /// submits the product 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static string SubmitProduct(Products product)
        {
            try
            {
                using (var dtContext = new TentHouseRentalEntities())
                {
                    if( product.QuantityPresent<=0 || product.PricePerDay <= 0)
                    {
                        return "Quantity or Price cannot be negative or zero";
                    }

                    Product u = new Product();
                    u.Title = product.Title;
                    u.QuantityPresent = product.QuantityPresent;
                    u.PricePerDay = product.PricePerDay;
                    u.Image = product.Image;
                    u.QuantityBooked = 0;

                    if(dtContext.Products.FirstOrDefault(s => s.Title == u.Title) == null)
                    {
                        dtContext.Products.Add(u);
                        dtContext.SaveChanges();
                        return "Succesfully Added";
                    }
                    else
                    {
                        return "Product Already Exists";
                    }
                   
                }
            }
            catch (Exception ex)
            {
                CommonFunctions.WriteLogFile(ex);
                return "Failed Transaction";
            }
        }

        /// <summary>
        /// get the list of products
        /// </summary>
        /// <returns></returns>
        public static List<Product> GetProducts()
        {

            try
            {
                using (var entities = new TentHouseRentalEntities())
                {
                    List<Product> products = entities.Products.ToList();
                    return products;
                }
            }
            catch (Exception ex)
            {
                CommonFunctions.WriteLogFile(ex);

            }
            return null;

        }

        /// <summary>
        /// get a particular product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Products GetProduct(int id)
        {
            try
            {
                using (var entities = new TentHouseRentalEntities())
                {
                    Product product = entities.Products.SingleOrDefault(s => s.ID == id);
                    Products productnew = new Products();
                    productnew.Image = product.Image;
                    productnew.ID = product.ID;
                    productnew.Title = product.Title;
                    productnew.QuantityPresent = product.QuantityPresent;
                    return productnew;
                }
            }
            catch (Exception ex)
            {
                CommonFunctions.WriteLogFile(ex);

            }
            return null;

        }

        /// <summary>
        /// get the product name associated with productid
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public static string GetProductName(int productId)
        {
            using (var entities = new TentHouseRentalEntities())
            {
                return entities.Products.FirstOrDefault(p => p.ID == productId).Title;
            }
        }
        /// <summary>
        /// Submit the customer to the database
        /// </summary>
        /// <param name="customerName"></param>
        /// <returns></returns>
        public static bool SubmitCustomer(String customerName)
        {
            try
            {
                using (var dtContext = new TentHouseRentalEntities())
                {
                    var customer = dtContext.Customers.FirstOrDefault(s => s.Name == customerName);
                    if (customer != null)
                    {
                        return false;
                    }

                    Customer u = new Customer();
                    u.Name = customerName;
                    dtContext.Customers.Add(u);
                    dtContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                CommonFunctions.WriteLogFile(ex);
                return false;
            }
        }

        /// <summary>
        /// Get the list of customers
        /// </summary>
        /// <returns></returns>
        public static List<Customer> GetCustomers()
        {
            try
            {
                using (var entities = new TentHouseRentalEntities())
                {
                    List<Customer> customers = entities.Customers.ToList();

                    return customers;
                }
            }
            catch (Exception ex)
            {
                CommonFunctions.WriteLogFile(ex);

            }
            return null;

        }

        /// <summary>
        /// gets all the transactions associated with a productID
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public static List<TransactionsModel2> GetProductTransactions(int productId)
        {

            try
            {
                using (var entities = new TentHouseRentalEntities())
                {
                    List<Transaction> transactions = entities.Transactions.Where(t => t.ProductID == productId).ToList();
                    if(transactions.Count != 0 )
                    {
                        List<TransactionsModel2> transactionMod = transactions.Select(tr =>
                     new TransactionsModel2
                     {
                         TransactionID = tr.TransactionID,
                         TransactionDateTime = (System.DateTime)tr.TransactionDateTime,
                         CustomerName = FindCustomerName(tr.CustomerID),
                         ProductName = GetProductName(tr.ProductID),
                         Type = tr.Type,
                         Quantity = tr.Quantity,
                         ParentID = tr.ParentID
                     }).OrderByDescending(s=>s.TransactionDateTime).ToList();
                        return transactionMod;
                    }

                    return null;

                }
            }
            catch (Exception ex)
            {
                CommonFunctions.WriteLogFile(ex);

            }
            return null;
        }

     
        /// <summary>
        /// Submit the transactions list
        /// </summary>
        /// <param name="transactions"></param>
        /// <returns></returns>
        public static String SubmitTransactions(List<TransactionsModel2> transactions)
        {
            String resultMessage = "Server Side Error";
            try
            {
                using (var dtContext = new TentHouseRentalEntities())
                {
                    List<Transaction> list2 = transactions.Select(x => new Transaction()
                    {
                        TransactionDateTime = Convert.ToDateTime(x.TransactionDateTime),
                        CustomerID = FindCustomerID(x.CustomerName),
                        ProductID = FindProductID(x.ProductName),
                        Type = x.Type,
                        Quantity = x.Quantity,
                        ParentID = x.ParentID
                    }).ToList();


                    using (DbContextTransaction transaction = dtContext.Database.BeginTransaction())
                    {
                        try
                        {
                            bool flag = false;
                            for (var i = 0; i < list2.Count; i++)
                            {

                                int amount = list2[i].Quantity;
                                int productid = list2[i].ProductID;
                                Product product = dtContext.Products.FirstOrDefault(s => s.ID == productid);
                                if (product != null)
                                {
 
                                    if (list2[i].Type == "OUT")
                                    {
                                        if(list2[i].CustomerID<=0)
                                        {
                                            Customer u = new Customer();
                                            u.Name = transactions[i].CustomerName;
                                            dtContext.Customers.Add(u);
                                            dtContext.SaveChanges();
                                            list2[i].CustomerID = u.ID;
                                        }
                                        if (amount <= 0)
                                        {
                                            return "Quantity Should be >0";
                                        }
                                        else if (product.QuantityPresent-amount >=0 )
                                        {
                                            product.QuantityPresent = product.QuantityPresent - amount;
                                            product.QuantityBooked = product.QuantityBooked + amount;
                                        }
                                        else
                                        {
                                            resultMessage = "Invalid Amount" + "Quantity Present : " +                                       product.QuantityPresent;
                                            return resultMessage;
                                        }
                                      
                                    }
                                    else
                                    {
                                        if (CheckReturnDateLaterThanOutDateOrNot((DateTime)list2[i].TransactionDateTime, (int)list2[i].ParentID))
                                        {
                                            product.QuantityPresent = product.QuantityPresent + amount;
                                            product.QuantityBooked = product.QuantityBooked - amount;
                                        }
                                        else
                                        {
                                            return "Return Date should be later";
                                        }
                                    }
                                   
                                }
                               
                            }
                          
                           

                            dtContext.Transactions.AddRange(list2);
                            dtContext.SaveChanges();
                            transaction.Commit();
                            return "Successful Transaction";
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            CommonFunctions.WriteLogFile(ex);
                            return "Failed Transaction";
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                CommonFunctions.WriteLogFile(ex);
                return "Failed Transaction";
            }

        }

        /// <summary>
        /// Check the returnDate of a transaction id in the view IndividualtransactionDetails is later then outdate or not
        /// </summary>
        /// <param name="d"></param>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        public static bool CheckReturnDateLaterThanOutDateOrNot(DateTime d , int transactionId)
        {
            using(var entities = new TentHouseRentalEntities())
            {
                var transaction = entities.Transactions.FirstOrDefault(t => t.TransactionID == transactionId);
                if (d <= transaction.TransactionDateTime)
                {
                    return false;

                }
                return true;


            }
        }

       
    }
}
