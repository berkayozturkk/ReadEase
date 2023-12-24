using ReadEase.Application.Services.Repositories;
using ReadEase.Domain.Entities;
using ReadEase.Persistance.Context;

namespace ReadEase.Persistance.Repositories;

internal class BookRepository : BaseRepository<Book, BaseDbContext>, IBookRepository
{
    public BookRepository(BaseDbContext context) : base(context) {}
}
