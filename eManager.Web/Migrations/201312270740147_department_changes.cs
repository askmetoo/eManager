namespace eManager.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class department_changes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employee", "Department_DepartmentID", "dbo.Department");
            DropIndex("dbo.Employee", new[] { "Department_DepartmentID" });
            RenameColumn(table: "dbo.Employee", name: "Department_DepartmentID", newName: "DepartmentID");
            AddForeignKey("dbo.Employee", "DepartmentID", "dbo.Department", "DepartmentID", cascadeDelete: true);
            CreateIndex("dbo.Employee", "DepartmentID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Employee", new[] { "DepartmentID" });
            DropForeignKey("dbo.Employee", "DepartmentID", "dbo.Department");
            RenameColumn(table: "dbo.Employee", name: "DepartmentID", newName: "Department_DepartmentID");
            CreateIndex("dbo.Employee", "Department_DepartmentID");
            AddForeignKey("dbo.Employee", "Department_DepartmentID", "dbo.Department", "DepartmentID");
        }
    }
}
