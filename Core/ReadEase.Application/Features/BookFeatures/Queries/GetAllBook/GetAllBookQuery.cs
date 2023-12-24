using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;
using ReadEase.Domain.Entities;

namespace ReadEase.Application.Features.BookFeatures.Queries.GetAllBook;

public record GetAllBookQuery(
    int pageNumber = 1,
    int pageSize = 10,
    string Search = "") : IRequest<PaginationResult<Book>>
{}
