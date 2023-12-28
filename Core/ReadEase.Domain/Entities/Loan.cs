using ReadEase.Domain.Abstraction;
using ReadEase.Domain.Enums;

namespace ReadEase.Domain.Entities;

public class Loan : Entity
{
    public string BookID { get; set; }
    public string BorrowerName { get; set; }
    public string BorrowerSurname { get; set; }
    public string ContactNumber { get; set; }
    public DateTime BorrowDate { get; set; }
    public DateTime ReturnDate { get; set; }

    public BookStatus Status { get; set; }


    public Loan(){}
    public Loan(string id) : base(id){}
    public Loan(string id, string bookID, string borrowerName, string contactNumber, DateTime borrowDate, DateTime returnDate, BookStatus status) : this(id)
    {
        BookID = bookID;
        BorrowerName = borrowerName;
        ContactNumber = contactNumber;
        BorrowDate = borrowDate;
        ReturnDate = returnDate;
        Status = status;
    }
}