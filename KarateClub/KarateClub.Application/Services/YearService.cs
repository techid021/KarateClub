﻿using KarateClub.Application.Interfaces;
using KarateClub.Application.ViewModels;
using KarateClub.Domain.Intefaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace KarateClub.Application.Services
{
    public class YearService : IYearService
    {
        private IYearRepository _yearRepository;
        public YearService(IYearRepository testRepository)
        {
            this._yearRepository = testRepository;
        }

        public YearViewModel GetYears()
        {
            return new YearViewModel
            {
                Years = _yearRepository.GetYears()
            };
        }
    }
}
