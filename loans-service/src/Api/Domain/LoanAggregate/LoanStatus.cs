namespace LoanService.Api.Domain.LoanAggregate {
    public enum LoanStatus {
        Requested = 1,
        Rejected = 2,
        Approved = 3,
        Active = 4,
        Finished = 5,
    }
}