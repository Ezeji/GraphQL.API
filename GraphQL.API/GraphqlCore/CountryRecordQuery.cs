using GraphQL.API.Repository;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.API.GraphqlCore
{
    public class CountryRecordQuery : ObjectGraphType<object>
    {
        public CountryRecordQuery(ICountryRecordRepository repository)
        {
            Name = "CountryRecordQuery";

            Field<CountryRecordType>(
               "countryRecordByYear",
               arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "year" }),
               resolve: context => repository.GetCountryRecordByYearAsync(context.GetArgument<string>("year"))
            );

            Field<CountryRecordType>(
               "countryRecordByTotalPopulation",
               arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "totalPopulation" }),
               resolve: context => repository.GetCountryRecordByTotalPopulationAsync(context.GetArgument<long>("totalPopulation"))
            );

            Field<ListGraphType<CountryRecordType>>(
             "countryRecords",
             resolve: context => repository.GetCountryRecordsAsync()
          );
        }
    }
}
