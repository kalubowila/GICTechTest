using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace GICTechTest.Model.DBModels
{
    public partial class GICTechTest_Context : DbContext
    {
        public GICTechTest_Context()
        {
        }

        public GICTechTest_Context(DbContextOptions<GICTechTest_Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Actuals> Actuals { get; set; }
        public virtual DbSet<Estimates> Estimates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=GICTechTest_DEV;Trusted_Connection=True;MultipleActiveResultSets=true");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actuals>(entity =>
            {
                entity.HasKey(e => e.State);

                entity.Property(e => e.State).ValueGeneratedNever();
            });

            modelBuilder.Entity<Estimates>(entity =>
            {
                entity.HasKey(e => new { e.State, e.Districts });
            });
        }
    }
}
