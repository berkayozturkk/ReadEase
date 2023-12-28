using MediatR;
using ReadEase.Application.Services;
using ReadEase.Domain.Dtos;

namespace ReadEase.Application.Features.LoanFeatures.Command.BorrowBook;

public class BorrowBookCommandHandler : IRequestHandler<BorrowBookCommand, MessageResponse>
{
    private readonly ILoanService _loanService;

    public BorrowBookCommandHandler(ILoanService loanService)
    {
        _loanService = loanService;
    }

    public async Task<MessageResponse> Handle(BorrowBookCommand request, CancellationToken cancellationToken)
    {
        await _loanService.BorrowBookAsync(request, cancellationToken);
        return new("Book is lent", true, request.BookId);
    }
}
