using EntityFrameworkCorePagination.Nuget.Pagination;
using Microsoft.AspNetCore.Mvc;
using ReadEase.Application.Features.BookFeatures.Command.CreateBook;
using ReadEase.Application.Features.BookFeatures.Queries.GetAllBook;
using ReadEase.Application.Features.BookFeatures.Queries.GetAllBookGenre;
using ReadEase.Domain.Dtos;
using ReadEase.Domain.Entities;

namespace ReadEase.WebApi.Controllers;

public class BookControler : BaseController
{
    [HttpPost("[action]")]
    public async Task<IActionResult> GetAllBookAsync(GetAllBookQuery request,
          CancellationToken cancellationToken)
    {
        PaginationResult<Book> response = await Mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> GetAllBookGenreAsync(GetAllBookGenreQuery request,
      CancellationToken cancellationToken)
    {
        IQueryable<GetAllBookGenreQueryItemDto> response = await Mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateBookAsync(CreateBookCommand request,
      CancellationToken cancellationToken)
    {
        MessageResponse response = await Mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}