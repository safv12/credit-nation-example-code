using LoanService.Api.Domain.LoanAggregate;
using Microsoft.EntityFrameworkCore;

namespace LoanService.Api.Infrastructure.Repositories
{
    public class LoanServiceContext : DbContext
    {
        public LoanServiceContext(DbContextOptions<LoanServiceContext> options)
            : base(options)
        { }

        public LoanServiceContext()
        { }

        public DbSet<Loan> Loan { get; set; }
        public DbSet<Payment> Payment { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Should be provided by environment variable
            optionsBuilder.UseSqlite("Data Source=loanServiceDB.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Loan>().HasKey(l => l.Id);
            modelBuilder.Entity<Payment>().HasKey(p => p.Id);
        }
    }
}