namespace OneClick.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNoteTable1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notes", "ContentType", c => c.String());
            AddColumn("dbo.Notes", "Content", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notes", "Content");
            DropColumn("dbo.Notes", "ContentType");
        }
    }
}
