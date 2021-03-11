using KarateClub.Application.Interfaces;
using KarateClub.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarateClub.Mvc.Controllers
{
    public class ContactUsController : Controller
    {

        private IAboutUsService _aboutUsService;
        public ContactUsController(IAboutUsService aboutUsService)
        {
            this._aboutUsService = aboutUsService;
        }

        [HttpGet]
        [Route("ContactUs")]
        public IActionResult Contact()
        {
            AboutUsViewModel model = null;
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                model = _aboutUsService.GetAboutUs();
               

            }
            catch (Exception ex)
            {
                model = null;
            }

            return View(model);
        }

        #region RegisterOpinion
        [Route("ContactUs")]
        public IActionResult Register()
        {
            return View();
        }

        //[HttpPost] // CallBack Method
        //[Route("ContactUs")]
        //public IActionResult Register(RegisterViewModels register)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(register);
        //    }

        //    CheckUser checkUser = userService.CheckUser(register.UserName, register.Email);
        //    if (checkUser != CheckUser.Ok)
        //    {
        //        ViewBag.Check = checkUser;
        //        return View(register);
        //    }

        //    User user = new User
        //    {
        //        Email = register.Email.Trim(),
        //        UserName = register.UserName.Trim()
        //    };
        //    userService.RegisterUser(user);
        //    return View("SuccessRegister", register);
        //}
        #endregion


    }
}
