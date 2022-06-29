using OnboardingChallenge.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingChallenge.Data.Repositories.Impl
{
    public class CityRepository : BaseRepository<City>, ICityRepository
    {
        public CityRepository(OnboardingChallengeDbContext context) : base(context)
        {
        }
    }
}
