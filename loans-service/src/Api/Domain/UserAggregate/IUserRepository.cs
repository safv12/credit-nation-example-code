using System;
using System.Threading.Tasks;

namespace LoanService.Api.Domain.UserAggregate
{
    public interface IUserRepository
    {
        Task<User> SaveUserAsync(User user);

        Task<User> GetUserAsync(Guid userId);
    }
}