using ProblemShare.Web.Interface;
using System.Data.Entity;


namespace ProblemShare.Web.Entities
{
    public class PSContext : DbContext, IDbContext
    {
        public PSContext() : base("ProblemShareDB") { }
        public PSContext(string connectionString) : base(connectionString) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Problem> Problems { get; set; }
        public DbSet<File> Files { get; set; }
    }
}
