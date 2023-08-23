//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TentHouseRentals.DALDB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Transaction
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Transaction()
        {
            this.Transactions1 = new HashSet<Transaction>();
        }
    
        public int TransactionID { get; set; }
        public Nullable<System.DateTime> TransactionDateTime { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public Nullable<int> ParentID { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transaction> Transactions1 { get; set; }
        public virtual Transaction Transaction1 { get; set; }
    }
}