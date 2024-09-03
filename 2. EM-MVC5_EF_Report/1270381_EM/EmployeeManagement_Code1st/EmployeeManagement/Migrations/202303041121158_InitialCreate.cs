namespace EmployeeManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(nullable: false, maxLength: 50),
                        BirthDate = c.DateTime(nullable: false),
                        AppliedFor = c.String(nullable: false, maxLength: 30),
                        ExpectedSalary = c.Decimal(nullable: false, storeType: "money"),
                        WorkFromHome = c.Boolean(nullable: false),
                        Picture = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        SkillId = c.Int(nullable: false, identity: true),
                        Course = c.String(nullable: false, maxLength: 50),
                        PassingYear = c.Int(nullable: false),
                        Institute = c.String(nullable: false, maxLength: 50),
                        Department = c.String(nullable: false, maxLength: 20),
                        Result = c.String(nullable: false, maxLength: 20),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SkillId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Skills", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Skills", new[] { "EmployeeId" });
            DropTable("dbo.Skills");
            DropTable("dbo.Employees");
        }
    }
}
