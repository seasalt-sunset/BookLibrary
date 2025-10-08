using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using LibraryApp.Entities;

namespace LibraryApp.Infrastructure
{
    public class LibraryAppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            var configBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configBuilder.GetConnectionString("connectionDb");
            dbContextOptionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("Authors");
                entity.HasKey(author => author.AuthorId);

                entity.HasMany(author => author.Books)
                .WithOne(book => book.Author)
                .HasForeignKey(book => book.AuthorId);
            });
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
