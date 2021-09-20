using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.API.DTO
{
    public class CountryRecordDTO
    {
        [Required]
        public string Country { get; set; }

        [Required]
        public string Year { get; set; }

        [Required]
        public long Area { get; set; }

        [Required]
        public long TotalPopulation { get; set; }
    }
}
