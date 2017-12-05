using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KingKoiBudgeter.Models
{
    public class Budget
    {
        public int Id { get; set; }
        public int MonthFrequency {get; set;}

        public int BudgetCategoryId { get; set; }

        public string Description { get; set; }
        public decimal Amount { get; set; }

        public int? HouseholdId { get; set; }
        public string AuthorUserId { get; set;}
        public string UpdateUserId { get; set; }

        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Updated { get; set; }

        public virtual Household Household { get; set; }
        public virtual Category BudgetCategory { get; set; }
        public virtual ApplicationUser AuthorUser { get; set; }
        public virtual ApplicationUser UpdateUser { get; set; }
    }
}