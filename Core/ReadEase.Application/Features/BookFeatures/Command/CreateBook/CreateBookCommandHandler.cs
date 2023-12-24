using MediatR;
using ReadEase.Application.Services;
using ReadEase.Domain.Dtos;

namespace ReadEase.Application.Features.BookFeatures.Command.CreateBook;

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, MessageResponse>
{
    private readonly IBookService _bookService;

    public CreateBookCommandHandler(IBookService bookService)
    {
        _bookService = bookService;
    }

    public async Task<MessageResponse> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        await _bookService.CreateBookAsync(request, cancellationToken);
        return new("Book Added", true, null);
    }
}
