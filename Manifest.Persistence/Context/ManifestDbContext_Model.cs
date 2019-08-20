namespace Manifest.Persistence.Context
{
    using Manifest.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public partial class ManifestDbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aircraft>(ConfigureAircraftEntityType);
            modelBuilder.Entity<Jump>(ConfigureJumpEntityType);
            modelBuilder.Entity<Person>(ConfigurePersonEntityType);

            ConfigureJumpData(modelBuilder);
        }

        private static void ConfigureAircraftEntityType(EntityTypeBuilder<Aircraft> aircraftEntityTypeBuilder)
        {
            aircraftEntityTypeBuilder
                .HasKey(aircraft => aircraft.Name);

            aircraftEntityTypeBuilder
                .Property(aircraft => aircraft.Name)
                .HasMaxLength(50);
        }

        private static void ConfigureJumpEntityType(EntityTypeBuilder<Jump> jumpEntityTypeBuilder)
        {
            jumpEntityTypeBuilder
                .HasKey(jump => jump.Id);

            jumpEntityTypeBuilder
                .Property(jump => jump.Id)
                .HasMaxLength(10);
        }

        private static void ConfigurePersonEntityType(EntityTypeBuilder<Person> personEntityTypeBuilder)
        {
            personEntityTypeBuilder
                .HasKey(person => person.ManifestNumber);

            personEntityTypeBuilder
                .Property(person => person.ManifestNumber)
                .HasMaxLength(8);

            personEntityTypeBuilder
                .Property(person => person.FirstName)
                .HasMaxLength(50);

            personEntityTypeBuilder
                .Property(person => person.LastName)
                .HasMaxLength(50);
        }
    }
}
