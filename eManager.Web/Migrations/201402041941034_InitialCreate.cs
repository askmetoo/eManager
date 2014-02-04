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
                        DepartmentID = c.Int(nullable: false),
                        Name = c.String(),
                        HireDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.Department", t => t.DepartmentID, cascadeDelete: true)
                .Index(t => t.DepartmentID);
            
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
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.DepartmentID);
            
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
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Dependent", new[] { "EmployeeID" });
            DropIndex("dbo.Employee", new[] { "DepartmentID" });
            DropForeignKey("dbo.Dependent", "EmployeeID", "dbo.Employee");
            DropForeignKey("dbo.Employee", "DepartmentID", "dbo.Department");
            DropTable("dbo.Dependent");
            DropTable("dbo.Department");
            DropTable("dbo.Employee");
        }
    }
}
