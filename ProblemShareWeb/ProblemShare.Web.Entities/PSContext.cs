using System.Data.Entity;

namespace ProblemShare.Web.Entities
{
    public class PSContext : DbContext
    {
        public PSContext() : base()
        {

        }

        public DbSet<Document> Documents { get; set; }
    }
}
