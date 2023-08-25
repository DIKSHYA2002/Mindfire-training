using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TentHouseRentals.Model
{
    public class Products
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int QuantityPresent { get; set; }
        public Nullable<int> QuantityBooked { get; set; }
        public int PricePerDay { get; set; }
        public string Image { get; set; }
    }
    public class Customers
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public class Transactions
    {
        public int TransactionID { get; set; }
        public System.DateTime TransactionDateTime { get; set; }
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public Nullable<int> ParentID { get; set; }

    }
    public  class IndividualTransactionDetails
    {
        public int TransactionID { get; set; }
        public System.DateTime TransactionOutDate { get; set; }
        public Nullable<System.DateTime> TransactionInDate { get; set; }
        public int CustomerID { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public int ProductID { get; set; }
        public Nullable<int> ParentID { get; set; }
    }

}
