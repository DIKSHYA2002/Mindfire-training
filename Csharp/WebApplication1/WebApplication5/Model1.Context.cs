﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication5
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Test2Entities1 : DbContext
    {
        public Test2Entities1()
            : base("name=Test2Entities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<country> countries { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<userDetail> userDetails { get; set; }
        public virtual DbSet<UserCredential> UserCredentials { get; set; }
        public virtual DbSet<Note_Text> Note_Text { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
    
        public virtual ObjectResult<GetStates_Result> GetStates()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetStates_Result>("GetStates");
        }
    }
}