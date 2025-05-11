using BookOperations.GenreOperations.Command.CreateGenre;
using FluentValidation;

namespace BookOperations.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommandValidator:AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreCommandValidator()
        {
            RuleFor(query => query.Model.Name).NotEmpty().MinimumLength(4);
        }
    }
}