using KarateClub.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KarateClub.Application.Interfaces
{
    public interface INewsService
    {
        Task<NewsViewModel> GetLastNotificationAndNews(CancellationToken cancellationToken);
        Task<NewsViewModel> GetNewsByPagingAsync(int startIndex, CancellationToken cancellationToken);
        Task<NewsViewModel> GetNotificationsByPagingAsync(int startIndex, CancellationToken cancellationToken);
        Task<int> GetNewsCount(CancellationToken cancellationToken);
        Task<int> GetNotificationsCount(CancellationToken cancellationToken);
    }
}
