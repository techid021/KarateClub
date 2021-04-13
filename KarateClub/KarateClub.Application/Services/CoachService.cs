using KarateClub.Application.Interfaces;
using KarateClub.Application.ViewModels;
using KarateClub.Domain.Intefaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KarateClub.Application.Services
{
    public class CoachService : ICoachService
    {
        private ICoachRepository _coachRepository;
        public CoachService(ICoachRepository coachRepository)
        {
            this._coachRepository = coachRepository;
        }

        public async Task<CoachViewModel> GetCoaches(CancellationToken cancellationToken)
        {
            return new CoachViewModel
            {
                Coaches = await _coachRepository.GetCoaches(cancellationToken)
            };

        }


    }
}
