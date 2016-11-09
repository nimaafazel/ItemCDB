namespace ItemCDBMigrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveTimeStmpBudP : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tblPOSITIONBUDGETED", "SSMA_TimeStamp");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tblPOSITIONBUDGETED", "SSMA_TimeStamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "timestamp"));
        }
    }
}
