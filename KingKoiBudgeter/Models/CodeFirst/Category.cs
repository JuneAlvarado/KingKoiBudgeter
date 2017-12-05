using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KingKoiBudgeter.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? HouseholdId { get; set; }
        public bool IsExpense { get; set; }

        public virtual Household Household { get; set; }
    }
}