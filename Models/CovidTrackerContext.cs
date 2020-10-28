using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class CovidTrackerContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<UserCheckin> UserCheckIns { get; set; }
        public CovidTrackerContext(DbContextOptions options) : base (options)
        {

        }
    }
}
