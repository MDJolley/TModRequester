namespace TMR.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProfileFK : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Post", "UserID");
            CreateIndex("dbo.Reply", "UserID");
            AddForeignKey("dbo.Post", "UserID", "dbo.Profile", "UserID", cascadeDelete: true);
            AddForeignKey("dbo.Reply", "UserID", "dbo.Profile", "UserID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reply", "UserID", "dbo.Profile");
            DropForeignKey("dbo.Post", "UserID", "dbo.Profile");
            DropIndex("dbo.Reply", new[] { "UserID" });
            DropIndex("dbo.Post", new[] { "UserID" });
        }
    }
}
