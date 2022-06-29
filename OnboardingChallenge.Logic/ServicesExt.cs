using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using OnboardingChallenge.Data;
using OnboardingChallenge.Data.Repositories;
using OnboardingChallenge.Logic.Mappers;
using OnboardingChallenge.Logic.Services;
using OnboardingChallenge.Logic.Services.Impl;

namespace OnboardingChallenge.Logic
{
    public static class ServicesExt
    {
        public static IServiceCollection AddLogicServices(this IServiceCollection services)
        {
            //Data services
            services.AddDataServices();

            //Mapper
            services.AddAutoMapper(typeof(PersonMapper).Assembly);

            //Services
            services.AddScoped<IPersonService>(s => new PersonService(s.GetRequiredService<IPersonRepository>(), s.GetRequiredService<IMapper>()));
            services.AddScoped<ICityService>(s => new CityService(s.GetRequiredService<ICityRepository>(), s.GetRequiredService<IMapper>()));

            return services;
        }
    }
}