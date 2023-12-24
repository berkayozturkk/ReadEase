using FluentValidation;

namespace ReadEase.Application.Features.BookFeatures.Command.CreateBook;

public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
{
    public CreateBookCommandValidator()
    {
        RuleFor(p => p.Title).NotEmpty().WithMessage("Title name cannot be empty");
        RuleFor(p => p.Title).NotNull().WithMessage("Title name cannot be empty");
        RuleFor(p => p.Title).MinimumLength(2).WithMessage("Title name cannot be shorter than 2 letters");

        RuleFor(p => p.Author).NotEmpty().WithMessage("Author name cannot be empty");
        RuleFor(p => p.Author).NotNull().WithMessage("Author name cannot be empty");
        RuleFor(p => p.Author).MinimumLength(2).WithMessage("Author name cannot be shorter than 2 letters");

        RuleFor(p => p.Description).NotEmpty().WithMessage("Description name cannot be empty");
        RuleFor(p => p.Description).NotNull().WithMessage("Description name cannot be empty");
        RuleFor(p => p.Description).MinimumLength(2).WithMessage("Description name cannot be shorter than 2 letters");

        RuleFor(p => p.ImageURL).NotEmpty().WithMessage("Description name cannot be empty");
        RuleFor(p => p.ImageURL).NotNull().WithMessage("Description name cannot be empty");
        RuleFor(p => p.ImageURL).MinimumLength(2).WithMessage("Author name cannot be shorter than 2 letters");

        //RuleFor(p => p.ISBN).MinimumLength(13).WithMessage("ISBN must be exactly 13 digits");
    }
}
