using Microsoft.EntityFrameworkCore;
using SamuraiApp.Domain;
using SamuraiApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SamuraiApp.Data.Model
{
    public class SamuraiContext : DbContext
    {
        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> QuotesSamurais { get; set; }
        public DbSet<Clan> Clans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SamuraiAppData;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // for identitfy keys for many to many relationship between Battle and Samurai Entities
            modelBuilder.Entity<SamuraiBattle>().HasKey(s => new { s.BattleId, s.SamuraiId });
            modelBuilder.Entity<Horse>().ToTable("Horses");
        }
    }
}
