﻿using KarateClub.Application.Interfaces;
using KarateClub.Application.ViewModels;
using KarateClub.Mvc.Models;
using KarateClub.Mvc.Models.ExtentionMethods;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KarateClub.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private INewsService newsService;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, INewsService newsService)
        {
            _logger = logger;
            this.newsService = newsService;
        }

        #region Get Last Notification And News For Home Page 
        [HttpGet]
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            NewsViewModel newsModel;
            try
            {
                if (!ModelState.IsValid)
                {
                    newsModel = new NewsViewModel();
                    return View(newsModel);
                }
                newsModel = await newsService.GetLastNotificationAndNews(cancellationToken);
                foreach (var item in newsModel.Notification)
                {
                    item.Title1 = item.Date?.ToPersianDate();
                }

                foreach (var item in newsModel.News)
                {
                    item.Title3 = string.Format("data:" + item.Extention + ";base64,{0}", Convert.ToBase64String(item.Image));
                    item.Title2 = item.Date?.ToPersianDate();
                }

                foreach (var item in newsModel.NewsForSlider)
                {
                    item.Description = string.Format("data:" + item.Extention + ";base64,{0}", Convert.ToBase64String(item.Image));
                }


            }
            catch
            {
                newsModel = new NewsViewModel();
            }

            return View(newsModel);
        }
        #endregion

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
