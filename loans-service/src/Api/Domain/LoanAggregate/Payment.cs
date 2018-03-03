using LoanService.Api.Domain.SharedKernel;

namespace LoanService.Api.Domain.LoanAggregate {
    public class Payment : ValueObject {
        public Payment(
            int paymentNumber,
            double balance,
            double amortization,
            double interests,
            double requiredPayment,
            double finalBalance) 
        {
            this.PaymentNumber = paymentNumber;
            this.Amoritization = amortization;
            this.Balance = balance;
            this.Interests = interests;
            this.RequiredPayment = requiredPayment;
            this.FinalBalance = finalBalance;
        }

        public int PaymentNumber { get; private set;}

        public double Balance { get; private set;}

        public double Amoritization { get; private set;}

        public double Interests { get; private set;}

        public double RequiredPayment { get; private set;}

        public double FinalBalance { get; private set;}
    }
}