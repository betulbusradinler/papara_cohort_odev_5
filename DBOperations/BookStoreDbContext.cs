using BookOperations.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookOperations.DBOperations;
public class BookStoreDbContext:DbContext
{
    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base (options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
            .HasOne(b => b.Author)
            .WithMany(a => a.Books)
            .HasForeignKey(b => b.AuthorId)
            .OnDelete(DeleteBehavior.Restrict);
    }
    public DbSet<Book> Books { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Author> Authors { get; set; }

}
