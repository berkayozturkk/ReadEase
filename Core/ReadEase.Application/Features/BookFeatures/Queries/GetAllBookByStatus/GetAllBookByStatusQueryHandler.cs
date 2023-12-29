using MediatR;
using ReadEase.Application.Services;

namespace ReadEase.Application.Features.BookFeatures.Queries.GetAllBookByStatus;

public class GetAllBookByStatusQueryHandler : IRequestHandler<GetAllBookByStatusQuery, IQueryable<GetAllBookByStatusQueryListItemDto>>
{
    private readonly IBookService _bookService;

    public GetAllBookByStatusQueryHandler(IBookService bookService)
    {
        _bookService = bookService;
    }

    public async Task<IQueryable<GetAllBookByStatusQueryListItemDto>> Handle(GetAllBookByStatusQuery request, CancellationToken cancellationToken)
    {
        var data = await _bookService.GetAllBookByStatusAsync(request, cancellationToken);
        return data;
    }
}
