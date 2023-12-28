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
using ReadEase.Persistance.Repositories;
using System.Linq;

namespace ReadEase.Persistance.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly ILoanRepository _loanRepository;
    private readonly IBookGenreRepository _bookGenreRepository;
    private readonly IUnitOfWork __unitOfWork;
    private readonly IMapper _mapper;

    public BookService(IBookRepository bookRepository, ILoanRepository loanRepository, IBookGenreRepository bookGenreRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _loanRepository = loanRepository;
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

    public async Task<PaginationResult<GetAllBookQueryListItemDto>> GetAllBookAsync(GetAllBookQuery request, CancellationToken cancellationToken)
    {
        var query = from book in _bookRepository.GetWhere(p => p.Title.ToLower().Contains(request.Search.ToLower()))
                    join loan in _loanRepository.GetWhere(l => l.Status == 0)
                    on book.Id equals loan.BookID into bookLoans
                    from loan in bookLoans.DefaultIfEmpty()
                    select new { Book = book, Loan = loan };

        var result = await query.ToPagedListAsync(request.pageNumber, request.pageSize, cancellationToken);

        IList<GetAllBookQueryListItemDto> books = result.Datas.Select(x => new GetAllBookQueryListItemDto
        {
            Title = x.Book.Title,
            Author = x.Book.Author,
            Description = x.Book.Description,
            ImageURL = x.Book.ImageURL,
            Id = x.Book.Id,
            Status = x.Book.Status,
            ReturnDate = x.Loan?.ReturnDate
        }).ToList();

        PaginationResult<GetAllBookQueryListItemDto> returnModel = new PaginationResult<GetAllBookQueryListItemDto>(books, result.PageNumber, result.PageSize, result.TotalPages);

        return returnModel;
        //PaginationResult<Book> data = await _bookRepository
        //    .GetWhere(p => p.Title.ToLower().Contains(request.Search.ToLower()))
        //    .ToPagedListAsync(request.pageNumber, request.pageSize, cancellationToken);

        //List<Book> result = data.Datas.ToList<Book>();

        //var xdata = _mapper.Map<GetAllBookQueryListItemDto>(result);

        //return data;
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