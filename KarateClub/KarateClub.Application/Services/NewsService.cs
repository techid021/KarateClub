using KarateClub.Application.Interfaces;
using KarateClub.Application.ViewModels;
using KarateClub.Domain.Intefaces;
using System;
using System.Collections.Generic;
using System.Text;
using Nelibur.ObjectMapper;
using KarateClub.Domain.Models;
using System.Threading.Tasks;
using System.Threading;

namespace KarateClub.Application.Services
{
    public class NewsService : INewsService
    {
        private INewsRepository _newsRepository;
        public NewsService(INewsRepository newsRepository)
        {
            this._newsRepository = newsRepository;
        }

        public async Task<NewsViewModel> GetLastNotificationAndNews(CancellationToken cancellationToken)
        {
            return new NewsViewModel
            {
                Notification = await _newsRepository.GetThreeLastNotification(cancellationToken),
                News = await _newsRepository.GetFourLastNews(cancellationToken),
                NewsForSlider = await _newsRepository.GetThreeLastNewsForSlider(cancellationToken)
            };

        }

        public async Task<NewsViewModel> GetNewsByPagingAsync(int startIndex, CancellationToken cancellationToken)
        {
            return new NewsViewModel
            {
                News = await _newsRepository.GetNewsByPaging(startIndex, cancellationToken)
            };
        }

        public async Task<int> GetNewsCount(CancellationToken cancellationToken)
        {
            return await _newsRepository.GetNewsCount(cancellationToken);
        }

        public async Task<NewsViewModel> GetNotificationsByPagingAsync(int startIndex, CancellationToken cancellationToken)
        {
            return new NewsViewModel
            {
                Notification = await _newsRepository.GetNotificationByPaging(startIndex, cancellationToken)
            };
        }

        public async Task<int> GetNotificationsCount(CancellationToken cancellationToken)
        {
            return await _newsRepository.GetNotificationsCount(cancellationToken);
        }
    }
}
