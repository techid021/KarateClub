using KarateClub.Application.Interfaces;
using KarateClub.Application.ViewModels;
using KarateClub.Domain.Intefaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace KarateClub.Application.Services
{
    public class CoachService : ICoachService
    {
        private ICoachRepository _coachRepository;
        public CoachService(ICoachRepository coachRepository)
        {
            this._coachRepository = coachRepository;
        }

        public CoachViewModel GetCoaches()
        {
            return new CoachViewModel
            {
                Coaches = _coachRepository.GetCoaches()
            };

        }


    }
}
