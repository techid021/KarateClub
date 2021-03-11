using KarateClub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KarateClub.Application.Interfaces
{
    public interface IContactUsService
    {
        long RegisterContact(ContactUs contactUs);
    }
}
