using AutoMapper;
using BookOperations.DBOperations;
using BookOperations.Entities;

namespace BookOperations.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {       
        public int Id {get;set;}
        public UpdateAuthorModel Model {get; set;}
        private readonly IMapper _mapper;
        private readonly BookStoreDbContext _bookStoreDbContext;
        public UpdateAuthorCommand(BookStoreDbContext bookStoreDbContext,IMapper mapper)
        {
            _mapper = mapper;
            _bookStoreDbContext = bookStoreDbContext;
        }
        public void Handle(){

            var existAuthor = _bookStoreDbContext.Authors.SingleOrDefault(x=>x.Id==Id);
            if(existAuthor is null)
                throw new InvalidOperationException("Yazar mevcut değil");
            
           
            existAuthor.Name = string.IsNullOrWhiteSpace(Model.Name) ? existAuthor.Name : Model.Name;
            existAuthor.LastName = string.IsNullOrWhiteSpace(Model.LastName) ? existAuthor.LastName : Model.LastName;
            existAuthor.BirthDay = Model.BirthDay != default ? Model.BirthDay : existAuthor.BirthDay;

            _bookStoreDbContext.SaveChanges();
        }
    }
    public class UpdateAuthorModel
    {
        public string Name {get; set;}
        public string LastName {get; set;}
        public DateTime BirthDay {get; set;}
    }
}