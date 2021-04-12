using KarateClub.Domain.Intefaces;
using KarateClub.Domain.Models;
using KarateClub.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
        public async Task<AboutUs> GetAboutUs(CancellationToken cancellationToken)
        {
            return await _ctx.AboutUs.OrderByDescending(i => i.Id).AsNoTracking().SingleOrDefaultAsync(cancellationToken);
        }
    }
}
