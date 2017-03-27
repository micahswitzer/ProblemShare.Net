using System.Data.Entity;

namespace ProblemShare.Web.Entities
{
    public interface IDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Institution> Institutions { get; set; }
        DbSet<Document> Documents { get; set; }
        DbSet<Test> Tests { get; set; }
        DbSet<Problem> Problems { get; set; }
        DbSet<File> Files { get; set; }
    }
}
