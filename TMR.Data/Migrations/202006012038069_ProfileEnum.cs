namespace TMR.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProfileEnum : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Profile", "Picture", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Profile", "Picture", c => c.String());
        }
    }
}
