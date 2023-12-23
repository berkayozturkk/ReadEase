using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ReadEase.Domain.Entities;
using System.Reflection;

namespace ReadEase.Persistance.Context;

public class BaseDbContext : DbContext
{
    public IConfiguration Configuration { get; set; }

    public DbSet<Book> Books { get; set; }
    public DbSet<Loan> Loans { get; set; }
    public DbSet<BookGenre> BookGenres { get; set; }

    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
    {
        Configuration = configuration;
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
