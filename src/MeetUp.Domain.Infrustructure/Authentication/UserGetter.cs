using MeetUp.Domain.Authentication;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MeetUp.Domain.Infrustructure.Authentication
{
    public sealed class UserGetter : IUserGetter
    {
        private readonly AuthenticationDbContext _context;

        public UserGetter(AuthenticationDbContext context)
        {
            _context = context;
        }

        public async Task<User> FindByEmail(string email, CancellationToken cancellationToken)
        {
            return await _context.Users.SingleOrDefaultAsync(o => o.Email == email, cancellationToken);
        }

        public async Task<User> Get(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Users.SingleOrDefaultAsync(o => o.Id == id, cancellationToken);
        }

        public async Task<User> FindByLogin(string login, CancellationToken cancellationToken)
        {
            return await _context.Users.SingleOrDefaultAsync(o => o.Login == login, cancellationToken);
        }

        public async Task<User> FindByNumberPhone(string numberPhone, CancellationToken cancellationToken)
        {
            return await _context.Users.SingleOrDefaultAsync(o => o.Login == numberPhone, cancellationToken);
        }

    }
}
