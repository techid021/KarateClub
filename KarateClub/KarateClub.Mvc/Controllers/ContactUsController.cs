using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarateClub.Mvc.Controllers
{
    public class ContactUsController : Controller
    {


        public ContactUsController()
        {

        }

        [HttpGet]
        [Route("ContactUs")]
        public IActionResult Contact()
        {
            return View();
        }
    }
}
