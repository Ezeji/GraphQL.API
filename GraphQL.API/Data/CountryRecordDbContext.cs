using GraphQL.API.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.API.Data
{
    public partial class CountryRecordDbContext : DbContext
    {
        public CountryRecordDbContext(DbContextOptions<CountryRecordDbContext> options) : base(options)
        {
        }

        public virtual DbSet<CountryRecord> CountryRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<CountryRecord>(entity =>
            {
                entity.HasKey(e => e.CountryId);

                entity.Property(e => e.Country).IsRequired();

                entity.Property(e => e.Year).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
