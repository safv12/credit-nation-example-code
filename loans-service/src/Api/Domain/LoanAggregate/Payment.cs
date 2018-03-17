using System;
using LoanService.Api.Domain.SharedKernel;

namespace LoanService.Api.Domain.LoanAggregate {
    public class Payment : Entity<Guid> {
        public Payment(
            int paymentNumber,
            double balance,
            double amortization,
            double interests,
            double requiredPayment,
            double finalBalance)
            : base(Guid.NewGuid())
        {
            this.PaymentNumber = paymentNumber;
            this.Amoritization = amortization;
            this.Balance = balance;
            this.Interests = interests;
            this.RequiredPayment = requiredPayment;
            this.FinalBalance = finalBalance;
        }

        private Payment()
            : base(Guid.NewGuid())
        {}

        public int PaymentNumber { get; private set;}

        public double Balance { get; private set;}

        public double Amoritization { get; private set;}

        public double Interests { get; private set;}

        public double RequiredPayment { get; private set;}

        public double FinalBalance { get; private set;}
    }
}