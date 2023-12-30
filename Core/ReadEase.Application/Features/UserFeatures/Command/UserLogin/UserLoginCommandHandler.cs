using MediatR;
using ReadEase.Application.Services;
using ReadEase.Domain.Dtos;

namespace ReadEase.Application.Features.UserFeatures.Command.UserLogin;

public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, MessageResponse>
{
    private readonly IUserService _userService;

    public UserLoginCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<MessageResponse> Handle(UserLoginCommand request, CancellationToken cancellationToken)
    {
        await _userService.UserLoginAsync(request, cancellationToken);
        return new MessageResponse("Login", true, null);
    }
}
