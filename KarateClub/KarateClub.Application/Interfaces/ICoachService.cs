using KarateClub.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KarateClub.Application.Interfaces
{
    public interface ICoachService
    {
        Task<CoachViewModel> GetCoaches(CancellationToken cancellationToken);
    }
}
