using AutoMapper;
using OnboardingChallenge.Server.ViewModels.Person;

namespace OnboardingChallenge.Server.Mappers
{
    public class PersonMapper : Profile
    {
        public PersonMapper()
        {
            this.CreateMap<Logic.Models.Person, PersonViewModel>().ReverseMap();
            this.CreateMap<Logic.Models.Person, CreatePersonRequest>().ReverseMap();
            this.CreateMap<Logic.Models.Person, UpdatePersonRequest>().ReverseMap();
        }
    }
}
