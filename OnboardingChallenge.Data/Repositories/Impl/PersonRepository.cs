using Microsoft.EntityFrameworkCore;
using OnboardingChallenge.Data.Models;

namespace OnboardingChallenge.Data.Repositories.Impl
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(OnboardingChallengeDbContext context) : base(context)
        {
        }

        public override async Task<Person> GetAsync<T>(long id, CancellationToken cancellationToken)
        {
            return await this.GetQuery().Include(c => c.City).Where(c => c.Id == id).FirstOrDefaultAsync(cancellationToken);
        }
    }
}
