using KarateClub.Domain.Intefaces;
using KarateClub.Domain.Models;
using KarateClub.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace KarateClub.Infra.Data.Repository
{
    public class TestRepository : ITestRepository
    {
        private KarateClubDBContext _ctx;
        public TestRepository(KarateClubDBContext ctx)
        {
            this._ctx = ctx;
        }

        public IEnumerable<Test> GetTests()
        {
            return _ctx.Tests;
        }
    }
}
