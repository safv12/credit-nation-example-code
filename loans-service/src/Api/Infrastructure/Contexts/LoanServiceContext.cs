using System;
using LoanService.Api.Domain.LoanAggregate;
using LoanService.Api.Domain.UserAggregate;
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
        
        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Should be provided by environment variable
            var db = Environment.GetEnvironmentVariable("SQLITE_PATH") ?? "loanServiceDB.db";
            optionsBuilder.UseSqlite("Data Source=" + db);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Loan>().HasKey(l => l.Id);
            modelBuilder.Entity<Payment>().HasKey(p => p.Id);


            modelBuilder.Entity<User>().HasKey(u => u.Id);
        }
    }
}