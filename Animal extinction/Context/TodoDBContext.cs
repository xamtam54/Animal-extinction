using Animal_extinction.Model;
using Microsoft.EntityFrameworkCore;

namespace Animal_extinction.Context
{
    public class TodoDBContext : DbContext
    {
        public TodoDBContext(DbContextOptions<TodoDBContext> options): base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Viability>()
                .Property(v => v.ReproductionRate)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Viability>()
                .Property(v => v.GeneticDiversity)
                .HasColumnType("decimal(18,2)"); 
        }
        public DbSet<DetailObservations> detailObservations { get; set; } = null!;
        public DbSet<Observations> observations { get; set; } = null!;
        public DbSet<Species> species { get; set; } = null!;
        public DbSet<Threats> threats { get; set; } = null!;
        public DbSet<Viability> viability { get; set; } = null!;
    }
}
