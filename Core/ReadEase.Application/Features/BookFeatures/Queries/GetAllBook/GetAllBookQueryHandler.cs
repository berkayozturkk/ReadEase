using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;
using ReadEase.Application.Responses;
using ReadEase.Application.Services;
using ReadEase.Domain.Entities;
using System.Linq;

namespace ReadEase.Application.Features.BookFeatures.Queries.GetAllBook;

public sealed class GetAllBookQueryHandler : IRequestHandler<GetAllBookQuery, PaginationResult<Book>>
{
    private readonly IBookService _bookService;

    public GetAllBookQueryHandler(IBookService bookService)
    {
        _bookService = bookService;
    }

    public async Task<PaginationResult<Book>> Handle(GetAllBookQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<Book> books = await _bookService.GetAllBookAsync(request, cancellationToken);
        return books;
    }
}
