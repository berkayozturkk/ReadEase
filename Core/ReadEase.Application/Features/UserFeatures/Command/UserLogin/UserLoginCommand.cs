using MediatR;
using ReadEase.Application.Features.BookFeatures.Command.CreateBook;
using ReadEase.Domain.Dtos;

namespace ReadEase.Application.Features.UserFeatures.Command.UserLogin;

public class UserLoginCommand : IRequest<MessageResponse>
{
    public string UserName { get; set; }
    public string Password { get; set; }

    public UserLoginCommand(){}
    public UserLoginCommand(string userName, string password)
    {
        UserName = userName;
        Password = password;
    }
}
