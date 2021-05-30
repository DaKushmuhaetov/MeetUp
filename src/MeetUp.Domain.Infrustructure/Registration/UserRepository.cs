using MeetUp.Domain.Registration;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace MeetUp.Domain.Infrustructure.Registration
{
    public sealed class UserRepository : IUserRepository
    {
        private readonly RegistrationDbContext _context;

        public UserRepository(RegistrationDbContext context)
        {
            _context = context;
        }

        public async Task<User> FindByEmail(string email, CancellationToken cancellationToken)
        {
            return await _context.Users.SingleOrDefaultAsync(co => co.Email == email, cancellationToken);
        }

        public async Task<User> FindByLogin(string login, CancellationToken cancellationToken)
        {
            return await _context.Users.SingleOrDefaultAsync(co => co.Login == login, cancellationToken);
        }

        public async Task<User> FindByNumberPhone(string numberPhone, CancellationToken cancellationToken)
        {
            return await _context.Users.SingleOrDefaultAsync(co => co.NumberPhone == numberPhone, cancellationToken);
        }

        public async Task Save(User user)
        {
            if (_context.Entry(user).State == EntityState.Detached)
                _context.Users.Add(user);

            await _context.SaveChangesAsync();
        }
    }
}
