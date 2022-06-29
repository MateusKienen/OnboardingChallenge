using AutoMapper;
using OnboardingChallenge.Data.Repositories;
using OnboardingChallenge.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingChallenge.Logic.Services.Impl
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository personRepository;
        private readonly IMapper mapper;

        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            this.personRepository = personRepository;
            this.mapper = mapper;
        }

        public async Task<Person> CreateAsync(Person person, CancellationToken cancellationToken = default)
        {
            var result = await this.personRepository.CreateAsync<Person>(this.mapper.Map<Data.Models.Person>(person), cancellationToken);
            var createdPerson = await this.GetAsync(result.Id, cancellationToken);
            return this.mapper.Map<Person>(createdPerson);
        }

        public async Task DeleteAsync(Person person, CancellationToken cancellationToken = default)
        {
            await this.personRepository.DeleteAsync<Person>(this.mapper.Map<Data.Models.Person>(person), cancellationToken);
        }

        public async Task<Person> GetAsync(long id, CancellationToken cancellationToken = default)
        {
            var result = await this.personRepository.GetAsync<Person>(id, cancellationToken);
            return this.mapper.Map<Person>(result);
        }

        public async Task<Person> UpdateAsync(Person person, CancellationToken cancellationToken = default)
        {
            var result = await this.personRepository.UpdateAsync<Person>(this.mapper.Map<Data.Models.Person>(person), cancellationToken);
            var updatedPerson = await this.GetAsync(result.Id, cancellationToken);
            return this.mapper.Map<Person>(updatedPerson);
        }
    }
}
