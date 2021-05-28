using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MeetUp.Domain.Authentication
{
    public interface IUserGetter
    {
        Task<User> Get(Guid id, CancellationToken cancellationToken);
        Task<User> FindByEmail(string email, CancellationToken cancellationToken);
        Task<User> FindByLogin(string login, CancellationToken cancellationToken);
        Task<User> FindByNumberPhone(string numberPhone, CancellationToken cancellationToken);
    }
}
