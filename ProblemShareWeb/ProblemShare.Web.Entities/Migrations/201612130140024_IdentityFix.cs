namespace ProblemShare.Web.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdentityFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Documents", "InstitutionId", "dbo.Institutions");
            DropPrimaryKey("dbo.Institutions");
            AlterColumn("dbo.Institutions", "InstitutionId", c => c.Guid(nullable: false, identity: true, defaultValueSql: "newid()"));
            AddPrimaryKey("dbo.Institutions", "InstitutionId");
            AddForeignKey("dbo.Documents", "InstitutionId", "dbo.Institutions", "InstitutionId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Documents", "InstitutionId", "dbo.Institutions");
            DropPrimaryKey("dbo.Institutions");
            AlterColumn("dbo.Institutions", "InstitutionId", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Institutions", "InstitutionId");
            AddForeignKey("dbo.Documents", "InstitutionId", "dbo.Institutions", "InstitutionId", cascadeDelete: true);
        }
    }
}
