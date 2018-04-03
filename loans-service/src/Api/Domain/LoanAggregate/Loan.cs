using System;
using System.Collections.Generic;
using Gbm.Api.Scopes.Domain.SeedWork;
using LoanService.Api.Domain.LoanAggregate.DomainEvents;

namespace LoanService.Api.Domain.LoanAggregate {

    /// <summary>
    /// Test all logic related with the Loan Aggregate
    /// </summary>
    public class Loan : AggregateRoot<Guid> {

        public Loan(
            Guid loanId,
            Guid userId,
            double amount,
            int numberOfPayments,
            double rate,
            Periodicity periodicity,
            LoanStatus status)
            : base(loanId)
        {
            if (userId == Guid.Empty) 
            {
                throw new InvalidOperationException("UserId should not be an empty GUID");
            }

            this.UserId = userId;
            this.Amount = amount;
            this.NumberOfPayments = numberOfPayments;
            this.InterestRate = rate;
            this.Periodicity = periodicity;
            this.Payments = new List<Payment>();
            this.Status = status;
        }

        private Loan()
            : base(Guid.NewGuid())
        {}

        public Loan(Guid userId, double amount, int numberOfPayments, double rate, Periodicity periodicity)
            : this(Guid.NewGuid(), userId, amount, numberOfPayments, rate, periodicity, LoanStatus.Requested)
        {
            this.CalculatePayments();
            this.AddDomainEvent(new LoanCreated(this.Id));
        }

        /// <summary>
        /// User identifier
        /// </summary>
        public Guid UserId { get; private set;}

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
        /// Loan payments
        /// </summary>
        public List<Payment> Payments { get; private set; }

        /// <summary>
        /// Loan status
        /// </summary>
        public LoanStatus Status { get; private set; }

        /// <summary>
        /// Calculates the loan payments
        /// </summary>
        private void CalculatePayments() {
            var paymentAmount = this.GetPaymentAmount();
            var ratePercent = this.InterestRate / 100;
            var initialBalance = this.Amount;

            for (var i = 1; i <= this.NumberOfPayments; i++) {
                var paymentInterests = Round(initialBalance * ratePercent);
                var amortization = Round(paymentAmount - paymentInterests);
                var finalBalance =  Round(initialBalance - amortization);

                this.Payments.Add(new Payment(
                    i,
                    initialBalance,
                    amortization,
                    paymentInterests,
                    paymentAmount,
                    finalBalance));

                initialBalance = finalBalance;
            }
        }

        /// <summary>
        /// Calculates the montly payment amount
        /// </summary>
        private double GetPaymentAmount() 
        {
            var ratePercent = this.InterestRate / 100;
            var payment = (ratePercent * this.Amount) / (1 - Math.Pow((1 / (1 + ratePercent)), NumberOfPayments));
            return Round(payment);
        }

        /// <summary>
        /// Round a double number into 2 decimal digits
        /// </summary>
        /// <param name="toRound">Number to round</param>
        /// <returns>2 decimal double number</returns>
        private static double Round(double toRound)
        {
            return Math.Round(toRound, 2, MidpointRounding.ToEven);
        }
    }
}