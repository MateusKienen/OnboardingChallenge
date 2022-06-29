using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingChallenge.Logic.Mappers
{
    public class CityMapper : Profile
    {
        public CityMapper()
        {
            this.CreateMap<Logic.Models.City, Data.Models.City>().ReverseMap();
        }
    }
}
