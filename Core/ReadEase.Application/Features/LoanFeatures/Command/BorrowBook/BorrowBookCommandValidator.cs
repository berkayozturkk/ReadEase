using FluentValidation;

namespace ReadEase.Application.Features.LoanFeatures.Command.BorrowBook;

public class BorrowBookCommandValidator : AbstractValidator<BorrowBookCommand>
{
    public BorrowBookCommandValidator()
    {
        RuleFor(p => p.BookId)
            .NotEmpty().WithMessage("Id cannot be empty.")
            .Must(BeValidGuid).WithMessage("Id must be a valid GUID.");

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

    private bool BeValidGuid(string id)
    {
        // Id'nin bir GUID olup olmadığını kontrol et
        return Guid.TryParse(id, out _);
    }
}
