using MediatR;
using ReadEase.Domain.Dtos;

namespace ReadEase.Application.Features.BookFeatures.Command.CreateBook;

public record CreateBookCommand : IRequest<MessageResponse>
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Description { get; set; }
    public string BookGenreId { get; set; }
    public int ISBN { get; set; }
    public string? ImageURL { get; set; }

    public CreateBookCommand(){}
}
