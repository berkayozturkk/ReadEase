using GenericRepository;
using ReadEase.Application.Services.Repositories;
using ReadEase.Domain.Entities;
using ReadEase.Persistance.Context;

namespace ReadEase.Persistance.Repositories;

public class BookRepository : Repository<Book, BaseDbContext>, IBookRepository
{
    public BookRepository(BaseDbContext context) : base(context) {}
}
