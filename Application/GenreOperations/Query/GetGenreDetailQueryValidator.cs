using FluentValidation;

namespace BookOperations.GenreOperations.Query; 
public class GetGenreDetailQueryValidator:AbstractValidator<GetGenresDetailQuery>
{
    public GetGenreDetailQueryValidator()
    {
        RuleFor(query => query.GenreID).GreaterThan(0);
    }
}