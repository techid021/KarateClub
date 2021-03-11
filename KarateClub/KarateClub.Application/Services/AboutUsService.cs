using KarateClub.Application.Interfaces;
using KarateClub.Application.ViewModels;
using KarateClub.Domain.Intefaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace KarateClub.Application.Services
{
    public class AboutUsService : IAboutUsService
    {
        private IAboutUsRepository _aboutUsRepository;
        public AboutUsService(IAboutUsRepository aboutUsRepository)
        {
            this._aboutUsRepository = aboutUsRepository;
        }
        public AboutUsViewModel GetAboutUs()
        {
            return new AboutUsViewModel
            {
                AboutUs = _aboutUsRepository.GetAboutUs()
            };
        }
    }
}
