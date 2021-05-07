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
        Task<NewsViewModel> GetNewsByPagingAsync(int startIndex, int pageSize, CancellationToken cancellationToken);
        Task<NewsViewModel> GetNotificationsByPagingAsync(int startIndex, int pageSize, CancellationToken cancellationToken);

    }
}
