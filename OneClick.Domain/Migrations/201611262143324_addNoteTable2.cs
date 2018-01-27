namespace OneClick.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNoteTable2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notes", "Download", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notes", "Download");
        }
    }
}
