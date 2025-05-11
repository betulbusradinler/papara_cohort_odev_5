using BookOperations.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookOperations.DBOperations;
public class DataGenerator
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
        {
            if (context.Books.Any())
            {
                return;
            }
            context.Genres.AddRange(
                new Genre {
                    Name = " Personal Growth "
                },
                new Genre {
                    Name = " Science Fiction "
                }, 
                new Genre {
                    Name = " Romance "
                }
            );
            context.Authors.AddRange(
                new Author{
                    Name="Eric",
                    LastName = "RIES",
                    BirthDay = new DateTime(1981,01,02)
                },
                new Author{
                    Name="Charlotte",
                    LastName = "Perkins",
                    BirthDay = new DateTime(1982,03,04)
                },
                new Author{
                    Name="Frank",
                    LastName = "Herbert",
                    BirthDay = new DateTime(1982,05,06)
                }
            );
            context.Books.AddRange(
                new Book
                {
                    Title = "Lean Startup",
                    GenreId = 1, // Personal Growtn
                    AuthorId = 1,
                    PageCount = 200,
                    PublishDate = new DateTime(2001, 06, 12)
                },

                new Book
                {
                    Title = "Herland",
                    GenreId = 2,// Science Fiction
                    AuthorId = 2,
                    PageCount = 250,
                    PublishDate = new DateTime(2010, 05, 23)
                },

                new Book
                {
                    Title = "Dune",
                    GenreId = 1, // Science Fiction
                    AuthorId = 3,
                    PageCount = 540,
                    PublishDate = new DateTime(2001, 12, 21)
                }
            );
            context.SaveChanges();
        }
    }
}
