using System.Data.Entity;


namespace ProblemShare.Web.Entities
{
    public class PSContext : DbContext
    {
        public PSContext() : base("ProblemShareDB")
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Problem> Problems { get; set; }
    }
}
