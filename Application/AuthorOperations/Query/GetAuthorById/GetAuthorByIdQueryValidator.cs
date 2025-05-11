using FluentValidation;

namespace BookOperations.Application.AuthorOperations.Query.GetAuthorById
{
    public class GetAuthorByIdQueryValidator:AbstractValidator<GetAuthorByIdCommand>
    {
        public GetAuthorByIdQueryValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);
        }
    }
}