namespace Manifest.Persistence.Context
{
    using Manifest.Domain.Entities;
    using Microsoft.EntityFrameworkCore;

    public partial class ManifestDbContext : DbContext
    {
        public virtual DbSet<Aircraft> Aircraft { get; set; }

        public virtual DbSet<Jump> Jumps { get; set; }

        public virtual DbSet<Person> People { get; set; }
    }
}
