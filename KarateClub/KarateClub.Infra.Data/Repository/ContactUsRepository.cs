using KarateClub.Domain.Intefaces;
using KarateClub.Domain.Models;
using KarateClub.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

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
        public async void AddContact(ContactUs contactUs, CancellationToken cancellationToken)
        {
            await _ctx.ContactUs.AddAsync(contactUs, cancellationToken);
        }

        public void Save()
        {
            _ctx.SaveChanges();
        }
    }
}
