using Microsoft.AspNetCore.Mvc;
using ReadEase.Application.Features.LoanFeatures.Command.BorrowBook;
using ReadEase.Domain.Dtos;

namespace ReadEase.WebApi.Controllers
{
    public class LoanController : BaseController
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> BorrowBookAsync(BorrowBookCommand request,
          CancellationToken cancellationToken)
        {
            MessageResponse response = await Mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
