using KarateClub.Domain.Intefaces;
using KarateClub.Domain.Models;
using KarateClub.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KarateClub.Infra.Data.Repository
{
    public class CoachRepository : ICoachRepository
    {
        private KarateClubDBContext _ctx;
        public CoachRepository(KarateClubDBContext ctx)
        {
            this._ctx = ctx;
        } 

        //خواندن اساتید برای نمایش در صفحه درباره ما
        public IEnumerable<Coach> GetCoaches()
        {
            return _ctx.Coach.OrderByDescending(i => i.Rank)
                .Where(o => o.IsActive == 1).AsNoTracking().ToList();
        }
    }
}
