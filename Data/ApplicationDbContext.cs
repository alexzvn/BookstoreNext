using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BookstoreNext.Models;

namespace BookstoreNext.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<BookModel>  Books { get; set; }
        public object BookModel { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var book = builder.Entity<BookModel>();

            book.HasKey(b => b.Id);
            book.Property(b => b.Name).IsRequired().HasMaxLength(255);
            book.Property(b => b.Image).HasMaxLength(255);
            book.Property(b => b.Description).HasMaxLength(1000);
            book.Property(b => b.Price).IsRequired();

        }
    }
}
