using OnboardingChallenge.Server.ViewModels.City;

namespace OnboardingChallenge.Server.ViewModels.Person
{
    public class PersonViewModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Cpf { get; set; }

        public int Age { get; set; }

        public CityViewModel City { get; set; }
    }
}
