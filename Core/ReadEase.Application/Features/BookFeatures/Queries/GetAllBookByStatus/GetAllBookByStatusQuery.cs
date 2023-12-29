using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;
using ReadEase.Application.Features.BookFeatures.Queries.GetAllBook;
using ReadEase.Domain.Enums;

namespace ReadEase.Application.Features.BookFeatures.Queries.GetAllBookByStatus;

//public class GetAllBookByStatusQuery : IRequest<IQueryable<GetAllBookByStatusQueryListItemDto>>
//{
//    public BookStatus BookStatus { get; set; }
   
//    public GetAllBookByStatusQuery(){}
//}

public record GetAllBookByStatusQuery(
    BookStatus BookStatus ) : IRequest<IQueryable<GetAllBookByStatusQueryListItemDto>>;
