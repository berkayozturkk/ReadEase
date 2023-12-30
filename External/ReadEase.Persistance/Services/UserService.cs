using Microsoft.EntityFrameworkCore;
using ReadEase.Application.Features.UserFeatures.Command.UserLogin;
using ReadEase.Application.Services;
using ReadEase.Application.Services.Repositories;
using ReadEase.Domain.Entities;
using ReadEase.Presentation.Shared;

namespace ReadEase.Persistance.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task UserLoginAsync(UserLoginCommand request, CancellationToken cancellationToken)
    {
        var user = _userRepository.GetWhere(x => x.Username == request.UserName).First(); // Yoksa InvalidEx

        //if (user == null)
        //    throw new ArgumentNullException("User not found");

        //string hashedPassword = EncryptionHelper.Encrypt(request.Password);

        string checkPassword = EncryptionHelper.Decrypt(user.Password);

        if(request.Password != checkPassword)
            throw new ArgumentNullException("Password not found");
    }
}