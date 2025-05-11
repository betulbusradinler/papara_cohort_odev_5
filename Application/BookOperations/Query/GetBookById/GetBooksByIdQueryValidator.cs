using BookOperations.Application.GetBookById;
using FluentValidation;

namespace BookOperations.Application.BookOperations.Query.GetBookById
{
    public class GetBooksByIdQueryValidator:AbstractValidator<GetBooksByIdQuery>
    {
        public GetBooksByIdQueryValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);
        }
    }
}