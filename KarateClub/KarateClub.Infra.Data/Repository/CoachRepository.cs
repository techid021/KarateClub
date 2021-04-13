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
    public class CoachRepository : ICoachRepository
    {
        private KarateClubDBContext _ctx;
        public CoachRepository(KarateClubDBContext ctx)
        {
            this._ctx = ctx;
        }

        //خواندن اساتید برای نمایش در صفحه درباره ما
        public async Task<IEnumerable<Coach>> GetCoaches(CancellationToken cancellationToken)
        {
            var result = await _ctx.Coach.OrderByDescending(i => i.Rank)
                .Where(o => o.IsActive == 1).AsNoTracking().ToListAsync(cancellationToken);
            return result;
        }
    }
}
