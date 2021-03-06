using KarateClub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KarateClub.Application.ViewModels
{
    public class NewsViewModel
    {
        public IEnumerable<News> Notification { get; set; }
    }
}
