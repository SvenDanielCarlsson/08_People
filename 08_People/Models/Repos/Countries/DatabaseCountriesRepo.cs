using _08_People.Data;
using _08_People.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _08_People.Models.Repos
{
    public class DatabaseCountriesRepo : ICountriesRepo
    {
        private readonly PeopleDbContext _peopleDbContext;
        public DatabaseCountriesRepo(PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }




        public Country Create(Country country)
        {
            _peopleDbContext.Countries.Add(country);
            _peopleDbContext.SaveChanges();
            return country;
        }

        public List<Country> Read()
        {
            return _peopleDbContext.Countries.ToList();
        }

        public Country Read(int id)
        {
            return _peopleDbContext.Countries.SingleOrDefault(c => c.Id == id);
        }

        public bool Update(Country country)
        {
            _peopleDbContext.Countries.Update(country);
            _peopleDbContext.SaveChanges();
            return true;
        }

        public bool Delete(Country country)
        {
            _peopleDbContext.Countries.Remove(country);
            _peopleDbContext.SaveChanges();
            return true;
        }
    }
}
