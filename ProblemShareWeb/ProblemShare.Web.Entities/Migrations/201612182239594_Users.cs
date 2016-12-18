namespace ProblemShare.Web.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Users : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Documents", "UserId", c => c.Guid());
            CreateIndex("dbo.Documents", "UserId");
            AddForeignKey("dbo.Documents", "UserId", "dbo.AspNetUsers", "Id");

            AddColumn("dbo.AspNetUsers", "InstitutionId", c => c.Guid());
            CreateIndex("dbo.AspNetUsers", "InstitutionId");
            AddForeignKey("dbo.AspNetUsers", "InstitutionId", "dbo.Institutions", "InstitutionId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Documents", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "InstitutionId", "dbo.Institutions");
            DropIndex("dbo.AspNetUsers", new[] { "InstitutionId" });
            DropIndex("dbo.Documents", new[] { "UserId" });
            DropColumn("dbo.Documents", "UserId");
        }
    }
}
