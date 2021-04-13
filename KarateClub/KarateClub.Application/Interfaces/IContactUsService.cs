using KarateClub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KarateClub.Application.Interfaces
{
    public interface IContactUsService
    {
        Task<long> RegisterContact(ContactUs contactUs, CancellationToken cancellationToken);
    }
}
