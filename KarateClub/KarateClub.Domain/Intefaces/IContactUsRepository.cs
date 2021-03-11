using KarateClub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KarateClub.Domain.Intefaces
{
    public interface IContactUsRepository
    {
        void AddContact(ContactUs contactUs);
        void Save();
    }
}
