using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnboardingChallenge.Logic.Models;
using OnboardingChallenge.Logic.Services;
using OnboardingChallenge.Server.ViewModels;
using OnboardingChallenge.Server.ViewModels.Person;

namespace OnboardingChallenge.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : Controller
    {
        private readonly IPersonService service;
        private readonly IMapper mapper;
        private readonly ICityService cityService;

        public PersonController(IPersonService service, IMapper mapper, ICityService cityService)
        {
            this.service = service;
            this.mapper = mapper;
            this.cityService = cityService;
        }

        [HttpGet]
        public async Task<ActionResult<PersonViewModel>> Get(long id, CancellationToken cancellationToken)
        {
            var result = await this.service.GetAsync(id, cancellationToken);

            if (result is null)
            {
                return NotFound();
            }

            return this.Ok(this.mapper.Map<PersonViewModel>(result));
        }

        [HttpPost]
        [ProducesResponseType(typeof(PersonViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PersonViewModel>> Create([FromBody] CreatePersonRequest person, CancellationToken cancellationToken)
        {
            var city = await this.cityService.GetAsync(person.CityId, cancellationToken);
            if (city is null)
            {
                return BadRequest("ID de cidade não encontrado.");
            }

            var result = await this.service.CreateAsync(this.mapper.Map<Person>(person), cancellationToken);

            return this.Ok(this.mapper.Map<PersonViewModel>(result));
        }

        [HttpPut]
        [ProducesResponseType(typeof(PersonViewModel), StatusCodes.Status200OK)]
        public async Task<ActionResult<PersonViewModel>> Update([FromBody] UpdatePersonRequest person, CancellationToken cancellationToken)
        {
            var city = await this.cityService.GetAsync(person.CityId, cancellationToken);
            if (city is null)
            {
                return BadRequest("ID de cidade não encontrado.");
            }

            var result = await this.service.UpdateAsync(this.mapper.Map<Person>(person), cancellationToken);
            return this.Ok(this.mapper.Map<PersonViewModel>(result));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(PersonViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete([FromRoute] long id, CancellationToken cancellationToken)
        {
            var person = await this.service.GetAsync(id, cancellationToken);

            if (person is null)
            {
                return this.NotFound();
            }

            await this.service.DeleteAsync(this.mapper.Map<Person>(person), cancellationToken);
            return this.NoContent();
        }
    }
}
