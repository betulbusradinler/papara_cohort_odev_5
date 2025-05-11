using AutoMapper;
using BookOperations.Application.AuthorOperations.Commands.CreateAuthor;
using BookOperations.Application.AuthorOperations.Query.GetAuthorById;
using BookOperations.Application.BookOperations.Commands.CreateBook;
using BookOperations.Application.BookOperations.DeleteBook;
using BookOperations.Application.BookOperations.Query.GetBookById;
using BookOperations.Application.CreateBook;
using BookOperations.Application.GetBookById;
using BookOperations.Application.GetBooks;
using BookOperations.Application.UpdateBook;
using BookOperations.DBOperations;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace BookOperations.Controllers;

[Route("api/[controller]s")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;
    public BookController(BookStoreDbContext context,IMapper mapper)
    {
        _mapper = mapper;
        _context = context;
    }

    [HttpGet]
    public IActionResult GetBooks()
    {
        GetBooksQuery query = new(_context,_mapper);
        var result = query.Handle();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        GetBooksByIdQuery command = new(_context,_mapper);
        command.Id = id;
        GetBooksByIdQueryValidator validator = new();
        validator.ValidateAndThrow(command);
        var result = command.Handle();
        return Ok(result);

    }

    [HttpPost]
    public IActionResult Post([FromBody] CreateBookModel newBook)
    {
        CreateBookCommand command = new CreateBookCommand(_context,_mapper);
        command.Model = newBook;
        CreateBookCommandValidator validator = new();
        validator.ValidateAndThrow(command);
        command.Handle();
        return StatusCode(201,"Created");
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] UpdateBookModel updateModel)
    {
        UpdateBookCommand updateBookCommand = new(_context);
        updateBookCommand.Id = id;
        updateBookCommand.Model = updateModel;
        updateBookCommand.Handle();
        return Ok();
    }  
    
    [HttpDelete("{id}")]
    public IActionResult DeleteBook(int id)
    {
        DeleteBookCommand deleteBookCommand = new DeleteBookCommand(_context);
        deleteBookCommand.BookId = id;
        DeleteBookCommandValidator validator = new();
        validator.ValidateAndThrow(deleteBookCommand);
        deleteBookCommand.Handle();
        return Ok();
    }
}
