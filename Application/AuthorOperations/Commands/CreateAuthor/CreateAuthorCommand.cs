using AutoMapper;
using BookOperations.DBOperations;
using BookOperations.Entities;

namespace BookOperations.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommand
    {
        public CreateAuthorModel Model {get; set;}
        private readonly IMapper _mapper;
        private readonly BookStoreDbContext _bookStoreDbContext;
        public CreateAuthorCommand(BookStoreDbContext bookStoreDbContext,IMapper mapper)
        {
            _mapper = mapper;
            _bookStoreDbContext = bookStoreDbContext;
        }
        public void Handle(){

            var mapping = _mapper.Map<Author>(Model);
            var existAuthor = _bookStoreDbContext.Authors.SingleOrDefault(x=>x.Name==Model.Name);
            if(existAuthor is not null)
                throw new InvalidOperationException("Yazar zaten mevcut");
            
            _bookStoreDbContext.Authors.Add(mapping);
            _bookStoreDbContext.SaveChanges();
        }
    }

    public class CreateAuthorModel
    {
        public string Name {get; set;}
        public string LastName {get; set;}
        public DateTime BirthDay {get; set;}
    }
}