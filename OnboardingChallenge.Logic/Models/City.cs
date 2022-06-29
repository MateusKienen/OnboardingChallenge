using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace OnboardingChallenge.Logic.Models
{
    public class City
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string UF { get; set; }
    }
}
