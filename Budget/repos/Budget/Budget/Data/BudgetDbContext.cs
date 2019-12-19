using Microsoft.EntityFrameworkCore;
using Budget.Models;

namespace Budget.Data
{
    public class BudgetDbContext : DbContext
    {
        public BudgetDbContext(DbContextOptions<BudgetDbContext> options)
            : base(options)
        {
        }
        public DbSet<Banque> Banque { get; set; }
        public DbSet<Ecriture> Ecriture { get; set; }
        public DbSet<Personne> Personne { get; set; }
        public DbSet<Compte> Compte { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Compte>()
                .HasOne<Personne>()
                .WithMany()
                .HasForeignKey(p => p.Id);
            modelBuilder.Entity<Banque>()
                .HasOne<Banque>()
                .WithMany()
                .HasForeignKey(p => p.Id);

            modelBuilder.Entity<Ecriture>()
                .HasOne<Compte>()
                .WithMany()
                .HasForeignKey(p => p.Id);
        }

    }
}
