using KarateClub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KarateClub.Domain.Intefaces
{
    public interface ICoachRepository
    {
        Task<IEnumerable<Coach>> GetCoaches(CancellationToken cancellationToken);
    }
}
