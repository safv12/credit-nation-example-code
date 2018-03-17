using System;
using System.Threading.Tasks;

namespace LoanService.Api.Domain.LoanAggregate
{
    public interface ILoanRepository
    {
        Task<Loan> SaveLoanAsync(Loan loan);

        Task<Loan> GetLoanAsync(Guid loanId);
    }
}