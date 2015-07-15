using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dNetApp.Models
{
    public class Account
    {

        public Account() 
        {
            Contacts = new List<Contact>();
        }

        public int ID { get; set; }
        public string Name { get; set; }

        public virtual IList<Contact> Contacts { get; set; }
        
    }
}