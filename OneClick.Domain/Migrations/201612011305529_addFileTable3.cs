namespace OneClick.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFileTable3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notes", "FileId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notes", "FileId");
        }
    }
}
