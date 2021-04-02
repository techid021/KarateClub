using KarateClub.Application.Interfaces;
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
            service.AddScoped<IYearService, YearService>();
            service.AddScoped<INewsService, NewsService>();
            service.AddScoped<IAboutUsService, AboutUsService>();
            service.AddScoped<IContactUsService, ContactUsService>();
            service.AddScoped<ICoachService, CoachService>();

            //Infra Data Layer
            service.AddScoped<ITestRepository, TestRepository>();
            service.AddScoped<IYearRepository, YearRepository>();
            service.AddScoped<INewsRepository, NewsRepository>();
            service.AddScoped<IAboutUsRepository, AboutUsRepository>();
            service.AddScoped<IContactUsRepository, ContactUsRepository>();
            service.AddScoped<ICoachRepository, CoachRepository>();
        }
    }
}
