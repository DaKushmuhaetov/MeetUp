using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MeetUp.Domain.Positions
{
    public interface IPositionRepository
    {
        Task Save(Position position, CancellationToken cancellationToken);
    }
}
