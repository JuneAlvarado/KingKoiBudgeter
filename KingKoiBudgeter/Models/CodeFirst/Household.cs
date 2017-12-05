using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KingKoiBudgeter.Models
{
    public class Household
    {

        public Household()
        {
            this.Users = new HashSet<ApplicationUser>();
            this.Accounts = new HashSet<Account>();
            this.Budgets = new HashSet<Budget>();
            this.Categories = new HashSet<Category>();
           
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }

        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Updated { get; set; }
        
        public virtual ICollection<ApplicationUser> Users { get; set; }
        public virtual ICollection<Account> Accounts  { get; set; }
        public virtual ICollection<Budget> Budgets { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}