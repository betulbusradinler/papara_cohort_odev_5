using AutoMapper;
using BookOperations.DBOperations;

namespace BookOperations.GenreOperations.Query; 
public class GetGenresDetailQuery {
    public int GenreID {get;set;}
    public readonly BookStoreDbContext _context;
    public readonly IMapper _mapper;
    public GetGenresDetailQuery(BookStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public  GenreDetailViewModel Handle (){
        var genre = _context.Genres.SingleOrDefault(x=>x.IsActive && x.Id == GenreID);
        if(genre is null)
            throw new InvalidOperationException("Kitap Türü Bulunmadı!");
        GenreDetailViewModel returnObj = _mapper.Map<GenreDetailViewModel>(genre);
        return returnObj;
    }
}

public class GenreDetailViewModel{
    public int Id {get; set;}
    public string Name {get; set;}
}