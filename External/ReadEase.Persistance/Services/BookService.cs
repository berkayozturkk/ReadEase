using AutoMapper;
using EntityFrameworkCorePagination.Nuget.Pagination;
using GenericRepository;
using ReadEase.Application.Features.BookFeatures.Command.CreateBook;
using ReadEase.Application.Features.BookFeatures.Queries.GetAllBook;
using ReadEase.Application.Features.BookFeatures.Queries.GetAllBookGenre;
using ReadEase.Application.Services;
using ReadEase.Application.Services.Repositories;
using ReadEase.Domain.Entities;
using ReadEase.Domain.Enums;

namespace ReadEase.Persistance.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IBookGenreRepository _bookGenreRepository;
    private readonly IUnitOfWork __unitOfWork;
    private readonly IMapper _mapper;

    public BookService(IBookRepository bookRepository, IBookGenreRepository bookGenreRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _bookGenreRepository = bookGenreRepository;
        __unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task CreateBookAsync(CreateBookCommand request, CancellationToken cancellationToken)
    {
        Book newBook = _mapper.Map<Book>(request);

        newBook.Id = Guid.NewGuid().ToString();
        newBook.Status = BookStatus.Available;
        newBook.PublishDate = DateTime.Now;

        await _bookRepository.AddAsync(newBook, cancellationToken);
        await __unitOfWork.SaveChangesAsync(cancellationToken);
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

    public async Task<IQueryable<GetAllBookGenreQueryItemDto>> GetAllBookGenreAsync(GetAllBookGenreQuery request, CancellationToken cancellationToken)
    {
        var data = _bookGenreRepository.GetAll().OrderBy(x => x.GenreName);

        IQueryable<GetAllBookGenreQueryItemDto> dtos = data.Select(bg => new GetAllBookGenreQueryItemDto
        {
            Id = bg.Id,
            GenreName = bg.GenreName
        });

        return dtos;
    }
}
