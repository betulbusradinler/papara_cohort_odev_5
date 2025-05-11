using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookOperations.DBOperations;

namespace BookOperations.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {       
        public int Id {get; set;}
        private readonly BookStoreDbContext _bookStoreDbContext;
        public DeleteAuthorCommand(BookStoreDbContext bookStoreDbContext)
        {
            _bookStoreDbContext = bookStoreDbContext;
        }
        public void Handle(){

            var existAuthor = _bookStoreDbContext.Authors.SingleOrDefault(x=>x.Id==Id);
            if(existAuthor is null)
                throw new InvalidOperationException("Yazar mevcut değil");
            
            _bookStoreDbContext.Authors.Remove(existAuthor);
            _bookStoreDbContext.SaveChanges();
        }
    }
}