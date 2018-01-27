namespace OneClick.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyDateTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notes", "Date", c => c.Single(nullable: false));
            AddColumn("dbo.Notes", "Time", c => c.Single(nullable: false));
            DropColumn("dbo.Notes", "DateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notes", "DateTime", c => c.Single(nullable: false));
            DropColumn("dbo.Notes", "Time");
            DropColumn("dbo.Notes", "Date");
        }
    }
}
