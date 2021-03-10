using KarateClub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KarateClub.Domain.Intefaces
{
    public interface INewsRepository
    {
        IEnumerable<News> GetThreeLastNotification();

        IEnumerable<News> GetFourLastNews();


    }
}
