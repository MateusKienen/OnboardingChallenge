namespace OnboardingChallenge.Server.ViewModels.Person
{
    public class CreatePersonRequest
    {
        public string Name { get; set; }

        public string Cpf { get; set; }

        public int Age { get; set; }

        public long CityId { get; set; }
    }
}
