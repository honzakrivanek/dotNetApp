using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using dNetApp.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace dNetApp.DAL
{
    public class AccountsContext : DbContext
    {

        public AccountsContext() : base("AccountsContext")
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }


    }
}