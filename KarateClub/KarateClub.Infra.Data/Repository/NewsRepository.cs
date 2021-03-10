using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KarateClub.Domain.Intefaces;
using KarateClub.Domain.Models;
using KarateClub.Infra.Data.Context;

namespace KarateClub.Infra.Data.Repository
{
    public class NewsRepository : INewsRepository
    {
        private KarateClubDBContext _ctx;
        public NewsRepository(KarateClubDBContext ctx)
        {
            this._ctx = ctx;
        }

        //گرفتن چهار خبر آخر جهت نمایش در صفحه اول
        public IEnumerable<News> GetFourLastNews()
        {
            return _ctx.News.OrderByDescending(i => i.Date)
                .Where(o => o.Notification == 0 && o.IsActive == 1 && o.ShowInSlider == 0).Take(4);
        }

        //گرفتن چهار خبر آخر جهت نمایش در اسلایدر صفحه اول
        public IEnumerable<News> GetThreeLastNewsForSlider()
        {
            return _ctx.News.OrderByDescending(i => i.Date)
                .Where(o => o.Notification == 0 && o.IsActive == 1 && o.ShowInSlider == 1).Take(4);
        }

        //گرفتن سه اطلاعیه آخر جهت نمایش در صفحه اول
        public IEnumerable<News> GetThreeLastNotification()
        {
            var result = _ctx.News.OrderByDescending(p => p.Date)
                         .Where(o => o.Notification == 1 && o.IsActive == 1).Take(3);
            return (IEnumerable<News>)result;
        }


    }
}
