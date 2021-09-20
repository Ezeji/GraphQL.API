using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.API.GraphqlCore
{
    public class CountryRecordInputType : InputObjectGraphType
    {
        public CountryRecordInputType()
        {
            Name = "AddCountryRecordInput";
            Field<NonNullGraphType<StringGraphType>>("country");
            Field<NonNullGraphType<StringGraphType>>("year");
            Field<NonNullGraphType<IntGraphType>>("area");
            Field<NonNullGraphType<IntGraphType>>("totalPopulation");
        }
    }
}
