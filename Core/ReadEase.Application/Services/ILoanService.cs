using ReadEase.Application.Features.BookFeatures.Command.CreateBook;
using ReadEase.Application.Features.LoanFeatures.Command.BorrowBook;

namespace ReadEase.Application.Services;

public interface ILoanService
{
    Task BorrowBookAsync(BorrowBookCommand request, CancellationToken cancellationToken);
}
