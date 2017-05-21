using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskListApp.Domain.Models;
using TaskListApp.Domain.Models.Identity;

namespace TaskListApp.DAL.AppDbContext
{
    public class TaskListAppDbContext : IdentityDbContext<User, Role, Guid, UserLogin, UserRole, UserClaim>
    {
        public TaskListAppDbContext()
            : base("TaskListAppDbConnection")
        { }

        public DbSet<Department> Departments { get; set; }
        public DbSet<ToDoTask> ToDoTasks { get; set; }

        public static TaskListAppDbContext Create()
        {
            return new TaskListAppDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
