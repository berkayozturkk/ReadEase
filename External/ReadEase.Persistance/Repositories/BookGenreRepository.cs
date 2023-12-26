using GenericRepository;
using ReadEase.Application.Services.Repositories;
using ReadEase.Domain.Entities;
using ReadEase.Persistance.Context;

namespace ReadEase.Persistance.Repositories;

public class BookGenreRepository : Repository<BookGenre, BaseDbContext>, IBookGenreRepository
{
    public BookGenreRepository(BaseDbContext context) : base(context) { }
}
