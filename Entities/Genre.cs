using System.ComponentModel.DataAnnotations.Schema;

namespace BookOperations.Entities;

public class Genre
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id {get; set;}
    public string Name {get; set;}
    public bool IsActive {get; set;} = true;
}