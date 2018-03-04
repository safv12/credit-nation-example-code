using LoanService.Api.Application.Dtos;
using LoanService.Api.Domain.LoanAggregate;

namespace LoanService.Api.Application.Mappers
{
    public static class LoanMapper
    {
        public static Loan ToDomain(this NewLoanDto from)
        {
            return new Loan(
                from.UserId,
                from.Amount,
                from.NumberOfPayments,
                from.Rate,
                from.Periodicity);
        }

        public static LoanDto ToDto(this Loan from)
        {
            return new LoanDto 
            {
                UserId = from.UserId,
                Status = from.Status,
                Payments = from.Payments,
                Amount = from.Amount,
                NumberOfPayments = from.NumberOfPayments,
                InterestRate = from.InterestRate,
                Periodicity = from.Periodicity
            };
        }
    }
}