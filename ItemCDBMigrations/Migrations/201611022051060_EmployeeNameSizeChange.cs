namespace ItemCDBMigrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeNameSizeChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tblEMPLOYEELIST", "LastName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.tblEMPLOYEELIST", "FirstName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.tblEMPLOYEELIST", "MiddleName", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tblEMPLOYEELIST", "MiddleName", c => c.String(maxLength: 10));
            AlterColumn("dbo.tblEMPLOYEELIST", "FirstName", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.tblEMPLOYEELIST", "LastName", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
