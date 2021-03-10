using KarateClub.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KarateClub.Application.Interfaces
{
    public interface INewsService
    {
        NewsViewModel GetLastNotificationAndNews();

    }
}
