using FluentValidation;

namespace BookOperations.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommandValidator:AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreCommandValidator()
        {
             RuleFor(query => query.GenreId).GreaterThan(0);
        }
    }
}