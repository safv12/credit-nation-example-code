namespace LoanService.Api.Application.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using LoanService.Api.Application.Dtos;
    using LoanService.Api.Application.Mappers;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// This class is responsible to share the status
    /// of the web service
    /// </summary>
    [Route("loans")]
    public class LoanController : ControllerBase
    {
        /// <summary>
        /// Creates a new loan request
        /// </summary>
        /// <returns>A <see cref="Loan"/> class</returns>
        [HttpPost]
        public IActionResult NewLoanRequest([FromBody] NewLoanDto loanDto)
        {
            var loan = loanDto.ToDomain();
            return this.Ok(loan);
        }
    }
}
