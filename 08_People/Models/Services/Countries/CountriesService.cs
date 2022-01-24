using _08_People.Models.Entity;
using _08_People.Models.Repos;
using _08_People.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _08_People.Models.Services
{
    public class CountriesService : ICountriesService
    {
        private readonly ICountriesRepo _countriesRepo;
        public CountriesService(ICountriesRepo countriesRepo)
        {
            _countriesRepo = countriesRepo;
        }


        public Country Add(CreateCountryViewModel newCountry)
        {
            if(newCountry == null)
            {
                return null;
            }
            else
            {
                Country country = new Country()
                {
                    CountryName = newCountry.CountryName
                };

                return _countriesRepo.Create(country);
            }
        }

        public List<Country> All()
        {
            return _countriesRepo.Read();
        }

        public Country FindById(int id)
        {
            return _countriesRepo.Read(id);
        }

        public List<Country> Search(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return All();
            }
            else
            {
                List<Country> result = All().Where(x => x.CountryName.ToLower().Contains(search.ToLower())).ToList();
                
                if(result.Count < 1)
                {
                    return All();
                }
                else
                {
                    return result;
                }
            }
        }

        public bool Edit(int id, CreateCountryViewModel eCountry)
        {
            Country country = FindById(id);

            if(country != null)
            {
                country.CountryName = eCountry.CountryName;             
                return _countriesRepo.Update(country);
            }
            return false;
        }

        public bool Remove(int id)
        {
            Country country = FindById(id);

            if (country != null)
            {
                return _countriesRepo.Delete(country);
            }
            return false;
        }


    }
}
