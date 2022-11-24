using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        //table Activities in our DB based on Activity class
        public DbSet<Activity> Activities { get; set; }

        public DbSet<Fruit> Fruits { get; set; } //table Fruits
    }
}