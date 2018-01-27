namespace OneClick.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNoteTable4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Notes", "Content");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notes", "Content", c => c.Binary());
        }
    }
}
