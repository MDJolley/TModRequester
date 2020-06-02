namespace TMR.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WheresMyDb : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reply", "PostID", "dbo.Post");
            DropIndex("dbo.Reply", new[] { "PostID" });
            CreateTable(
                "dbo.Profile",
                c => new
                    {
                        UserID = c.Guid(nullable: false),
                        Picture = c.String(),
                        UserName = c.String(),
                        BIO = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateIndex("dbo.Reply", "UserID");
            AddForeignKey("dbo.Reply", "UserID", "dbo.Profile", "UserID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reply", "UserID", "dbo.Profile");
            DropIndex("dbo.Reply", new[] { "UserID" });
            DropTable("dbo.Profile");
            CreateIndex("dbo.Reply", "PostID");
            AddForeignKey("dbo.Reply", "PostID", "dbo.Post", "ID", cascadeDelete: true);
        }
    }
}
