using KarateClub.Application.Interfaces;
using KarateClub.Application.ViewModels;
using KarateClub.Domain.Models;
using KarateClub.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<ContactUsController> _logger;
        private IAboutUsService _aboutUsService;
        private IContactUsService _contactUsService;
        private ICoachService _coachService;
        AboutUsViewModel model = null;
        CoachViewModel coachModel = null;

        public ContactUsController(ILogger<ContactUsController> logger, IAboutUsService aboutUsService, IContactUsService contactUsService, ICoachService coachService)
        {
            this._aboutUsService = aboutUsService;
            this._contactUsService = contactUsService;
            this._coachService = coachService;
            this._logger = logger;
        }

        #region ContactUs
        [HttpGet]
        [Route("ContactUs")]
        public async Task<IActionResult> Contact(CancellationToken cancellationToken)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    ViewData["AboutData"] = model;
                    return View();
                }
                model = await _aboutUsService.GetAboutUs(cancellationToken);
                ViewData["AboutData"] = model;
            }
            catch
            {
                model = null;
            }

            return View();
        }
        #endregion

        #region RegisterOpinion
        [Route("ContactUs")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost] // CallBack Method
        [Route("ContactUs")]
        public async Task<IActionResult> Register(ContactUsViewModel registerContact, CancellationToken cancellationToken)
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

                await _contactUsService.RegisterContact(contact, cancellationToken);
                ViewData["message"] = "پیام شما با موفقیت ثبت شد";
                ViewData["AboutData"] = model;
                return View("Contact");


            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "خطایی در سیستم بوجود آمده است");
                ViewData["message"] = "خطایی در سیستم به وجود آمده است. لطفا در زمان دیگری مجددا تلاش بفرمایید";
                ViewData["AboutData"] = model;
                return View("Contact");
            }
        }
        #endregion

        #region AboutUs
        [HttpGet]
        [Route("AboutUs")]
        public async Task<IActionResult> AboutUs(CancellationToken cancellationToken)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(coachModel);
                }
                coachModel = await _coachService.GetCoaches(cancellationToken);
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
