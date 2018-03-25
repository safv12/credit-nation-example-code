namespace LoanService.Api.Application.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using LoanService.Api.Application.Dtos;
    using LoanService.Api.Application.Mappers;
    using LoanService.Api.Domain.LoanAggregate;
    using LoanService.Api.Domain.UserAggregate;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// This class is responsible to share the status
    /// of the web service
    /// </summary>
    [Route("users/{userId}/loans")]
    public class LoanController : ControllerBase
    {
        private readonly ILoanRepository loanRepo;
        private readonly IUserRepository userRepo;

        public LoanController(ILoanRepository repo, IUserRepository userRepo)
        {
            this.loanRepo = repo;
            this.userRepo = userRepo;
        }

        /// <summary>
        /// Creates a new loan request
        /// </summary>
        /// <returns>A <see cref="Loan"/> class</returns>
        [HttpPost]
        public async Task<IActionResult> NewLoanRequest(Guid userId, [FromBody] NewLoanDto loanDto)
        {
            var user = await this.userRepo.GetUserAsync(userId).ConfigureAwait(false);

            if (user == null) 
            {
                return this.NotFound(
                    new ErrorDto("UserNotFound", "The user id was not found.")
                );
            }

            if (!user.CanRequestLoan())
            {
                return this.BadRequest(
                    new ErrorDto("CantRequestLoan", "The user can not requests a new loan."));
            }

            var loan = loanDto.ToDomain();
            await this.loanRepo.SaveLoanAsync(loan).ConfigureAwait(false);
            user.RegisterNewLoan(loan.Id);

            return this.Ok(loan.ToDto());
        }

        [HttpGet("{loanId}")]
        public async Task<IActionResult> GetLoanRequest(Guid loanId)
        {
            var loan = await this.loanRepo.GetLoanAsync(loanId).ConfigureAwait(false);
            
            if (loan == null) {
                return this.NotFound();
            }

            return this.Ok(loan.ToDto());
        }
    }
}
