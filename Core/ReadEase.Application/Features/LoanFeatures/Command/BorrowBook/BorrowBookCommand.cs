using FluentValidation;
using MediatR;
using ReadEase.Application.Features.BookFeatures.Command.CreateBook;
using ReadEase.Application.Services;
using ReadEase.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadEase.Application.Features.LoanFeatures.Command.BorrowBook;

public class BorrowBookCommand : IRequest<MessageResponse>
{
    public string BookId { get; set; }
    public string BorrowerName { get; set; }
    public string BorrowerSurname { get; set; }
    public string ContactNumber { get; set; }
    public DateTime ReturnDate { get; set; }
}

public class BorrowBookCommandHandler : IRequestHandler<BorrowBookCommand, MessageResponse>
{
    private readonly ILoanService _loanService;

    public BorrowBookCommandHandler(ILoanService loanService)
    {
        _loanService = loanService;
    }

    public Task<MessageResponse> Handle(BorrowBookCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

public class BorrowBookCommandValidator : AbstractValidator<BorrowBookCommand>
{
    public BorrowBookCommandValidator()
    {
        RuleFor(p => p.BorrowerName).NotEmpty().WithMessage("Author name cannot be empty");
        RuleFor(p => p.BorrowerName).NotNull().WithMessage("Author name cannot be empty");
        RuleFor(p => p.BorrowerName).MinimumLength(2).WithMessage("Author name cannot be shorter than 2 letters");

        RuleFor(p => p.BorrowerSurname).NotEmpty().WithMessage("Description name cannot be empty");
        RuleFor(p => p.BorrowerSurname).NotNull().WithMessage("Description name cannot be empty");
        RuleFor(p => p.BorrowerSurname).MinimumLength(2).WithMessage("Description name cannot be shorter than 2 letters");

        RuleFor(p => p.ReturnDate)
             .NotEmpty().WithMessage("Return date cannot be empty.")
             .Must(BeInPast).WithMessage("Return date must be in the past.");
    }

    private bool BeInPast(DateTime returnDate)
    {
        // ReturnDate'in şu anki tarihten küçük olup olmadığını kontrol et
        return returnDate < DateTime.Now;
    }
}
