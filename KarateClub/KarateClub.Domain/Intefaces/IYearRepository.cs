using KarateClub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KarateClub.Domain.Intefaces
{
    public interface IYearRepository
    {
        IEnumerable<Year> GetYears();
    }
}
