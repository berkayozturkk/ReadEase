using EntityFrameworkCorePagination.Nuget.Pagination;
using ReadEase.Application.Features.BookFeatures.Command.CreateBook;
using ReadEase.Application.Features.BookFeatures.Queries.GetAllBook;
using ReadEase.Application.Features.BookFeatures.Queries.GetAllBookGenre;
using ReadEase.Domain.Dtos;
using ReadEase.Domain.Entities;

namespace ReadEase.Application.Services;

public interface IBookService
{
    Task<PaginationResult<Book>> GetAllBookAsync(GetAllBookQuery request, CancellationToken cancellationToken);
    Task<IQueryable<GetAllBookGenreQueryItemDto>> GetAllBookGenreAsync(GetAllBookGenreQuery request, CancellationToken cancellationToken);
    Task CreateBookAsync(CreateBookCommand request, CancellationToken cancellationToken);
}
