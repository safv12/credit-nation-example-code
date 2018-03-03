namespace LoanService.Api.Domain.SharedKernel
{
    /// <summary>
    /// Represents an Aggregate root in the domain
    /// </summary>
    public class Aggregate<TId> : Entity<TId>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Aggregate"/>
        /// </summary>
        /// <param name="id"></param>
        public Aggregate(TId id)
            : base(id)
        {
        }
    }
}