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
                account.Contacts.Add(new Contact { });
                return View(account);
            }
            else
            {
                var account = new Account { };
                return View(account);
            }

            //Never happen
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

                    oldAccount.Name = account.Name;

                    
                    for (int i = 0; i < oldAccount.Contacts.Count; i++)
                    {
                        oldAccount.Contacts[i].FirstName = account.Contacts[i].FirstName;
                        oldAccount.Contacts[i].LastName = account.Contacts[i].LastName;
                        oldAccount.Contacts[i].Email = account.Contacts[i].Email;
                    }
                    
                    if ( (oldAccount.Contacts.Count < account.Contacts.Count) )
                        // && LASTNAME != NULL
                    {
                        oldAccount.Contacts.Add(new Contact { FirstName = account.Contacts.Last().FirstName,
                                                              LastName = account.Contacts.Last().LastName,
                                                              Email = account.Contacts.Last().Email
                                                            });
                    }

                    db.SaveChanges();
                    return RedirectToAction("List");
                }

                db.Accounts.Add(account);
                db.SaveChanges();
                return RedirectToAction("List");
            }
           
            return View(account);
        }


        public ActionResult Delete(int id)
        {
            Account account = db.Accounts.Find(id);
            if (account == null) return RedirectToAction("List");

            for (var i = account.Contacts.Count; i > 0; i--)
            {
                db.Contacts.Remove(account.Contacts[i-1]);
            }
            account.Contacts.Clear();
            db.Accounts.Remove(account);
            db.SaveChanges();
            return RedirectToAction("List");
        }

    }  
}