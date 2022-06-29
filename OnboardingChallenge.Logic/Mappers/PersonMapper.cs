using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingChallenge.Logic.Mappers
{
    public class PersonMapper : Profile
    {
        public PersonMapper()
        {
            this.CreateMap<Expression<Func<Logic.Models.Person>>, Expression<Func<Data.Models.Person>>>();
            this.CreateMap<Logic.Models.Person, Data.Models.Person>().ReverseMap();
        }
    }
}
