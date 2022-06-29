using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingChallenge.Logic.Services
{
    public interface IPersonService
    {
        Task<Logic.Models.Person> CreateAsync(Logic.Models.Person person, CancellationToken cancellationToken = default);
        Task<Logic.Models.Person> UpdateAsync(Logic.Models.Person person, CancellationToken cancellationToken = default);
        Task<Logic.Models.Person> GetAsync(long id, CancellationToken cancellationToken = default);
        Task DeleteAsync(Logic.Models.Person person, CancellationToken cancellationToken = default);
    }
}
