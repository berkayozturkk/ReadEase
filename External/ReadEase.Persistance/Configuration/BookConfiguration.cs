using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReadEase.Domain.Entities;

namespace ReadEase.Persistance.Configuration;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Books");
        builder.HasKey(p => p.Id);

        //builder.HasMany(b => b.Loans)          // Book, Loans koleksiyonuna sahiptir
        //       .WithOne(l => l.Book)           // Loan, bir Book'a aittir
        //       .HasForeignKey(l => l.BookId);
    }
}
