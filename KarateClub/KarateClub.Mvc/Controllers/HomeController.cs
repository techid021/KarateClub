using KarateClub.Application.Interfaces;
using KarateClub.Application.ViewModels;
using KarateClub.Mvc.Models;
using KarateClub.Mvc.Models.ExtentionMethods;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace KarateClub.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private IYearService yearService;//test}
        private INewsService newsService;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, INewsService newsService, IYearService yearService)
        {
            _logger = logger;
            this.yearService = yearService;//test
            this.newsService = newsService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            NewsViewModel newsModel;
            try
            {
                //YearViewModel model = yearService.GetYears();//test
                newsModel = newsService.GetLastNotificationAndNews();
                foreach (var item in newsModel.Notification)
                {
                    item.Title1 = item.Date?.ToPersianDate();
                }
                foreach (var item in newsModel.News)
                {
                    item.Title1 = item.Date?.ToPersianDate();
                }

            }
            catch(Exception ex)
            {
                newsModel = new NewsViewModel();
            }
            
            return View(newsModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
