using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;
using ReadEase.Application.Features.BookFeatures.Queries.GetAllBook;
using ReadEase.Domain.Entities;

namespace ReadEase.Application.Features.BookFeatures.Queries.GetAllBookGenre;

public class GetAllBookGenreQuery : IRequest<IQueryable<GetAllBookGenreQueryItemDto>>
{
}
