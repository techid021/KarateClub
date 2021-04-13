using KarateClub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace KarateClub.Domain.Intefaces
{
    public interface IContactUsRepository
    {
        void AddContact(ContactUs contactUs, CancellationToken cancellationToken);
        void Save();
    }
}
