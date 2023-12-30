using ReadEase.Application.Features.UserFeatures.Command.UserLogin;

namespace ReadEase.Application.Services;

public interface IUserService
{
    Task UserLoginAsync(UserLoginCommand request, CancellationToken cancellationToken);
}
