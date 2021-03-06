﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using KarateClub.Domain.Intefaces;
using KarateClub.Domain.Models;
using KarateClub.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace KarateClub.Infra.Data.Repository
{
    public class NewsRepository : INewsRepository
    {
        private KarateClubDBContext _ctx;
        public NewsRepository(KarateClubDBContext ctx)
        {
            this._ctx = ctx;
        }

        public async Task<int> GetNewsCount(CancellationToken cancellationToken)
        {
            return await _ctx.News.Where(o => o.Notification == 0 && o.IsActive == 1 && o.ShowInSlider == 0)
                  .CountAsync(cancellationToken);
        }

        //گرفتن چهار خبر آخر جهت نمایش در صفحه اول
        public async Task<IEnumerable<News>> GetFourLastNews(CancellationToken cancellationToken)
        {
            return await _ctx.News.OrderByDescending(i => i.Date)
                .Where(o => o.Notification == 0 && o.IsActive == 1 && o.ShowInSlider == 0)
                .Take(4).ToListAsync(cancellationToken);
        }

        //خواندن اخبار در صفحه اخبار - صفحه بندی هم دارد
        public async Task<IEnumerable<News>> GetNewsByPaging(int startIndex, CancellationToken cancellationToken)
        {
            return await _ctx.News.OrderByDescending(i => i.Date)
                .Where(o => o.Notification == 0 && o.IsActive == 1 && o.ShowInSlider == 0)
                .Skip((startIndex - 1) * 20).Take(20).ToListAsync(cancellationToken);

        }

        //خواندن اطلاعیه ها در صفحه اطلاعیه ها - صفحه بندی هم دارد
        public async Task<IEnumerable<News>> GetNotificationByPaging(int startIndex, CancellationToken cancellationToken)
        {
            return await _ctx.News.OrderByDescending(i => i.Date)
                .Where(o => o.Notification == 1 && o.IsActive == 1)
                .Skip((startIndex - 1) * 20).Take(20).ToListAsync(cancellationToken);
        }

        //گرفتن سه خبر آخر جهت نمایش در اسلایدر صفحه اول
        public async Task<IEnumerable<News>> GetThreeLastNewsForSlider(CancellationToken cancellationToken)
        {
            return await _ctx.News.OrderByDescending(i => i.Date)
                .Where(o => o.Notification == 0 && o.IsActive == 1 && o.ShowInSlider == 1)
                .Take(3).ToListAsync(cancellationToken);
        }

        //گرفتن سه اطلاعیه آخر جهت نمایش در صفحه اول
        public async Task<IEnumerable<News>> GetThreeLastNotification(CancellationToken cancellationToken)
        {
            var result = _ctx.News.OrderByDescending(p => p.Date)
                         .Where(o => o.Notification == 1 && o.IsActive == 1).Take(3).ToListAsync(cancellationToken);
            return await result;
        }

        public async Task<int> GetNotificationsCount(CancellationToken cancellationToken)
        {
            return await _ctx.News.Where(o => o.Notification == 1 && o.IsActive == 1)
                  .CountAsync(cancellationToken);
        }
    }
}
