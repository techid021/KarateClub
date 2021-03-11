using KarateClub.Application.Interfaces;
using KarateClub.Domain.Intefaces;
using KarateClub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KarateClub.Application.Services
{
    public class ContactUsService : IContactUsService
    {
        private IContactUsRepository _contactUsRepository;
        public ContactUsService(IContactUsRepository contactUsRepository)
        {
            this._contactUsRepository = contactUsRepository;
        }

        public long RegisterContact(ContactUs contactUs)
        {
            _contactUsRepository.AddContact(contactUs);
            _contactUsRepository.Save();
            return contactUs.Id;
        }
    }
}
