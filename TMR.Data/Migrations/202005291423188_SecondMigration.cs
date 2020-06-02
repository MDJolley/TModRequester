namespace TMR.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reply",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Body = c.String(nullable: false),
                        UserID = c.Guid(nullable: false),
                        TimePosted = c.DateTimeOffset(nullable: false, precision: 7),
                        PostID = c.Int(nullable: false),
                        TimeEdited = c.DateTimeOffset(precision: 7),
                        Solution = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Post", t => t.PostID, cascadeDelete: true)
                .Index(t => t.PostID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reply", "PostID", "dbo.Post");
            DropIndex("dbo.Reply", new[] { "PostID" });
            DropTable("dbo.Reply");
        }
    }
}
