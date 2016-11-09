namespace ItemCDBMigrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredUnit : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tblUnit", "UnitDesc", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tblUnit", "UnitDesc", c => c.String(maxLength: 50));
        }
    }
}
