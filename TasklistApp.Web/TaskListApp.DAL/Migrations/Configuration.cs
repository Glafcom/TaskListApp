using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskListApp.DAL.AppDbContext;
using TaskListApp.Domain.Enums;
using TaskListApp.Domain.Models.Identity;

namespace TaskListApp.DAL.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<TaskListAppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TaskListAppDbContext context)
        {
            context.Roles.AddOrUpdate(
                r => r.Name,
                new Role { Name = RoleType.Admin.ToString() },
                new Role { Name = RoleType.Boss.ToString() },
                new Role { Name = RoleType.Head.ToString() },
                new Role { Name = RoleType.Employee.ToString() }

             );

            var userStore = new UserStore<User, Role, Guid, UserLogin, UserRole, UserClaim>(context);
            var userManager = new UserManager<User, Guid>(userStore);

            if (!context.Users.Any(u => u.UserName == "SuperAdmin"))
            {
                var admin = new User
                {
                    Email = "little-beetle_88@mail.ru",
                    UserName = "SuperAdmin",
                    Name = "Super",
                    Surname = "Admin"
                };

                userManager.Create(admin, "admin123");
                userManager.AddToRole(admin.Id, RoleType.Admin.ToString());
            }

            context.SaveChanges();
        }
    }
}
