using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using dNetApp.Models;

namespace dNetApp.DAL
{
    public class AccountsInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<AccountsContext>
    {
        protected override void Seed(AccountsContext context)
        {

            var accounts = new List<Account>
            {
            new Account{Name="Name01"},
            new Account{Name="Name02"},
            new Account{Name="Name03"},
            new Account{Name="Name04"},
            new Account{Name="Name05"}
            };


            context.SaveChanges();


            
            
        }
    }
}