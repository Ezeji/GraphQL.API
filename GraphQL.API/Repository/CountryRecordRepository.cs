using GraphQL.API.Data;
using GraphQL.API.DTO;
using GraphQL.API.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.API.Repository
{

    /// <summary>  
    /// CountryRecordRepository.  
    /// </summary> 
    public class CountryRecordRepository : ICountryRecordRepository
    {

        /// <summary>  
        /// The _context.  
        /// </summary>  
        private readonly CountryRecordDbContext _context;

        public CountryRecordRepository(CountryRecordDbContext context)
        {
            _context = context;
        }

        public async Task<CountryRecord> AddCountryRecordAsync(CountryRecordDTO countryRecordDTO)
        {
            var newCountryRecord = new CountryRecord
            {
                Area = countryRecordDTO.Area,
                Country = countryRecordDTO.Country,
                TotalPopulation = countryRecordDTO.TotalPopulation,
                Year = countryRecordDTO.Year
            };

            var savedCountryRecord = (await _context.CountryRecords.AddAsync(newCountryRecord)).Entity;
            await _context.SaveChangesAsync();
            return savedCountryRecord;
        }

        public async Task<bool> DeleteCountryRecordAsync(CountryRecord countryRecord)
        {
            _context.CountryRecords.Remove(countryRecord);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<CountryRecord> GetCountryRecordByTotalPopulationAsync(long totalPopulation)
        {
            var countryRecord = await _context.CountryRecords.FirstOrDefaultAsync(x => x.TotalPopulation == totalPopulation);

            return countryRecord;
        }

        public async Task<CountryRecord> GetCountryRecordByYearAsync(string year)
        {
            var countryRecord = await _context.CountryRecords.FirstOrDefaultAsync(x => x.Year == year);

            return countryRecord;
        }

        public async Task<List<CountryRecord>> GetCountryRecordsAsync()
        {
            var countryRecord = await _context.CountryRecords.ToListAsync();

            return countryRecord;
        }

        public async Task<CountryRecord> UpdateCountryRecordAsync(CountryRecord countryRecord)
        {
            var updatedCountryRecord = (_context.CountryRecords.Update(countryRecord)).Entity;
            await _context.SaveChangesAsync();
            return updatedCountryRecord;

        }
    }
}
