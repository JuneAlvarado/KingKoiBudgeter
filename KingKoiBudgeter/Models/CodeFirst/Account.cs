using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KingKoiBudgeter.Models
{
    public class Account
    {
        public int Id { get; set; }
        public int? HouseholdId { get; set; }

        public string UserId { get; set; }
        public string Description { get; set; }

        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Updated { get; set; }

        public int AccountTypeId { get; set; }

        public decimal Balance { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Household Household { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }


    }
}