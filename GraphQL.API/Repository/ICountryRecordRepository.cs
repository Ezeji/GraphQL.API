using GraphQL.API.DTO;
using GraphQL.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.API.Repository
{
    public interface ICountryRecordRepository
    {
        Task<List<CountryRecord>> GetCountryRecordsAsync();
        Task<CountryRecord> GetCountryRecordByYearAsync(string year);
        Task<CountryRecord> GetCountryRecordByTotalPopulationAsync(long totalPopulation);
        Task<CountryRecord> AddCountryRecordAsync(CountryRecordDTO countryRecordDTO);
        Task<CountryRecord> UpdateCountryRecordAsync(CountryRecord countryRecord);
        Task<bool> DeleteCountryRecordAsync(CountryRecord countryRecord);
    }
}
