#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VokabelTrainerAPI.Models;

namespace VokabelTrainerAPI.Data
{
    public class VokabelTrainerAPIContext : DbContext
    {
        public VokabelTrainerAPIContext (DbContextOptions<VokabelTrainerAPIContext> options)
            : base(options)
        {
        }

        public DbSet<VokabelTrainerAPI.Models.Vokabel> Vokabel { get; set; }
        public DbSet<VokabelTrainerAPI.Models.Sprache> Sprache { get; set; }
        public DbSet<VokabelTrainerAPI.Models.WortTyp> WortTyp { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vokabel>().ToTable("Vokabel");
            modelBuilder.Entity<Sprache>().ToTable("Sprache");
            modelBuilder.Entity<WortTyp>().ToTable("WortTyp");

            modelBuilder.Entity<Sprache>().HasIndex(s => s.Name).IsUnique();   
            modelBuilder.Entity<WortTyp>().HasIndex(w => w.Typ).IsUnique();
        }
    }
}
