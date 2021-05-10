using KarateClub.Mvc.Models.ExtentionMethods;
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

        public NewsController(INewsService newsService, ILogger<NewsController> logger)
        {
            this._newsService = newsService;
            this._logger = logger;
        }


        [HttpGet]
        public async Task<IActionResult> Index(int startIndex, CancellationToken cancellationToken)
        {
            NewsViewModel newsModel = null;
            if (startIndex == 0)
                startIndex = 1;
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(new NewsViewModel());
                }

                newsModel = await _newsService.GetNewsByPagingAsync(startIndex, cancellationToken);//

                int count = await _newsService.GetNewsCount(cancellationToken);
                ViewBag.Count = count / 20;
                ViewBag.StartIndex = startIndex;

                foreach (var item in newsModel.News)
                {
                    item.Title3 = string.Format("data:" + item.Extention + ";base64,{0}", Convert.ToBase64String(item.Image));
                    item.Title2 = item.Date?.ToPersianDate();
                }


            }
            catch (Exception ex)
            {
                newsModel = new NewsViewModel();
            }

            return View(newsModel);
        }

    }
}
