namespace OneClick.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFileTable : DbMigration
    {
        public override void Up()
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
            AlterColumn("dbo.Notes", "Content", c => c.Binary());
            CreateIndex("dbo.Notes", "files_FileId");
            AddForeignKey("dbo.Notes", "files_FileId", "dbo.Files", "FileId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notes", "files_FileId", "dbo.Files");
            DropIndex("dbo.Notes", new[] { "files_FileId" });
            AlterColumn("dbo.Notes", "Content", c => c.Binary(nullable: false));
            DropColumn("dbo.Notes", "files_FileId");
            DropTable("dbo.Files");
        }
    }
}
