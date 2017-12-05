using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KingKoiBudgeter.Models
{
    public class Transaction
    {
        public int Id { get; set;  }
        public int AccountId { get; set;}

        public string UserId { get; set; }
        public string Description { get; set; }

        public int TransCategoryId{ get; set; }

        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Updated { get; set; }

        public bool Reconcile { get; set; }
        public decimal Balance { get; set; }

        public virtual Account Account { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Category TransCategory { get; set; }
    }
}