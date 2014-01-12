namespace eManager.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false),
                        Name = c.String(),
                        HireDate = c.DateTime(),
                        Department_DepartmentID = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.Department", t => t.Department_DepartmentID)
                .Index(t => t.Department_DepartmentID);
            
            CreateTable(
                "dbo.Dependent",
                c => new
                    {
                        DependentID = c.Int(nullable: false, identity: true),
                        EmployeeID = c.Int(nullable: false),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        Relation = c.Int(),
                    })
                .PrimaryKey(t => t.DependentID)
                .ForeignKey("dbo.Employee", t => t.EmployeeID, cascadeDelete: true)
                .Index(t => t.EmployeeID);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Category = c.String(),
                        X = c.Double(nullable: false),
                        Y = c.Double(nullable: false),
                        Width = c.Double(nullable: false),
                        Height = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Dependent", new[] { "EmployeeID" });
            DropIndex("dbo.Employee", new[] { "Department_DepartmentID" });
            DropForeignKey("dbo.Dependent", "EmployeeID", "dbo.Employee");
            DropForeignKey("dbo.Employee", "Department_DepartmentID", "dbo.Department");
            DropTable("dbo.Department");
            DropTable("dbo.Dependent");
            DropTable("dbo.Employee");
        }
    }
}
