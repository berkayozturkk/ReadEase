using ReadEase.Domain.Abstraction;
using ReadEase.Domain.Enums;

namespace ReadEase.Domain.Entities;

public class Book : Entity
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Description { get; set; }
    public string BookGenreID { get; set; }
    public int ISBN { get; set; }
    public DateTime? PublishDate { get; set; }
    public string? ImageURL { get; set; }

    public BookStatus Status { get; set; }
    public BookGenre Genre { get; set; }

    public Book(string id) : base(id) {}

    public Book(string id,string title, string author, string description, string bookGenreID, int iSBN, DateTime? publishDate, string imageURL, BookStatus status) : this(id)
    {
        Title = title;
        Author = author;
        Description = description;
        BookGenreID = bookGenreID;
        ISBN = iSBN;
        PublishDate = publishDate;
        ImageURL = imageURL;
        Status = status;
    }
}
