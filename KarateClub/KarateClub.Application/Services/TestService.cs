using KarateClub.Application.Interfaces;
using KarateClub.Application.ViewModels;
using KarateClub.Domain.Intefaces;
using KarateClub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KarateClub.Application.Services
{
    public class TestService : ITestService
    {
        private ITestRepository _testRepository;
        public TestService(ITestRepository testRepository)
        {
            this._testRepository = testRepository;
        }

        public TestViewModel GetTests()
        {
            return new TestViewModel
            {
                Tests = _testRepository.GetTests()
            };
        }
    }
}
