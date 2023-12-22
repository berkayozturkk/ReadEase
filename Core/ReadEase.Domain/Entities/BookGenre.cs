using ReadEase.Domain.Abstraction;

namespace ReadEase.Domain.Entities;

public class BookGenre : Entity
{
    public string GenreName { get; set; }

    public BookGenre(string id) : base(id){}

    public BookGenre(string id,string genreName) : base(id) 
    {
        GenreName = genreName;
    }
}
