using GenericRepository;
using ReadEase.Application.Services.Repositories;
using ReadEase.Domain.Entities;
using ReadEase.Persistance.Context;

namespace ReadEase.Persistance.Repositories;

public class LoanRepository : Repository<Loan, BaseDbContext>, ILoanRepository
{
    public LoanRepository(BaseDbContext context) : base(context) { }
}
