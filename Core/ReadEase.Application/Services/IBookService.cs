using EntityFrameworkCorePagination.Nuget.Pagination;
using ReadEase.Application.Features.BookFeatures.Queries.GetAllBook;
using ReadEase.Application.Responses;
using ReadEase.Domain.Entities;

namespace ReadEase.Application.Services;

public interface IBookService
{
    Task<PaginationResult<Book>> GetAllBookAsync(GetAllBookQuery request, CancellationToken cancellationToken);
}
