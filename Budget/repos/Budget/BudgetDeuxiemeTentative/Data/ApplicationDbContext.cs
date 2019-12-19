using System;
using System.Collections.Generic;
using System.Text;
using Budget.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BudgetDeuxiemeTentative.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Banque> Banque { get; set; }
        public DbSet<Compte> Compte { get; set; }
        public DbSet<Ecriture> Ecriture { get; set; }
        public DbSet<Personne> Personne { get; set; }
    }
}
