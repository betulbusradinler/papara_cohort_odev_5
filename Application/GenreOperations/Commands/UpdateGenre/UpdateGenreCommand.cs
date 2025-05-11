using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookOperations.DBOperations;

namespace BookOperations.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommand
    {
        public int GenreId {get;set;}
        public UpdateGenreModel Model {get;set;}
        private readonly BookStoreDbContext _bookStoreDbContext;
        public UpdateGenreCommand(BookStoreDbContext bookStoreDbContext)
        {
            _bookStoreDbContext = bookStoreDbContext;
        }

        public void Handle(){
            var genre = _bookStoreDbContext.Genres.SingleOrDefault(x=>x.Id == GenreId);
            if(genre is null)
                throw new InvalidOperationException(" Kitap Türü Bulunamadı ");
            if(_bookStoreDbContext.Genres.Any(x=>x.Name.ToLower() == Model.Name.ToLower() && x.Id != GenreId))
                throw new InvalidOperationException(" Aynı isimli bir kitap türü zaten mevcut ");
            // genre.Name = Model.Name.Trim() == default ? genre.Name : Model.Name;
            genre.Name = string.IsNullOrEmpty(Model.Name.Trim()) ? genre.Name : Model.Name;
            genre.IsActive = Model.IsActive;
            _bookStoreDbContext.SaveChanges();
        }
    }

    public class UpdateGenreModel{
        public string Name {get; set;}
        public bool IsActive {get; set;} = true;
    }
}