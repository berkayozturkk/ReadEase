using AutoMapper;
using GenericRepository;
using ReadEase.Application.Features.LoanFeatures.Command.BorrowBook;
using ReadEase.Application.Services;
using ReadEase.Application.Services.Repositories;
using ReadEase.Domain.Entities;
using ReadEase.Domain.Enums;

namespace ReadEase.Persistance.Services;

public class LoanService : ILoanService
{
    private readonly ILoanRepository _loanRepository;
    private readonly IBookRepository _bookRepository;
    private readonly IUnitOfWork __unitOfWork;
    private readonly IMapper _mapper;

    public LoanService(ILoanRepository loanRepository, IBookRepository bookRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _loanRepository = loanRepository;
        _bookRepository = bookRepository;
        __unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task BorrowBookAsync(BorrowBookCommand request, CancellationToken cancellationToken)
    {
        Book borrowBook = _bookRepository.GetWhere(x => x.Id == request.BookId).SingleOrDefault();

        if(borrowBook == null)
            throw new ArgumentNullException("Book not found");

        borrowBook.Status = BookStatus.OnLoan;

        Loan loan = _mapper.Map<Loan>(request);

        loan.Id = Guid.NewGuid().ToString();
        loan.BorrowDate = DateTime.Now;
        loan.Status = BookStatus.OnLoan;

        _bookRepository.Update(borrowBook);
        await _loanRepository.AddAsync(loan, cancellationToken);
        await __unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
