using GraphQL.API.DTO;
using GraphQL.API.Model;
using GraphQL.API.Repository;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.API.GraphqlCore
{
    public class CountryRecordMutation : ObjectGraphType<object>
    {

        public CountryRecordMutation(ICountryRecordRepository repository)
        {
            Name = "CountryRecordMutation";

            FieldAsync<CountryRecordType>(
                "createCountryRecord",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<CountryRecordInputType>> { Name = "countryRecordInput" }
                ),
                resolve: async context =>
                {
                    var countryRecordInput = context.GetArgument<CountryRecordDTO>("countryRecordInput");
                    return await repository.AddCountryRecordAsync(countryRecordInput);
                });

            FieldAsync<CountryRecordType>(
                "updateCountryRecord",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<CountryRecordInputType>> { Name = "countryRecordInput" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "year" }),
                resolve: async context =>
                {
                    var countryRecordInput = context.GetArgument<CountryRecord>("countryRecordInput");
                    var year = context.GetArgument<string>("year");

                    var countryRecordRetrieved = await repository.GetCountryRecordByYearAsync(year);
                    if (countryRecordRetrieved == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find country record."));
                        return null;
                    }
                    countryRecordRetrieved.Area = countryRecordInput.Area;
                    countryRecordRetrieved.Country = countryRecordInput.Country;
                    countryRecordRetrieved.TotalPopulation = countryRecordInput.TotalPopulation;
                    countryRecordRetrieved.Year = countryRecordInput.Year;

                    return await repository.UpdateCountryRecordAsync(countryRecordRetrieved);
                }
            );

            FieldAsync<StringGraphType>(
              "deleteCountryRecord",
              arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "year" }),
              resolve: async context =>
              {
                  var year = context.GetArgument<string>("year");

                  var countryRecordRetrieved = await repository.GetCountryRecordByYearAsync(year);
                  if (countryRecordRetrieved == null)
                  {
                      context.Errors.Add(new ExecutionError("Couldn't find country record."));
                      return null;
                  }

                  await repository.DeleteCountryRecordAsync(countryRecordRetrieved);
                  return $"Record for the country {countryRecordRetrieved.Country} in the year {year} has been deleted successfully.";
              }
          );
        }

    }
}
