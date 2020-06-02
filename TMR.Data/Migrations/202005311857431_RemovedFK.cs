namespace TMR.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedFK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reply", "UserID", "dbo.Profile");
            DropIndex("dbo.Reply", new[] { "UserID" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Reply", "UserID");
            AddForeignKey("dbo.Reply", "UserID", "dbo.Profile", "UserID", cascadeDelete: true);
        }
    }
}
