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
    public class AboutUsService : IAboutUsService
    {
        private IAboutUsRepository _aboutUsRepository;
        public AboutUsService(IAboutUsRepository aboutUsRepository)
        {
            this._aboutUsRepository = aboutUsRepository;
        }
        public async Task<AboutUsViewModel> GetAboutUs(CancellationToken cancellationToken)
        {
            return new AboutUsViewModel
            {
                AboutUs = await _aboutUsRepository.GetAboutUs(cancellationToken)
            };
        }
    }
}
