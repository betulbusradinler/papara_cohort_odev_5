using AutoMapper;
using BookOperations.Application.CreateBook;
using BookOperations.Application.GenreOperations.Commands.CreateGenre;
using BookOperations.Application.GenreOperations.Commands.DeleteGenre;
using BookOperations.Application.GenreOperations.Commands.UpdateGenre;
using BookOperations.Application.GetBookById;
using BookOperations.Application.GetBooks;
using BookOperations.Application.UpdateBook;
using BookOperations.DBOperations;
using BookOperations.GenreOperations.Command.CreateGenre;
using BookOperations.GenreOperations.Query;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace BookOperations.Controllers;

[Route("api/[controller]s")]
[ApiController]
public class GenreController : ControllerBase
{
    private readonly BookStoreDbContext _context;
    private  readonly IMapper _mapper;
    public GenreController(BookStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetGenres()
    {
        GetGenresQuery query = new(_context,_mapper);
        var result = query.Handle();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetGenreDetail(int id)
    {
        GetGenresDetailQuery query = new(_context, _mapper);
        query.GenreID = id;
        GetGenreDetailQueryValidator validator =new();
        validator.ValidateAndThrow(query);

        var obj = query.Handle();
        return Ok(obj);

    }

    [HttpPost]
    public IActionResult AddGenre([FromBody] CreateGenreModel newBook)
    {
        CreateGenreCommand createGenreCommand = new(_context);
        createGenreCommand.Model = newBook;
        CreateGenreCommandValidator validator = new();
        validator.ValidateAndThrow(createGenreCommand);

        createGenreCommand.Handle();
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateGenre(int id, [FromBody] UpdateGenreModel model)
    {
        UpdateGenreCommand command = new(_context);
        command.GenreId = id;
        command.Model = model;
        UpdateGenreCommandValidator validator = new();
        validator.ValidateAndThrow(command);
        command.Handle();
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteGenre(int id){
        DeleteGenreCommand command = new(_context);
        command.GenreId = id;
        DeleteGenreCommandValidator validator = new();
        validator.ValidateAndThrow(command);
        command.Handle();
        return Ok();
    }
}
