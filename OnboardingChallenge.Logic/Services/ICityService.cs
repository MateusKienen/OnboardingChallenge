using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingChallenge.Logic.Services
{
    public interface ICityService
    {
        Task<Logic.Models.City> CreateAsync(Logic.Models.City city, CancellationToken cancellationToken = default);
        Task<Logic.Models.City> UpdateAsync(Logic.Models.City city, CancellationToken cancellationToken = default);
        Task<Logic.Models.City> GetAsync(long id, CancellationToken cancellationToken = default);
        Task DeleteAsync(Logic.Models.City city, CancellationToken cancellationToken = default);
    }
}
