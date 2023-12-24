using ReadEase.Domain.Entities;
using ReadEase.Domain.Enums;

namespace ReadEase.Application.Features.BookFeatures.Queries.GetAllBook;

public class GetAllBookQueryListItemDto
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Description { get; set; }
    public int ISBN { get; set; }
    public DateTime? PublishDate { get; set; }
    public string? ImageURL { get; set; }
    public BookStatus Status { get; set; }
    public BookGenre Genre { get; set; }
}