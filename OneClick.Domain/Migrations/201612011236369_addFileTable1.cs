namespace OneClick.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFileTable1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        NoteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FileId)
                .ForeignKey("dbo.Notes", t => t.NoteId, cascadeDelete: true)
                .Index(t => t.NoteId);
            
            DropColumn("dbo.Notes", "ContentType");
            DropColumn("dbo.Notes", "Content");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notes", "Content", c => c.Binary());
            AddColumn("dbo.Notes", "ContentType", c => c.String());
            DropForeignKey("dbo.Files", "NoteId", "dbo.Notes");
            DropIndex("dbo.Files", new[] { "NoteId" });
            DropTable("dbo.Files");
        }
    }
}
