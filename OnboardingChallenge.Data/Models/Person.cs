using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace OnboardingChallenge.Data.Models
{
    public class Person : BaseEntity
    {
        [Required]
        [MaxLength(300)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(11)]
        public string Cpf { get; set; }
        
        [Required]
        public int Age { get; set; }


        //Relationships
        public City City { get; set; }

        public long CityId { get; set; }
    }
}
