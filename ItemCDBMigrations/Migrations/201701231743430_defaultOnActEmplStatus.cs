namespace ItemCDBMigrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class defaultOnActEmplStatus : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tblPOSITIONACTUAL", "ActEmplStatus", c => c.String(maxLength: 1, nullable: false, defaultValue: "A"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tblPOSITIONACTUAL", "ActEmplStatus", c => c.String(maxLength: 1, nullable: false));
        }
    }
}
