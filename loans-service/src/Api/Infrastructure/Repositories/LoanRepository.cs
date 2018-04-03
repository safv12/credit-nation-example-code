using System;
using System.Linq;
using System.Threading.Tasks;
using LoanService.Api.Domain.LoanAggregate;
using Microsoft.EntityFrameworkCore;

namespace LoanService.Api.Infrastructure.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        public async Task<Loan> GetLoanAsync(Guid loanId)
        {
            using (var db = new LoanServiceContext())
            {
                var loan = await db.Loan
                    .Include(l => l.Payments)
                    .SingleAsync(l => l.Id == loanId).ConfigureAwait(false);
                return loan;
            }
        }

        public async Task<Loan> SaveLoanAsync(Loan loan)
        {
            using (var db = new LoanServiceContext())
            {
                db.Loan.Add(loan);
                await db.SaveChangesAsync().ConfigureAwait(false);
            }
            loan.Dispatch();
            return loan;
        }
    }
}