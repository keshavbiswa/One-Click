namespace OneClick.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDateTime1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notes", "DateTime", c => c.Single(nullable: false));
            DropColumn("dbo.Notes", "Date");
            DropColumn("dbo.Notes", "Time");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notes", "Time", c => c.Single(nullable: false));
            AddColumn("dbo.Notes", "Date", c => c.Single(nullable: false));
            DropColumn("dbo.Notes", "DateTime");
        }
    }
}
