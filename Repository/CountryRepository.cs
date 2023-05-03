using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Model;

namespace PokemonReviewApp.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public CountryRepository(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public bool CountryExist(int id)
        {
            return _dataContext.Countries.Any(c => c.Id == id);
        }

        public bool CreateCountry(Country country)
        {
            _dataContext.Countries.Add(country);
            return Save();
        }

        public ICollection<Country> GetCountries()
        {
            return _dataContext.Countries.ToList();
        }

        public Country GetCountry(int id)
        {
            return _dataContext.Countries.Where(
                c => c.Id == id).FirstOrDefault();
        }

        public Country GetCountryByOwner(int ownerId)
        {
            return _dataContext.Owners.Where(o => o.Id == ownerId)
                .Select(c => c.Country).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnersFromACountry(int countryId)
        {
            return _dataContext.Owners.Where(o => o.Country.Id == countryId)
                .ToList();
        }

        public bool Save()
        {
            var saved = _dataContext.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
