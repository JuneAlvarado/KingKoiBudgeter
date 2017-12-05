using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KingKoiBudgeter.Models
{
    public class InvitationHelper
    {
        private ApplicationDbContext db;

        public InvitationHelper(ApplicationDbContext context)
        {
            this.db = context;
        }

        public bool IsInvitationMember(int householdId, string userId)
        {
            var Household = db.Households.Find(householdId);
            var userCheck = Household.Users.Any(h => h.Id == userId);
            return (userCheck);
        }

        public ICollection<ApplicationUser> ListHouseholdMembers(int householdId)
        {
            Household household = db.Households.Find(householdId);
            var userList = household.Users.ToList();
            return (userList);
        }

        public bool AddMembertoHousehold(int householdId, string userId)
        {
            Household household = db.Households.Find(householdId);
            ApplicationUser user = db.Users.Find(userId);

            household.Users.Add(user);

            try
            {
                var userAdded = db.SaveChanges();

                if (userAdded != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool RemoveMemberFromHousehold(int householdId, string userId)
        {
            Household household = db.Households.Find(householdId);
            ApplicationUser user = db.Users.Find(userId);

            household.Users.Remove(user);

            try
            {
                var UserRemove = db.SaveChanges();

                if (UserRemove != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }

}

