namespace KingKoiBudgeter.Migrations
{
    using KingKoiBudgeter.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<KingKoiBudgeter.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(KingKoiBudgeter.Models.ApplicationDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

                if (!context.Roles.Any(r => r.Name == "Admin"))
                {
                    roleManager.Create(new IdentityRole { Name = "Admin" });
                }


                var userManager = new UserManager<Models.ApplicationUser>(new UserStore<Models.ApplicationUser>(context));

                if (!context.Users.Any(u => u.Email == "JuneAlvarado624@gmail.com"))
                {
                    userManager.Create(new Models.ApplicationUser
                    {
                        UserName = "JuneAlvarado624@gmail.com",
                        Email = "JuneAlvarado624@gmail.com",
                        FirstName = "June",
                        LastName = "June",
                        DisplayName = "June_A"
                    }, "Password-1");
                }
                var userId_June_A = userManager.FindByEmail("JuneAlvarado624@gmail.com").Id;
                userManager.AddToRole(userId_June_A, "Admin");

                context.Categories.AddOrUpdate(c => c.Id,
                    new Models.Category() { Id = 1, Name = "Credit" },
                    new Models.Category() { Id = 2, Name = "Debit" }
                    );

                //  This method will be called after migrating to the latest version.

                //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
                //  to avoid creating duplicate seed data. E.g.
                //
                //    context.People.AddOrUpdate(
                //      p => p.FullName,
                //      new Person { FullName = "Andrew Peters" },
                //      new Person { FullName = "Brice Lambson" },
                //      new Person { FullName = "Rowan Miller" }
                //    );
                //
            }
        }
    }
}

