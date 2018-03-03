using LoanService.Api.Application.Dtos;
using LoanService.Api.Domain.LoanAggregate;

namespace LoanService.Api.Application.Mappers
{
    public static class LoanMapper
    {
        public static Loan ToDomain(this LoanDto from)
        {
            return new Loan(from.Amount, from.NumberOfPayments, from.Rate, from.Periodicity);
        }
    }
}