using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RamMotorsWebApp.Models;

namespace RamMotorsWebApp.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Car> Car { get; set; } = default!;
        public DbSet<CarRequest> CarRequests { get; set; } = default!;
        public DbSet<RtoRequest> RtoRequests { get; set; } = default!;

    }
}
