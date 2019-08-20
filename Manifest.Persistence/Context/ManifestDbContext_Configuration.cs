namespace Manifest.Persistence.Context
{
    using Microsoft.EntityFrameworkCore;

    public partial class ManifestDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Manifest;Integrated Security=True");
        }
    }
}
