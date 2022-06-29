using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnboardingChallenge.Logic.Models;
using OnboardingChallenge.Logic.Services;
using OnboardingChallenge.Server.ViewModels.City;
using OnboardingChallenge.Server.ViewModels.Person;

namespace OnboardingChallenge.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : Controller
    {
        private readonly ICityService service;
        private readonly IMapper mapper;

        public CityController(ICityService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CityViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CityViewModel>> Get([FromRoute] long id, CancellationToken cancellationToken)
        {
            var result = await this.service.GetAsync(id, cancellationToken);

            if (result is null)
            {
                return this.NotFound();
            }

            return this.Ok(this.mapper.Map<CityViewModel>(result));
        }

        [HttpPost]
        [ProducesResponseType(typeof(CityViewModel), StatusCodes.Status200OK)]
        public async Task<ActionResult<CityViewModel>> Create([FromBody] CreateCityRequest city, CancellationToken cancellationToken)
        {
            var result = await this.service.CreateAsync(this.mapper.Map<City>(city), cancellationToken);
            return this.Ok(this.mapper.Map<CityViewModel>(result));
        }

        [HttpPut]
        [ProducesResponseType(typeof(CityViewModel), StatusCodes.Status200OK)]
        public async Task<ActionResult<CityViewModel>> Update([FromBody] UpdateCityRequest city, CancellationToken cancellationToken)
        {
            var result = await this.service.UpdateAsync(this.mapper.Map<City>(city), cancellationToken);
            return this.Ok(this.mapper.Map<CityViewModel>(result));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(CityViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete([FromRoute] long id, CancellationToken cancellationToken)
        {
            var city = await this.service.GetAsync(id, cancellationToken);
            
            if (city is null)
            {
                return this.NotFound();
            }

            await this.service.DeleteAsync(this.mapper.Map<City>(city), cancellationToken);
            return this.NoContent();
        }

    }
}
