using AutoMapper;
using BookOperations.DBOperations;
using Microsoft.EntityFrameworkCore;

namespace BookOperations.Application.AuthorOperations.Query.GetAuthorById
{
    public class GetAuthorByIdCommand
    {
        public int Id {get; set;}
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetAuthorByIdCommand(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetAuthorByIdModel Handle(){

            var author = _context.Authors.Include(x=>x.Books).ThenInclude(b => b.Genre) .SingleOrDefault(x=>x.Id==Id);

            if (author is null)
                throw new InvalidOperationException(" Yazar kayıtlı değil ");

            var mapper = _mapper.Map<GetAuthorByIdModel>(author);
            
            return mapper;
        }
    }

    public class GetAuthorByIdModel
    {
        public string Name {get; set;}
        public string LastName {get; set;}
        public DateTime BirthDay {get; set;}
        public List<AuthorBookModel> Books {get; set;}
    }
    public class AuthorBookModel{
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}