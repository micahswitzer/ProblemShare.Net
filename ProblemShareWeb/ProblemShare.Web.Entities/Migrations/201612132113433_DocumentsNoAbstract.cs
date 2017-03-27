namespace ProblemShare.Web.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DocumentsNoAbstract : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Documents", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Documents", "Discriminator");
        }
    }
}
