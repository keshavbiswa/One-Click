namespace OneClick.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropFileTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Notes", "files_FileId", "dbo.Files");
            DropIndex("dbo.Notes", new[] { "files_FileId" });
            DropColumn("dbo.Notes", "files_FileId");
            DropTable("dbo.Files");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Length = c.Long(nullable: false),
                        Content = c.Binary(),
                    })
                .PrimaryKey(t => t.FileId);
            
            AddColumn("dbo.Notes", "files_FileId", c => c.Int());
            CreateIndex("dbo.Notes", "files_FileId");
            AddForeignKey("dbo.Notes", "files_FileId", "dbo.Files", "FileId");
        }
    }
}
