namespace ItemCDBMigrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveTimeStampEmpl : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tblEMPLOYEELIST", "SSMA_TimeStamp");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tblEMPLOYEELIST", "SSMA_TimeStamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "timestamp"));
        }
    }
}
