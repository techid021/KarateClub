
using KarateClub.Application.Interfaces;
using KarateClub.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KarateClub.Mvc.Controllers
{
    public class NewsController : Controller
    {
        private INewsService _newsService;
        private readonly ILogger<NewsController> _logger;

        public NewsController(INewsService newsService)
        {
            this._newsService = newsService;
        }


        [HttpGet]
        public async Task<IActionResult> Index(int startIndex, CancellationToken cancellationToken)
        {
            NewsViewModel newsModel = null;
            //try
            //{
            //    if (!ModelState.IsValid)
            //    {
            //        newsModel = new NewsViewModel();
            //        return View(newsModel);
            //    }
            //    newsModel = await newsService.GetLastNotificationAndNews(cancellationToken);
            //    foreach (var item in newsModel.Notification)
            //    {
            //        item.Title1 = item.Date?.ToPersianDate();
            //    }

            //    foreach (var item in newsModel.News)
            //    {
            //        item.Title3 = string.Format("data:" + item.Extention + ";base64,{0}", Convert.ToBase64String(item.Image));
            //        item.Title2 = item.Date?.ToPersianDate();
            //    }

            //    foreach (var item in newsModel.NewsForSlider)
            //    {
            //        item.Description = string.Format("data:" + item.Extention + ";base64,{0}", Convert.ToBase64String(item.Image));
            //    }


            //}
            //catch
            //{
            //    newsModel = new NewsViewModel();
            //}

            return View(newsModel);
        }

    }
}
