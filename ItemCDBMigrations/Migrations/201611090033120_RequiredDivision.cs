namespace ItemCDBMigrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredDivision : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tblDivision", "DivDesc", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.tblDivision", "DivDesc1", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tblDivision", "DivDesc1", c => c.String(maxLength: 50));
            AlterColumn("dbo.tblDivision", "DivDesc", c => c.String(maxLength: 50));
        }
    }
}
