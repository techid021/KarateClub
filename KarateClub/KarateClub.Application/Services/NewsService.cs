using KarateClub.Application.Interfaces;
using KarateClub.Application.ViewModels;
using KarateClub.Domain.Intefaces;
using System;
using System.Collections.Generic;
using System.Text;
using Nelibur.ObjectMapper;
using KarateClub.Domain.Models;

namespace KarateClub.Application.Services
{
    public class NewsService : INewsService
    {
        private INewsRepository _newsRepository;
        public NewsService(INewsRepository newsRepository)
        {
            this._newsRepository = newsRepository;
        }

        public NewsViewModel GetThreeLastNotification()
        {
            return new NewsViewModel
            {
                Notification = _newsRepository.GetThreeLastNotification()
            };
            
        }


    }
}
