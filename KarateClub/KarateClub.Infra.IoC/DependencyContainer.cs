﻿using KarateClub.Application.Interfaces;
using KarateClub.Application.Services;
using KarateClub.Domain.Intefaces;
using KarateClub.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace KarateClub.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection service)
        {
            //Application Layer
            service.AddScoped<ITestService, TestService>();

            //Infra Data Layer
            service.AddScoped<ITestRepository, TestRepository>();

        }
    }
}
