using KarateClub.Application.Interfaces;
using KarateClub.Application.ViewModels;
using KarateClub.Domain.Models;
using KarateClub.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace KarateClub.Mvc.Controllers
{
    public class ContactUsController : Controller
    {

        private IAboutUsService _aboutUsService;
        private IContactUsService _contactUsService;
        private ICoachService _coachService;
        AboutUsViewModel model = null;
        CoachViewModel coachModel = null;

        public ContactUsController(IAboutUsService aboutUsService, IContactUsService contactUsService, ICoachService coachService)
        {
            this._aboutUsService = aboutUsService;
            this._contactUsService = contactUsService;
            this._coachService = coachService;
        }

        [HttpGet]
        [Route("ContactUs")]
        public async Task<IActionResult> Contact()
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    ViewData["AboutData"] = model;
                    return View();
                }
                model = await _aboutUsService.GetAboutUs(CancellationToken.None);
                ViewData["AboutData"] = model;
            }
            catch
            {
                model = null;
            }

            return View();
        }

        #region RegisterOpinion
        [Route("ContactUs")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost] // CallBack Method
        [Route("ContactUs")]
        public async Task<IActionResult> Register(ContactUsViewModel registerContact)
        {
            model = await _aboutUsService.GetAboutUs(CancellationToken.None);
            if (!ModelState.IsValid)
            {
                ViewData["AboutData"] = model;
                return View("Contact");
            }
            try
            {
                string hostName = Dns.GetHostName();
                string ip = Dns.GetHostByName(hostName).AddressList[0].ToString();

                ContactUs contact = new ContactUs
                {
                    Email = registerContact.contactUs.Email,
                    InsertDate = DateTime.Now,
                    IsRead = 0,
                    FullName = registerContact.contactUs.FullName.Trim(),
                    Comment = registerContact.contactUs.Comment.Trim(),
                    IP = ip
                };

                _contactUsService.RegisterContact(contact);
                ViewData["message"] = "پیام شما با موفقیت ثبت شد";
                ViewData["AboutData"] = model;
                return View("Contact");


            }
            catch
            {
                ViewData["message"] = "خطایی در سیستم به وجود آمده است. لطفا در زمان دیگری مجددا تلاش بفرمایید";
                ViewData["AboutData"] = model;
                return View("Contact");
            }
        }
        #endregion

        #region AboutUs
        [HttpGet]
        [Route("AboutUs")]
        public async Task<IActionResult> AboutUs()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(coachModel);
                }
                coachModel = await _coachService.GetCoaches(CancellationToken.None);
                foreach (var item in coachModel.Coaches)
                {
                    item.Extention = string.Format("data:" + item.Extention + ";base64,{0}", Convert.ToBase64String(item.Image));
                }
            }
            catch
            {
                coachModel = null;
            }

            return View(coachModel);
        }
        #endregion
    }
}
