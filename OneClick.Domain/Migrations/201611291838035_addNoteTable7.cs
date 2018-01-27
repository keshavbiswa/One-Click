namespace OneClick.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNoteTable7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Notes", "Content", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Notes", "Content", c => c.Binary());
        }
    }
}
