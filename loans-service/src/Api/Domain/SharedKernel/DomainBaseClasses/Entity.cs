namespace LoanService.Api.Domain.SharedKernel
{
    using System;

    /// <summary>
    /// Represents an entitiy in the domain
    /// </summary>
    public class Entity<TId>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Entitiy"/>
        /// </summary>
        /// <param name="id"></param>
        public Entity(TId id)
        {
            if (id.Equals(default(TId)))
                throw new InvalidOperationException("The Id should no be a default value.");

            this.Id = id;
        }

        public TId Id { get; private set; }
    }
}