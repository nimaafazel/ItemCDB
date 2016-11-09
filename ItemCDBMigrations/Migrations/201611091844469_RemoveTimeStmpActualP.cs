namespace ItemCDBMigrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveTimeStmpActualP : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tblPOSITIONACTUAL", "SSMA_TimeStamp");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tblPOSITIONACTUAL", "SSMA_TimeStamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "timestamp"));
        }
    }
}
