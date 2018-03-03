namespace LoanService.Api.Application.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// This class is responsible to share the status
    /// of the web service
    /// </summary>
    [Route("health_check")]
    public class HealthCheckController : Controller
    {
        /// <summary>
        /// Health check method returns a success confirmation
        /// </summary>
        /// <returns>success connection confirmation</returns>
        [HttpGet]
        public IActionResult ServiceHealth()
        {
            return this.Ok(new { Success = true });
        }
    }
}
