using AutoMapper;
using OnboardingChallenge.Server.ViewModels.City;

namespace OnboardingChallenge.Server.Mappers
{
    public class CityMapper : Profile
    {
        public CityMapper()
        {
            this.CreateMap<Logic.Models.City, CityViewModel>().ReverseMap();
            this.CreateMap<Logic.Models.City, CreateCityRequest>().ReverseMap();
            this.CreateMap<Logic.Models.City, UpdateCityRequest>().ReverseMap();
        }
    }
}
