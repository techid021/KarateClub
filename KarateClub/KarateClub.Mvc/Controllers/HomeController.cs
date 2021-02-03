using KarateClub.Application.Interfaces;
using KarateClub.Application.ViewModels;
using KarateClub.Mvc.Models;
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

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IYearService yearService)
        {
            _logger = logger;
            this.yearService = yearService;//test
        }

        public IActionResult Index()
        {
            YearViewModel model = yearService.GetYears();//test
            return View();
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
