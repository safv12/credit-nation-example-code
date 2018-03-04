using System;
using LoanService.Api.Domain.LoanAggregate;

namespace LoanService.Api.Application.Dtos
{
    public class NewLoanDto
    {
        public Guid UserId { get; set; }

        public double Amount { get; set; }

        public int NumberOfPayments { get; set; }

        public double Rate { get; set; }

        public Periodicity Periodicity { get; set; }
    }
}