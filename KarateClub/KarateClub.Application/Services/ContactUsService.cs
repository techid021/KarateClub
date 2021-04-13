using KarateClub.Application.Interfaces;
using KarateClub.Domain.Intefaces;
using KarateClub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KarateClub.Application.Services
{
    public class ContactUsService : IContactUsService
    {
        private IContactUsRepository _contactUsRepository;
        public ContactUsService(IContactUsRepository contactUsRepository)
        {
            this._contactUsRepository = contactUsRepository;
        }

        public async Task<long> RegisterContact(ContactUs contactUs, CancellationToken cancellationToken)
        {
            _contactUsRepository.AddContact(contactUs, cancellationToken);
            _contactUsRepository.Save();
            return contactUs.Id;
        }
    }
}
