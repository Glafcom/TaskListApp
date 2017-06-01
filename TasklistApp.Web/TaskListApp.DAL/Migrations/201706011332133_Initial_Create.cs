namespace TaskListApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Create : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.AspNetUsers", "Department_Id", "dbo.Departments");
            DropPrimaryKey("dbo.Departments");
            DropPrimaryKey("dbo.ToDoTasks");
            AlterColumn("dbo.Departments", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.ToDoTasks", "Id", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.Departments", "Id");
            AddPrimaryKey("dbo.ToDoTasks", "Id");
            AddForeignKey("dbo.AspNetUsers", "DepartmentId", "dbo.Departments", "Id");
            AddForeignKey("dbo.AspNetUsers", "Department_Id", "dbo.Departments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Department_Id", "dbo.Departments");
            DropForeignKey("dbo.AspNetUsers", "DepartmentId", "dbo.Departments");
            DropPrimaryKey("dbo.ToDoTasks");
            DropPrimaryKey("dbo.Departments");
            AlterColumn("dbo.ToDoTasks", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Departments", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.ToDoTasks", "Id");
            AddPrimaryKey("dbo.Departments", "Id");
            AddForeignKey("dbo.AspNetUsers", "Department_Id", "dbo.Departments", "Id");
            AddForeignKey("dbo.AspNetUsers", "DepartmentId", "dbo.Departments", "Id");
        }
    }
}
