namespace ItemCDBMigrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredSection : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tblSection", "SecDesc", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.tblSection", "SecDesc1", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tblSection", "SecDesc1", c => c.String(maxLength: 50));
            AlterColumn("dbo.tblSection", "SecDesc", c => c.String(maxLength: 50));
        }
    }
}
