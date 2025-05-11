using AutoMapper;
using BookOperations.Common;
using BookOperations.DBOperations;
using Microsoft.EntityFrameworkCore;

namespace BookOperations.Application.GetBookById;
public class GetBooksByIdQuery
{
    public int Id { get; set; }

    private readonly BookStoreDbContext _bookStoreDbContext;
    private readonly IMapper _mapper;
    public GetBooksByIdQuery(BookStoreDbContext bookStoreDbContext, IMapper mapper)
    {
        _bookStoreDbContext = bookStoreDbContext;
        _mapper = mapper;
    }

    public GetBooksByIdModel Handle()
    {
        var book = _bookStoreDbContext.Books
                    .Include(x=>x.Genre)
                    .SingleOrDefault(x => x.Id == Id);

        if (book is null)
            throw new InvalidOperationException("Böyle Bir Kitap Mevcut Değil");

        GetBooksByIdModel vm = _mapper.Map<GetBooksByIdModel>(book);
        return vm;

    }
}

public class GetBooksByIdModel //BookDetailViewModel
{
    public string Title { get; set; }
    public int PageCount { get; set; }
    public string PublishDate { get; set; }
    public string Genre { get; set; }
}

