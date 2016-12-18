namespace ProblemShare.Web.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AutoId : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Documents", "DocumentId", c => c.Guid(nullable: false, identity: true, defaultValueSql: "newid()"));
            AlterColumn("dbo.Institutions", "InstitutionId", c => c.Guid(nullable: false, identity: true, defaultValueSql: "newid()"));
            AlterColumn("dbo.Problems", "ProblemId", c => c.Guid(nullable: false, identity: true, defaultValueSql: "newid()"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Documents", "DocumentId", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Institutions", "InstitutionId", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Problems", "ProblemId", c => c.Guid(nullable: false, identity: true));
        }
    }
}
