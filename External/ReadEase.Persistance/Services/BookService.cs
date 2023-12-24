using AutoMapper;
using EntityFrameworkCorePagination.Nuget.Pagination;
using GenericRepository;
using ReadEase.Application.Features.BookFeatures.Queries.GetAllBook;
using ReadEase.Application.Responses;
using ReadEase.Application.Services;
using ReadEase.Application.Services.Repositories;
using ReadEase.Domain.Entities;

namespace ReadEase.Persistance.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IUnitOfWork __unitOfWork;
    private readonly IMapper _mapper;

    public BookService(IBookRepository bookRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _bookRepository = bookRepository;
        __unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<PaginationResult<Book>> GetAllBookAsync(GetAllBookQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<Book> data = await _bookRepository
            .GetWhere(p => p.Title.ToLower().Contains(request.Search.ToLower()))
            .ToPagedListAsync(request.pageNumber, request.pageSize, cancellationToken);

        //List<Book> result = data.Datas.ToList<Book>();

        //var xdata = _mapper.Map<GetAllBookQueryListItemDto>(result);
            
        return data;
    }
}
