namespace ProblemShare.Web.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inheritance : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Problems", "DocumentId", "dbo.Documents");
            DropForeignKey("dbo.Documents", "InstitutionId", "dbo.Institutions");
            DropPrimaryKey("dbo.Documents");
            DropPrimaryKey("dbo.Institutions");
            DropPrimaryKey("dbo.Problems");
            AddColumn("dbo.Problems", "Number", c => c.Int(nullable: false));
            AlterColumn("dbo.Documents", "DocumentId", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Institutions", "InstitutionId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Problems", "ProblemId", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.Documents", "DocumentId");
            AddPrimaryKey("dbo.Institutions", "InstitutionId");
            AddPrimaryKey("dbo.Problems", "ProblemId");
            AddForeignKey("dbo.Problems", "DocumentId", "dbo.Documents", "DocumentId", cascadeDelete: true);
            AddForeignKey("dbo.Documents", "InstitutionId", "dbo.Institutions", "InstitutionId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Documents", "InstitutionId", "dbo.Institutions");
            DropForeignKey("dbo.Problems", "DocumentId", "dbo.Documents");
            DropPrimaryKey("dbo.Problems");
            DropPrimaryKey("dbo.Institutions");
            DropPrimaryKey("dbo.Documents");
            AlterColumn("dbo.Problems", "ProblemId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Institutions", "InstitutionId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Documents", "DocumentId", c => c.Guid(nullable: false));
            DropColumn("dbo.Problems", "Number");
            AddPrimaryKey("dbo.Problems", "ProblemId");
            AddPrimaryKey("dbo.Institutions", "InstitutionId");
            AddPrimaryKey("dbo.Documents", "DocumentId");
            AddForeignKey("dbo.Documents", "InstitutionId", "dbo.Institutions", "InstitutionId", cascadeDelete: true);
            AddForeignKey("dbo.Problems", "DocumentId", "dbo.Documents", "DocumentId", cascadeDelete: true);
        }
    }
}
