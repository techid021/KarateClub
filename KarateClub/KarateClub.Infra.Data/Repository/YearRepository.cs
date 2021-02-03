using KarateClub.Domain.Intefaces;
using KarateClub.Domain.Models;
using KarateClub.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace KarateClub.Infra.Data.Repository
{
    public class YearRepository: IYearRepository
    {
        private KarateClubDBContext _ctx;
        public YearRepository(KarateClubDBContext ctx)
        {
            this._ctx = ctx;
        }

        public IEnumerable<Year> GetYears()
        {
            return _ctx.Year;
        }
    }
}
