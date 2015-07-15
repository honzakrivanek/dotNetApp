using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dNetApp.DAL;
using dNetApp.Models;



using System.Data;
using System.Data.Entity;

using System.Net;


using System.Data.Entity.Infrastructure;

namespace dNetApp.Controllers
{
    public class AccountController : Controller
    {

        private AccountsContext db = new AccountsContext();

        // GET Account/List
        public ActionResult List()
        {
            return View(db.Accounts.ToList());
        }

        // GET Account/Form/{id}
        public ActionResult Form(int? id)
        {
            if (id != null)
            {
                Account account = db.Accounts.Find(id); 
                return View(account);
            }
            else
            {
                var account = new Account { };
                return View(account);
            }

            return View();
        }

        // POST Account/Form/{id}
        [HttpPost]
        public ActionResult Form(Account account)
        {
            if (ModelState.IsValid)
            {

                Account oldAccount = db.Accounts.Find(account.ID);
                if(oldAccount != null)
                {
                    //pokus
                    oldAccount.Contacts.Add(new Contact { FirstName = "aaaa", LastName = "dsfewf", Email = "dsff@feffe"});

                    oldAccount.Name = account.Name;
                    db.SaveChanges();
                    return RedirectToAction("List");
                }
            
            
                db.Accounts.Add(account);
                db.SaveChanges();
                return RedirectToAction("List");
            }

            return View(account);
        }
    }
}