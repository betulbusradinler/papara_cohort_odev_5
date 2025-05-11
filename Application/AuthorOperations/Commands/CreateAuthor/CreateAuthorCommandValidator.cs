using FluentValidation;

namespace BookOperations.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator:AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(4);
            RuleFor(command => command.Model.BirthDay.Date).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(command => command.Model.LastName).NotEmpty().MinimumLength(4);
        }
    }
}