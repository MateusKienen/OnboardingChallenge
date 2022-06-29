using Microsoft.EntityFrameworkCore;
using OnboardingChallenge.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingChallenge.Data
{
    public class OnboardingChallengeDbContext : DbContext
    {
 
        public DbSet<City>? Cities { get; set; }
        
        public DbSet<Person>? Persons { get; set; }

        public OnboardingChallengeDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
