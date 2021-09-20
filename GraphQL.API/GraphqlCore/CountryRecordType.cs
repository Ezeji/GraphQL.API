using GraphQL.API.Model;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.API.GraphqlCore
{
    public class CountryRecordType : ObjectGraphType<CountryRecord>
    {
        public CountryRecordType()
        {
            Field(x => x.Country).Description("Country.");
            Field(x => x.Year).Description("Year.");
            Field(x => x.Area).Description("Area.");
            Field(x => x.TotalPopulation).Description("Total population.");
        }
    }
}
