using System;
using System.Linq;
using System.Threading.Tasks;
using LoanService.Api.Domain.UserAggregate;
using Microsoft.EntityFrameworkCore;

namespace LoanService.Api.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public async Task<User> GetUserAsync(Guid userId)
        {
            using (var db = new LoanServiceContext())
            {
                var user = await db.User
                    .SingleOrDefaultAsync(u => u.Id == userId).ConfigureAwait(false);
                return user;
            }
        }

        public async Task<User> SaveUserAsync(User user)
        {
            using (var db = new LoanServiceContext())
            {
                db.User.Add(user);
                await db.SaveChangesAsync().ConfigureAwait(false);
            }
            return user;
        }
    }
}