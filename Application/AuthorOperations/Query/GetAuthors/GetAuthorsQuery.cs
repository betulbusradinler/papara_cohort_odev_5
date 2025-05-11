using AutoMapper;
using BookOperations.DBOperations;
using BookOperations.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookOperations.Application.AuthorOperations.Query.GetAuthors
{
    public class GetAuthorsQuery
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetAuthorsQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetAuthorsModel> Handle(){

            var authors = _context.Authors.OrderBy(x=>x.Id).ToList();

            if (authors is null)
                throw new InvalidOperationException(" Kayıtlı hiç yazar yok ");

            var mapper = _mapper.Map<List<GetAuthorsModel>>(authors);
            
            return mapper;
        }
    }

    public class GetAuthorsModel{
        public string Name {get; set;}
        public string LastName {get; set;}

    }
}