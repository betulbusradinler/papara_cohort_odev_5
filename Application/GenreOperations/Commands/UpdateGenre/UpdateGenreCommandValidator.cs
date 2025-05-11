using FluentValidation;

namespace BookOperations.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandValidator:AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(query => query.Model.Name).MinimumLength(4).When(x=>x.Model.Name.Trim() != string.Empty);
        }
    }
}