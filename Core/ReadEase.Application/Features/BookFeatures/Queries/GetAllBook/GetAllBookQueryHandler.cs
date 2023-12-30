using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;
using ReadEase.Application.Services;
using ReadEase.Domain.Entities;

namespace ReadEase.Application.Features.BookFeatures.Queries.GetAllBook;

public sealed class GetAllBookQueryHandler : IRequestHandler<GetAllBookQuery, PaginationResult<GetAllBookQueryListItemDto>>
{
    private readonly IBookService _bookService;

    public GetAllBookQueryHandler(IBookService bookService)
    {
        _bookService = bookService;
    }

    public async Task<PaginationResult<GetAllBookQueryListItemDto>> Handle(GetAllBookQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException("ExceptionMid");
        PaginationResult<GetAllBookQueryListItemDto> books = await _bookService.GetAllBookAsync(request, cancellationToken);
        return books;
    }
}
