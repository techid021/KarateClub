using KarateClub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KarateClub.Application.ViewModels
{
    public class CoachViewModel
    {
        public IEnumerable<Coach> Coaches { get; set; }
    }
}
