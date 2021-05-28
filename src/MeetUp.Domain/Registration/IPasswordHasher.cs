using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetUp.Domain.Registration
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
    }
}
