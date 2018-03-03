using System;
using System.Collections.Generic;
using LoanService.Api.Domain.SharedKernel;

namespace LoanService.Api.Domain.LoanAggregate {

    /// <summary>
    /// Test all logic related with the Loan Aggregate
    /// </summary>
    public class Loan : Aggregate<Guid> {
        public Loan(
            double amount,
            int numberOfPayments,
            double rate,
            Periodicity periodicity)
            : base(Guid.NewGuid())
        {
            this.Amount = amount;
            this.NumberOfPayments = numberOfPayments;
            this.InterestRate = rate;
            this.Periodicity = periodicity;
            this.Payments = new List<Payment>();
            this.CalculatePayments();
        }

        /// <summary>
        /// Amount lended to the client
        /// </summary>
        public double Amount { get; private set; }

        /// <summary>
        /// Number of payments of the loan
        /// </summary>
        public int NumberOfPayments { get; private set; }

        /// <summary>
        /// Interest Rate of the loan
        /// </summary>
        public double InterestRate { get; private set; }

        /// <summary>
        /// Payment periodicity
        /// </summary>
        public Periodicity Periodicity { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Payment> Payments { get; private set; }

        /// <summary>
        /// Calculates the loan payments
        /// </summary>
        private void CalculatePayments() {
            var paymentAmount = this.GetPaymentAmount();
            var ratePercent = this.InterestRate / 100;
            var paymentBalance = this.Amount;

            for (var i = 1; i <= this.NumberOfPayments; i++) {
                var paymentInterests = Round(paymentBalance * ratePercent);
                var amortization = Round(paymentAmount - paymentInterests);
                var finalBalance =  Round(paymentBalance - amortization);

                this.Payments.Add(new Payment(
                    i,
                    paymentBalance,
                    amortization,
                    paymentInterests,
                    paymentAmount,
                    finalBalance));

                paymentBalance = finalBalance;
            }
        }

        private double GetPaymentAmount() 
        {
            var ratePercent = this.InterestRate / 100;
            var payment = (ratePercent * this.Amount) / (1 - Math.Pow((1 / (1 + ratePercent)), NumberOfPayments));
            return Round(payment);
        }

        private static double Round(double toRound)
        {
            return Math.Round(toRound, 2, MidpointRounding.ToEven);
        }
    }
}