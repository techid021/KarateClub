using KarateClub.Domain.Intefaces;
using KarateClub.Domain.Models;
using KarateClub.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KarateClub.Infra.Data.Repository
{
    public class AboutUsRepository : IAboutUsRepository
    {
        private KarateClubDBContext _ctx;
        public AboutUsRepository(KarateClubDBContext ctx)
        {
            this._ctx = ctx;
        }

        //گرفتن اطلاعات درباره ما جهت نمایش
        public AboutUs GetAboutUs()
        {
            return _ctx.AboutUs.OrderByDescending(i => i.Id).Single();
        }
    }
}
