﻿using InvoicePayment.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicePayment.DAL.ORM.Context
{
    public class ProjectContext : DbContext

    {
        public ProjectContext()
        {
            Database.Connection.ConnectionString = "Server=.;Database=Payment;UID=bcp;PWD=123;";
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Bill> Bills { get; set; }
    }
}
