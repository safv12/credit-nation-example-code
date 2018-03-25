using System;
using System.Threading.Tasks;
using LoanService.Api.Domain.UserAggregate;
using Microsoft.AspNetCore.Mvc;

namespace LoanService.Api.Application.Controllers
{
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepo;

        public UserController(IUserRepository repo)
        {
            this.userRepo = repo;
        }

        [HttpGet("userId")]
        public async Task<IActionResult> GetUserRequest(Guid userId)
        {
            var user = await this.userRepo.GetUserAsync(userId).ConfigureAwait(false);

            if (user == null)
            {
                return this.NotFound();
            }

            return this.Ok(user);
        }

    }
}