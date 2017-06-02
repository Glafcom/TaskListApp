namespace TaskListApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectedDepartmentProperties : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Departments", "HeadId", "dbo.AspNetUsers");
            DropIndex("dbo.Departments", new[] { "HeadId" });
            AlterColumn("dbo.Departments", "HeadId", c => c.Guid());
            CreateIndex("dbo.Departments", "HeadId");
            AddForeignKey("dbo.Departments", "HeadId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Departments", "HeadId", "dbo.AspNetUsers");
            DropIndex("dbo.Departments", new[] { "HeadId" });
            AlterColumn("dbo.Departments", "HeadId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Departments", "HeadId");
            AddForeignKey("dbo.Departments", "HeadId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
