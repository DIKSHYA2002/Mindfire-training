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
        public static bool Reinitialise()
        {
            try
            {
                using(var entities = new TentHouseRentalEntities())
                {
                  
                    string commands = "TRUNCATE TABLE Transactions;DELETE FROM Customers DBCC CHECKIDENT ('Customers', RESEED, 0);DELETE FROM Products;\r\nDBCC CHECKIDENT ('Products', RESEED, 0);" +
                        "INSERT INTO Products\r\n           (Title\r\n           ,QuantityPresent\r\n           ,QuantityBooked\r\n           ,PricePerDay\r\n           ,Image)\r\n     VALUES\r\n           ('chairs'\r\n           ,23\r\n           ,0\r\n           ,2500\r\n           ,'20230822114040744plastichcaits.jpg'),\r\n\t\t    ('TentHouse'\r\n           ,22\r\n           ,0\r\n           ,1000\r\n           ,'20230822110456917download (1).jpg'),\r\n\t\t    ('Sound System'\r\n           ,20\r\n           ,0\r\n           ,25000\r\n           ,'20230822114132482soundsystems.jpg'),\r\n\t\t   ('Decorated Table'\r\n           ,200\r\n           ,0\r\n           ,2800\r\n           ,'20230822114203797tables.jpeg');\r\n" + "INSERT INTO Customers\r\n           (Name)\r\n     VALUES\r\n           ('user1'),\r\n\t\t   ('user2'),\r\n\t\t   ('user3'),\r\n\t\t   ('user4'),\r\n\t\t   ('user5');\r\n";
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
        public static List<IndividualTransactionDetail> GetTransactionInOutDetails(int customerId)
        {
            using (var entities = new TentHouseRentalEntities())
            {
                List<IndividualTransactionDetail> individual = entities.IndividualTransactionDetails.Where(s=>s.CustomerID == customerId).ToList();
                return individual;
            }
        }
     

        public static int IsUser(String email, String password)
        {
            try
            {
                using (var dtContext = new TentHouseRentalEntities())
                {
                    if ((email != "") && password != "")
                    {
                        var user = dtContext.Users.Single(x => x.Email == email);

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

        public static int FindCustomerID(String customerName)
        {
            try
            {
                using (var entities = new TentHouseRentalEntities())
                {
                    var Customer = entities.Customers.Where(c => c.Name == customerName).FirstOrDefault();
                    return Customer.ID;
                }

            }
            catch (Exception ex)
            {
                CommonFunctions.WriteLogFile(ex);
                return -1;
            }

        }


        public static int FindProductID(String productName)
        {
            try
            {
                using (var entities = new TentHouseRentalEntities())
                {
                    var product = entities.Products.Where(c => c.Title == productName).FirstOrDefault();
                    return product.ID;
                }

            }
            catch (Exception ex)
            {
                CommonFunctions.WriteLogFile(ex);
                return -1;
            }

        }

        public static String FindCustomerName(int CustomerID)
        {
            try
            {
                using (var entities = new TentHouseRentalEntities())
                {
                    var Customer = entities.Customers.Where(c => c.ID == CustomerID).FirstOrDefault();
                    return Customer.Name;
                }

            }
            catch (Exception ex)
            {
                CommonFunctions.WriteLogFile(ex);
                return null;
            }

        }
        public static bool SubmitProduct(Products product)
        {
            try
            {
                using (var dtContext = new TentHouseRentalEntities())
                {
                    Product u = new Product();
                    u.Title = product.Title;
                    u.QuantityPresent = product.QuantityPresent;
                    u.PricePerDay = product.PricePerDay;
                    u.Image = product.Image;
                    u.QuantityBooked = 0;
                    dtContext.Products.Add(u);
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
        public static Products GetProduct(int id)
        {

            try
            {
                using (var entities = new TentHouseRentalEntities())
                {
                    Product product = entities.Products.Where(s=>s.ID == id).Single();
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

        public static string GetProductName(int productId)
        {
            using (var entities = new TentHouseRentalEntities())
            {
                return entities.Products.Where(p => p.ID == productId).First().Title;
            }
        }
        public static bool SubmitCustomer(String customerName)
        {
            try
            {
                using (var dtContext = new TentHouseRentalEntities())
                {
                    var customer = dtContext.Customers.Where(s => s.Name == customerName).FirstOrDefault();
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
        public static List<TransactionsModel2> GetProductTransactions(int productId)
        {

            try
            {
                using (var entities = new TentHouseRentalEntities())
                {
                    List<Transaction> transactions = entities.Transactions.Where(t => t.ProductID == productId).ToList();
                    List<TransactionsModel2> transactionMod = transactions.Select(tr =>
                      new TransactionsModel2
                      {
                          TransactionID = tr.TransactionID,
                          TransactionDateTime = tr.TransactionDateTime.ToString(),
                          CustomerName = FindCustomerName(tr.CustomerID),
                          ProductName = GetProductName(tr.ProductID),
                          Type = tr.Type,
                          Quantity = tr.Quantity,
                          ParentID = tr.ParentID
                      }).ToList();
                    return transactionMod;

                }
            }
            catch (Exception ex)
            {
                CommonFunctions.WriteLogFile(ex);

            }
            return null;
        }

        public static List<TransactionsModel2> GetCustomerTransactions(String CustomerName)
        {

            try
            {
                using (var entities = new TentHouseRentalEntities())
                {
                    int customerId = FindCustomerID(CustomerName);
                    List<Transaction> transactions = entities.Transactions.Where(t => t.CustomerID == customerId && t.Type == "OUT").ToList();

                    List<TransactionsModel2> transactionMod = transactions.Select(tr =>
                       new TransactionsModel2
                       {
                           TransactionID = tr.TransactionID,
                           TransactionDateTime = tr.TransactionDateTime.ToString(),
                           CustomerName = FindCustomerName(tr.CustomerID),
                           ProductName = GetProductName(tr.ProductID),
                           Type = tr.Type,
                           Quantity = tr.Quantity,
                           ParentID = tr.ParentID
                       }).ToList();
                    return transactionMod;
                }
            }
            catch (Exception ex)
            {
                CommonFunctions.WriteLogFile(ex);

            }
            return null;
        }
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
                                Product product = dtContext.Products.Where(s => s.ID == productid).FirstOrDefault();
                                if (product != null)
                                {
 
                                    if (list2[i].Type == "OUT")
                                    {
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


        public static bool CheckReturnDateLaterThanOutDateOrNot(DateTime d , int transactionId)
        {
            using(var entities = new TentHouseRentalEntities())
            {
                var transaction = entities.Transactions.Where(t=>t.TransactionID== transactionId).FirstOrDefault();
                if (d <= transaction.TransactionDateTime)
                {
                    return false;

                }
                return true;


            }
        }

      
    }
}
