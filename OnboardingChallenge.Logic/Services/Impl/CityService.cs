using AutoMapper;
using OnboardingChallenge.Data.Repositories;
using OnboardingChallenge.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingChallenge.Logic.Services.Impl
{
    public class CityService : ICityService
    {
        private readonly ICityRepository cityRepository;
        private readonly IMapper mapper;

        public CityService(ICityRepository cityRepository, IMapper mapper)
        {
            this.cityRepository = cityRepository;
            this.mapper = mapper;
        }

        public async Task<City> CreateAsync(City city, CancellationToken cancellationToken = default)
        {
            var result = await this.cityRepository.CreateAsync<City>(this.mapper.Map<Data.Models.City>(city), cancellationToken);
            return this.mapper.Map<City>(result);
        }

        public async Task DeleteAsync(City city, CancellationToken cancellationToken = default)
        {
            await this.cityRepository.DeleteAsync<City>(this.mapper.Map<Data.Models.City>(city), cancellationToken);
        }

        public async Task<City> GetAsync(long id, CancellationToken cancellationToken = default)
        {
            var result = await this.cityRepository.GetAsync<City>(id, cancellationToken);
            return this.mapper.Map<City>(result);
        }

        public async Task<City> UpdateAsync(City city, CancellationToken cancellationToken = default)
        {
            var result = await this.cityRepository.UpdateAsync<City>(this.mapper.Map<Data.Models.City>(city), cancellationToken);
            return this.mapper.Map<City>(result);
        }
    }
}
