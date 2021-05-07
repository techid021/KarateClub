using KarateClub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KarateClub.Domain.Intefaces
{
    public interface INewsRepository
    {
        Task<IEnumerable<News>> GetThreeLastNotification(CancellationToken cancellationToken);

        Task<IEnumerable<News>> GetFourLastNews(CancellationToken cancellationToken);

        Task<IEnumerable<News>> GetThreeLastNewsForSlider(CancellationToken cancellationToken);

        Task<IEnumerable<News>> GetNewsByPaging(int startIndex, CancellationToken cancellationToken);

        Task<IEnumerable<News>> GetNotificationByPaging(int startIndex, CancellationToken cancellationToken);

        Task<int> GetNewsCount(CancellationToken cancellationToken);
        Task<int> GetNotificationsCount(CancellationToken cancellationToken);

    }
}
