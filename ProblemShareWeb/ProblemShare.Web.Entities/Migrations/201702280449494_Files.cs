namespace ProblemShare.Web.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Files : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        FileId = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Path = c.String(),
                        MimeType = c.String(),
                        UserId = c.Guid(),
                    })
                .PrimaryKey(t => t.FileId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            AddColumn("dbo.Documents", "FileId", c => c.Guid());
            CreateIndex("dbo.Documents", "FileId");
            AddForeignKey("dbo.Documents", "FileId", "dbo.Files", "FileId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Documents", "FileId", "dbo.Files");
            DropForeignKey("dbo.Files", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Files", new[] { "UserId" });
            DropIndex("dbo.Documents", new[] { "FileId" });
            DropColumn("dbo.Documents", "FileId");
            DropTable("dbo.Files");
        }
    }
}
