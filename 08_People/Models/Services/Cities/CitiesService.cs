using _08_People.Models.Entity;
using _08_People.Models.Repos;
using _08_People.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _08_People.Models.Services
{
    public class CitiesService : ICitiesService
    {
        private readonly ICitiesRepo _citiesRepo;
        public CitiesService(ICitiesRepo citiesRepo)
        {
            _citiesRepo = citiesRepo;
        }


        public City Add(CreateCityViewModel newCity)
        {
            if(newCity == null)
            {
                return null;
            }
            else
            {
                City city = new City()
                {
                    CityName = newCity.CityName,
                    CountryId = newCity.CountryId
                };

                return _citiesRepo.Create(city);
            }
        }

        public List<City> All()
        {
            return _citiesRepo.Read();
            //throw new NotImplementedException();
        }

        public City FindById(int id)
        {
            return _citiesRepo.Read(id);
        }

        public List<City> Search(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return All();
            }
            else
            {
                List<City> result = All().Where(x => x.CityName.ToLower().Contains(search.ToLower())).ToList();
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

        public bool Edit(int id, CreateCityViewModel eCity)
        {
            City city = FindById(id);

            if(city != null)
            {
                city.CityName = eCity.CityName;
                city.CountryId = eCity.CountryId;
                return _citiesRepo.Update(city);
            }
            return false;
        }

        public bool Remove(int id)
        {
            City city = FindById(id);

            if(city != null)
            {
                return _citiesRepo.Delete(city);
            }
            return false;
        }
    }
}
