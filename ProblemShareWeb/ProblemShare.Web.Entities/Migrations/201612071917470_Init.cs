namespace ProblemShare.Web.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        DocumentId = c.Guid(nullable: false),
                        Name = c.String(),
                        InstitutionId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.DocumentId)
                .ForeignKey("dbo.Institutions", t => t.InstitutionId, cascadeDelete: true)
                .Index(t => t.InstitutionId);
            
            CreateTable(
                "dbo.Institutions",
                c => new
                    {
                        InstitutionId = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.InstitutionId);
            
            CreateTable(
                "dbo.Problems",
                c => new
                    {
                        ProblemId = c.Guid(nullable: false),
                        DocumentId = c.Guid(nullable: false),
                        Body = c.String(),
                    })
                .PrimaryKey(t => t.ProblemId)
                .ForeignKey("dbo.Documents", t => t.DocumentId, cascadeDelete: true)
                .Index(t => t.DocumentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Problems", "DocumentId", "dbo.Documents");
            DropForeignKey("dbo.Documents", "InstitutionId", "dbo.Institutions");
            DropIndex("dbo.Problems", new[] { "DocumentId" });
            DropIndex("dbo.Documents", new[] { "InstitutionId" });
            DropTable("dbo.Problems");
            DropTable("dbo.Institutions");
            DropTable("dbo.Documents");
        }
    }
}
