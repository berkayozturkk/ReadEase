using ReadEase.Application.Features.BookFeatures.Command.CreateBook;

namespace ReadEase.Application.Services;

public interface ILoanService
{
    Task BorrowBookAsync(CreateBookCommand request, CancellationToken cancellationToken);
}
