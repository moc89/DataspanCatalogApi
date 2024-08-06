using Dataspan.Api.Messaging.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataspan.Api.Repository
{
    public class CatalogContext : DbContext
    {
        protected CatalogContext()
        {
        }

        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("CatalogDB");
        }

        public virtual DbSet<Author> Authors { get; set; }

        public virtual DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("Authors"); 
                entity.HasIndex(e => e.Id, "PK_AuthorId").IsUnique();
                entity.Property(e => e.Id).ValueGeneratedOnAdd().HasMaxLength(250);
                entity.Property(e => e.Surname).HasMaxLength(250);
                entity.Property(e => e.Name).HasMaxLength(250);
                entity.Property(e => e.BirthYear);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Books"); 
                entity.HasIndex(e => e.Id, "PK_BookId").IsUnique();
                entity.Property(e => e.Id).ValueGeneratedOnAdd().HasMaxLength(250);
                entity.Property(e => e.Title).HasMaxLength(250);
                entity.Property(e => e.Publisher).HasMaxLength(250);
                entity.Property(e => e.PublishedDate).HasMaxLength(250);
                entity.Property(e => e.Authors).HasMaxLength(250);
                entity.Property(e => e.Edition).HasMaxLength(250);
            });
        }

    }
}
