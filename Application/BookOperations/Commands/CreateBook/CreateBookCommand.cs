using AutoMapper;
using BookOperations.DBOperations;
using BookOperations.Entities;

namespace BookOperations.Application.CreateBook;
public class CreateBookCommand
{
    public CreateBookModel Model { get; set; }
    private readonly BookStoreDbContext bookStoreDbContext;
    private readonly IMapper _mapper;
    public CreateBookCommand(BookStoreDbContext bookStoreDbContext, IMapper mapper)
    {
        this.bookStoreDbContext = bookStoreDbContext;
        _mapper = mapper;
    }

    public void Handle()
    {
        var mapBook = _mapper.Map<Book>(Model);
        var book = bookStoreDbContext
            .Books
            .SingleOrDefault(x => x.Title == Model.Title);
        if (book is not null)
            throw new InvalidOperationException("Kitap zaten mevcut");

        bookStoreDbContext.Books.Add(mapBook);
        bookStoreDbContext.SaveChanges();
    }

}

public class CreateBookModel
{
    public string Title { get; set; }
    public int GenreId { get; set; }
    public int PageCount { get; set; }
    public DateTime PublishDate { get; set; }
}