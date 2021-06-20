using MeetUp.Domain.Positions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MeetUp.Domain.Infrustructure.Positions
{
    public class PositionRepository : IPositionRepository
    {
        private readonly PositionDbContext _context;

        public PositionRepository(PositionDbContext context)
        {
            _context = context;
        }

        public async Task Save(Position position, CancellationToken cancellationToken)
        {
            if (_context.Entry(position).State == EntityState.Detached)
                _context.Positions.Add(position);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
