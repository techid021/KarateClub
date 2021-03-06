using KarateClub.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KarateClub.Infra.Data.Context
{
    public class KarateClubDBContext : DbContext
    {
        public KarateClubDBContext(DbContextOptions<KarateClubDBContext> options) : base(options)
        {

        }


        //dbsets
        public DbSet<Test> Tests { get; set; } //بعدا پاک شود - تستی
        public DbSet<Year> Year { get; set; } 
        public DbSet<News> News { get; set; }


    }
}
