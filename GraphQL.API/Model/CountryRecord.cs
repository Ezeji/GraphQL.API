using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.API.Model
{
    public partial class CountryRecord
    {
        public int CountryId { get; set; }
        public string Country { get; set; }
        public string Year { get; set; }
        public long Area { get; set; }
        public long TotalPopulation { get; set; }
    }
}
