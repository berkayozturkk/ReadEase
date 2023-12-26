using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;
using ReadEase.Application.Services;
using ReadEase.Domain.Entities;

namespace ReadEase.Application.Features.BookFeatures.Queries.GetAllBookGenre;

public sealed class GetAllBookGenreQueryHandler : IRequestHandler<GetAllBookGenreQuery, IQueryable<GetAllBookGenreQueryItemDto>>
{
    private readonly IBookService _bookService;

    public GetAllBookGenreQueryHandler(IBookService bookService)
    {
        _bookService = bookService;
    }

    public async Task<IQueryable<GetAllBookGenreQueryItemDto>> Handle(GetAllBookGenreQuery request, CancellationToken cancellationToken)
    {
        IQueryable<GetAllBookGenreQueryItemDto> bookGenres = await _bookService.GetAllBookGenreAsync(request, cancellationToken);
        return bookGenres;
    }
}
