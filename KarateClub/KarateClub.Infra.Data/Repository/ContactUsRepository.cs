using KarateClub.Domain.Intefaces;
using KarateClub.Domain.Models;
using KarateClub.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace KarateClub.Infra.Data.Repository
{
    public class ContactUsRepository : IContactUsRepository
    {
        private KarateClubDBContext _ctx;
        public ContactUsRepository(KarateClubDBContext ctx)
        {
            this._ctx = ctx;
        }

        //درج نظر کاربران جهت پیشنهادات و انتقادات
        public void AddContact(ContactUs contactUs)
        {
            _ctx.ContactUs.Add(contactUs);
        }

        public void Save()
        {
            _ctx.SaveChanges();
        }
    }
}
