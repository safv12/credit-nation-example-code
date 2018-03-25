using System;
using LoanService.Api.Domain.SharedKernel;

namespace LoanService.Api.Domain.UserAggregate
{
    public class User : Aggregate<Guid>
    {
        public User(Guid userId, bool hasLoanInProgress, Guid? loanInProgressId)
            : base(userId)
        {
            this.HasLoanInProgress = hasLoanInProgress;
            this.LoanInProgressId = loanInProgressId;
        }

        public User(Guid userId)
            : this(userId, false, null)
        {
        }

        private User()
            : base(Guid.NewGuid())
        {
        }

        public bool HasLoanInProgress { get; private set; }

        public Guid? LoanInProgressId { get; private set; }

        public bool CanRequestLoan()
        {
            return !this.HasLoanInProgress;
        }

        public void RegisterNewLoan(Guid loanId)
        {
            this.HasLoanInProgress = true;
            this.LoanInProgressId = loanId;
        }
    }
}