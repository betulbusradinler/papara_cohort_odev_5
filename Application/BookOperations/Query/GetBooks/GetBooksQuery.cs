using AutoMapper;
using BookOperations.Common;
using BookOperations.DBOperations;
using BookOperations.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookOperations.Application.GetBooks;
public class GetBooksQuery
{
    private readonly BookStoreDbContext _dbContext;
    private readonly IMapper _mapper;
    public GetBooksQuery(BookStoreDbContext bookStoreDbContext, IMapper mapper)
    {
        _mapper = mapper;
        _dbContext = bookStoreDbContext;
    }

    public List<BooksViewModel> Handle()
    {
        var bookList = _dbContext.Books.Include(x=>x.Genre).OrderBy(x => x.Id).ToList();
        List<BooksViewModel> vm = _mapper.Map<List<BooksViewModel>>(bookList);
        return vm;
    }

    public class BooksViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }
}
