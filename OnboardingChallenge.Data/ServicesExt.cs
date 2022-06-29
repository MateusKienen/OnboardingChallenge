using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnboardingChallenge.Data.Repositories;
using OnboardingChallenge.Data.Repositories.Impl;

namespace OnboardingChallenge.Data
{
    public static class ServicesExt
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            //context
            services.AddDbContext<OnboardingChallengeDbContext>((services, options) =>
            {
                options.UseSqlServer(@"Data Source=localhost\sqlexpress;Initial Catalog=onboarding_db;Integrated Security=True;Pooling=False");
            });

            services.AddScoped<IPersonRepository>(s => new PersonRepository(s.GetRequiredService<OnboardingChallengeDbContext>()));
            services.AddScoped<ICityRepository>(s => new CityRepository(s.GetRequiredService<OnboardingChallengeDbContext>()));

            return services;
        }
    }
}