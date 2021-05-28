using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MeetUp.Domain.Registration
{
    public interface IUserRepository
    {
        Task<User> FindByEmail(string email, CancellationToken cancellationToken);
        Task<User> FindByLogin(string email, CancellationToken cancellationToken);
        Task<User> FindByNumberPhone(string email, CancellationToken cancellationToken);
        Task Save(User user);
    }
}
