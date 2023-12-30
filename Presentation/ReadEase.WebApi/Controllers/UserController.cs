using Microsoft.AspNetCore.Mvc;
using ReadEase.Application.Features.UserFeatures.Command.UserLogin;
using ReadEase.Domain.Dtos;

namespace ReadEase.WebApi.Controllers
{
    public class UserController : BaseController
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> UserLoginAsync(UserLoginCommand request,
          CancellationToken cancellationToken)
        {
            MessageResponse response = await Mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
