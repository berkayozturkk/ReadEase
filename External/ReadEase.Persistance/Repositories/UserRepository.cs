using GenericRepository;
using ReadEase.Application.Services.Repositories;
using ReadEase.Domain.Entities;
using ReadEase.Persistance.Context;

namespace ReadEase.Persistance.Repositories;

public class UserRepository : Repository<User, BaseDbContext>, IUserRepository
{
    public UserRepository(BaseDbContext context) : base(context) {}
}

