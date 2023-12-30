using ReadEase.Domain.Abstraction;

namespace ReadEase.Domain.Entities;

public class ErrorLog : Entity
{
    public string ErrorMessage { get; set; }
    public string StackTree { get; set; }
    public string RequestPath { get; set; }
    public string RequestMethod { get; set; }
    public DateTime TimeStamp { get; set; }

    public ErrorLog(){}
}
