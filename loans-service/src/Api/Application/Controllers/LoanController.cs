namespace LoanService.Api.Application.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using LoanService.Api.Application.Dtos;
    using LoanService.Api.Application.Mappers;
    using LoanService.Api.Domain.LoanAggregate;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// This class is responsible to share the status
    /// of the web service
    /// </summary>
    [Route("loans")]
    public class LoanController : ControllerBase
    {
        private readonly ILoanRepository loanRepo;

        public LoanController(ILoanRepository repo)
        {
            this.loanRepo = repo;
        }

        /// <summary>
        /// Creates a new loan request
        /// </summary>
        /// <returns>A <see cref="Loan"/> class</returns>
        [HttpPost]
        public async Task<IActionResult> NewLoanRequest([FromBody] NewLoanDto loanDto)
        {
            var loan = loanDto.ToDomain();
            await this.loanRepo.SaveLoanAsync(loan).ConfigureAwait(false);
            return this.Ok(loan);
        }

        [HttpGet("{loanId}")]
        public async Task<IActionResult> GetLoanRequest(Guid loanId)
        {
            var loan = await this.loanRepo.GetLoanAsync(loanId).ConfigureAwait(false);
            
            if (loan == null) {
                return this.NotFound();
            }

            return this.Ok(loan);
        }
    }
}
