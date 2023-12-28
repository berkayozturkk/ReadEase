using MediatR;
using ReadEase.Application.Features.BookFeatures.Command.CreateBook;
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

    public BorrowBookCommand(){}
}
