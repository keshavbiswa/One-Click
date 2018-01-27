namespace OneClick.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUserTable1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "PhoneNo", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "PhoneNo", c => c.Int(nullable: false));
        }
    }
}
