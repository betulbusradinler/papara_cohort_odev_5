using AutoMapper;
using BookOperations.Application.AuthorOperations.Commands.CreateAuthor;
using BookOperations.Application.AuthorOperations.Commands.UpdateAuthor;
using BookOperations.Application.AuthorOperations.Query.GetAuthorById;
using BookOperations.Application.AuthorOperations.Query.GetAuthors;
using BookOperations.Application.CreateBook;
using BookOperations.Application.GetBookById;
using BookOperations.Entities;
using BookOperations.GenreOperations.Query;
using static BookOperations.Application.GetBooks.GetBooksQuery;

namespace BookOperations.Common;
public class MappingProfile : Profile
{
    public MappingProfile(){

        CreateMap<CreateAuthorModel, Author>();
        
        CreateMap<UpdateAuthorModel, Author>();

        CreateMap<Author, GetAuthorByIdModel>()
            .ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.Books));

        CreateMap<Author, GetAuthorsModel>(); //.ForMember(dest=>dest.Books, opt => opt.MapFrom(src=>src.Books));
            
        CreateMap<Book, AuthorBookModel>()
            .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));

        CreateMap<CreateBookModel, Book>();

        CreateMap<Genre, GenresViewModel>();

        CreateMap<Genre, GenreDetailViewModel>();

        CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt=>opt.MapFrom(src=>src.Genre.Name));

        CreateMap<Book, GetBooksByIdModel>().ForMember(dest => dest.Genre, opt=>opt.MapFrom(src=>src.Genre.Name));
        
    }
}

 // CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt=>opt.MapFrom(src=>((GenreEnum)src.GenreId).ToString()))