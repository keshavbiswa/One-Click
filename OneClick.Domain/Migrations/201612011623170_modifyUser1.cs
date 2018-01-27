namespace OneClick.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyUser1 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Notes", "UserId");
            AddForeignKey("dbo.Notes", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notes", "UserId", "dbo.Users");
            DropIndex("dbo.Notes", new[] { "UserId" });
        }
    }
}
