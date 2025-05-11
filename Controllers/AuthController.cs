using AutoMapper;
using BookOperations.Application.AuthorOperations.Commands.CreateAuthor;
using BookOperations.Application.AuthorOperations.Commands.DeleteAuthor;
using BookOperations.Application.AuthorOperations.Commands.UpdateAuthor;
using BookOperations.Application.AuthorOperations.Query.GetAuthorById;
using BookOperations.Application.AuthorOperations.Query.GetAuthors;
using BookOperations.DBOperations;
using Microsoft.AspNetCore.Mvc;

namespace AuthorOperations.Controllers;

[Route("api/[controller]s")]
[ApiController]
public class AuthorController : ControllerBase
{
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;
    public AuthorController(BookStoreDbContext context,IMapper mapper)
    {
        _mapper = mapper;
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAuthors()
    {
        GetAuthorsQuery query = new(_context,_mapper);
        var result = query.Handle();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        GetAuthorByIdCommand command = new GetAuthorByIdCommand(_context,_mapper);
        command.Id = id;
        var result = command.Handle();
        return Ok(result);

    }

    [HttpPost]
    public IActionResult Post([FromBody] CreateAuthorModel newAuthor)
    {
        CreateAuthorCommand command = new(_context,_mapper);
        command.Model = newAuthor;
        command.Handle();
        return StatusCode(201,"Created");
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] UpdateAuthorModel updateModel)
    {
        UpdateAuthorCommand updateAuthorCommand = new(_context, _mapper);
        updateAuthorCommand.Id = id;
        updateAuthorCommand.Model = updateModel;
        updateAuthorCommand.Handle();
        return Ok();
    }  
    
    [HttpDelete("{id}")]
    public IActionResult DeleteAuthor(int id)
    {
        DeleteAuthorCommand deleteAuthorCommand = new DeleteAuthorCommand(_context);
        deleteAuthorCommand.Id = id;
        deleteAuthorCommand.Handle();
        return Ok();
    }
}
