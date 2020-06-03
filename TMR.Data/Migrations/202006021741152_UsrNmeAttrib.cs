namespace TMR.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsrNmeAttrib : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Profile", "UserName", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Profile", "UserName", c => c.String());
        }
    }
}
