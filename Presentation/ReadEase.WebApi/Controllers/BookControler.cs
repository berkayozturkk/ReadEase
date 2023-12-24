using EntityFrameworkCorePagination.Nuget.Pagination;
using Microsoft.AspNetCore.Mvc;
using ReadEase.Application.Features.BookFeatures.Queries.GetAllBook;
using ReadEase.Domain.Entities;

namespace ReadEase.WebApi.Controllers;

public class BookControler : BaseController
{
    [HttpPost]
    public async Task<IActionResult> GetAllBookAsync(GetAllBookQuery request,
          CancellationToken cancellationToken)
    {
        PaginationResult<Book> response = await Mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}