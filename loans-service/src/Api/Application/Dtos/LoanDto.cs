using System;
using System.Collections.Generic;
using LoanService.Api.Domain.LoanAggregate;

namespace LoanService.Api.Application.Dtos
{
    public class LoanDto
    {
        public Guid UserId { get; set;}
        public Guid LoanId { get; set;}
        public double Amount { get; set; }
        public int NumberOfPayments { get; set; }
        public double InterestRate { get; set; }
        public Periodicity Periodicity { get; set; }
        public IReadOnlyList<Payment> Payments { get; set; }
        public LoanStatus Status { get; set; }
    }
}